using System.Threading.Tasks;
using BoilerPlate.Interfaces;
using ServiceBus.Queue;
using ServiceBus.Common;
using System;
using BoilerPlate.Config;
using Microsoft.Extensions.Options;

namespace BoilerPlate.Services
{
    public class ServiceBusService : IServiceBusService
    {
        private IAzureQueueReceiver<Message> _azureQueueReceiver;
        private IAzureQueueSender<Message> _azureQueueSender;
        private AppSettings _appsettings;

        public ServiceBusService(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings.Value;
            Init();
        }


        public async void Send(Message message)
        {
            await _azureQueueSender.SendAsync(message);
        }

        private void Init()
        {
            var settings = new AzureQueueSettings(
               connectionString: _appsettings.ServiceBus.ConnectionString,
               queueName: _appsettings.ServiceBus.QueueName);
            _azureQueueSender = new AzureQueueSender<Message>(settings);
            _azureQueueReceiver = new AzureQueueReceiver<Message>(settings);
        }

        public async void Receive()
        {
            try
            {
                _azureQueueReceiver.Receive(message =>
                {
                    Console.WriteLine("RECEIVED MESSAGE-------->" + message.Text);
                    return MessageProcessResponse.Complete;
                },
                    ex => { Console.WriteLine(ex.Message); throw ex; },
                    () => Console.WriteLine("Waiting..."));
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
