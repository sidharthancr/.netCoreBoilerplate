using ServiceBus.Common;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Queue
{
    public class AzureQueueReceiver<T> : IAzureQueueReceiver<T> where T : class
    {

        public AzureQueueReceiver(AzureQueueSettings settings)
        {
            this._settings = settings;
            Init();
        }

        public void Receive(
            Func<T, MessageProcessResponse> onProcess,
            Action<Exception> onError,
            Action onWait)
        {
            
            var options = new MessageHandlerOptions(e => { onError(e.Exception); return Task.CompletedTask; })
            {
                AutoComplete = false,
                MaxAutoRenewDuration = TimeSpan.FromMinutes(1)
            };
                _client.RegisterMessageHandler(
                        async (message, token) =>
                        {
                            try
                            {
                            // Get message
                            var data = Encoding.UTF8.GetString(message.Body);
                                T item = JsonConvert.DeserializeObject<T>(data);

                            // Process message
                            var result = onProcess(item);

                                if (result == MessageProcessResponse.Complete)
                                    await _client.CompleteAsync(message.SystemProperties.LockToken);
                                else if (result == MessageProcessResponse.Abandon)
                                    await _client.AbandonAsync(message.SystemProperties.LockToken);
                                else if (result == MessageProcessResponse.Dead)
                                    await _client.DeadLetterAsync(message.SystemProperties.LockToken);

                            // Wait for next message
                            onWait();
                            }
                            catch (Exception ex)
                            {
                                await _client.DeadLetterAsync(message.SystemProperties.LockToken);
                                onError(ex);
                            }
                        }, options);
                
        }



        private AzureQueueSettings _settings;
        private QueueClient _client;

        private void Init()
        {
            _client = new QueueClient(this._settings.ConnectionString, this._settings.QueueName);
        }

    }
}
