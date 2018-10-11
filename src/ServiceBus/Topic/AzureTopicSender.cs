using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiver.Azure.ServiceBus.Topic
{
    public class AzureTopicSender<T> : IAzureTopicSender<T> where T : class
    {

        public AzureTopicSender(AzureTopicSettings settings)
        {
            this._settings = settings;
            Init();
        }

        public async Task SendAsync(T item)
        {
            await SendAsync(item, null);
        }

        public async Task SendAsync(T item, Dictionary<string, object> properties)
        {
            var json = JsonConvert.SerializeObject(item);
            var message = new Message(Encoding.UTF8.GetBytes(json));
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    message.UserProperties.Add(prop.Key, prop.Value);
                }
            }

            await _client.SendAsync(message);
        }


        private AzureTopicSettings _settings;
        private TopicClient _client;

        private void Init()
        {
            _client = new TopicClient(this._settings.ConnectionString, this._settings.TopicName);
        }

    }
}
