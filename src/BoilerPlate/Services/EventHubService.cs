using BoilerPlate.Config;
using BoilerPlate.Interfaces;
using EventHub.EventHub;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlate.Services
{
    public class EventHubService : IEventHubService
    {
        private AppSettings _appsettings;
        private IEventHubSender _eventHubSender;
        private EventProcessorHost _eventProcessorHost;

        public EventHubService(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings.Value;
            Init();
        }

        private void Init()
        {
            var eventHub = _appsettings.EventHub;
            _eventHubSender = new EventHubSender(eventHub.ConnectionString, eventHub.Name);
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(eventHub.ConnectionString)
            {
                EntityPath = eventHub.Name
            };

        }

        public async Task SendAsync(string message)
        {
            await _eventHubSender.SendAsync(message);
        }

        public async Task Register()
        {
            var eventHub = _appsettings.EventHub;
            _eventProcessorHost = new EventProcessorHost(
        eventHub.Name,
        PartitionReceiver.DefaultConsumerGroupName,
        eventHub.ConnectionString,
        eventHub.StorageConnectionString,
        eventHub.StorageContainerName);
            await _eventProcessorHost.RegisterEventProcessorAsync<EventHubMessageProcessor>();
        }

        public async Task UnRegister()
        {
            if (_eventProcessorHost != null)
            {
                await _eventProcessorHost.UnregisterEventProcessorAsync();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }


    }
}
