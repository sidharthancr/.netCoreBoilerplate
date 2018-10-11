using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.EventHub
{
   public class EventHubSender: IEventHubSender
    {
        private EventHubClient _eventHubClient;

        public EventHubSender(string connectionString,string eventHubName) 
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString)
            {
                EntityPath = eventHubName
            };
            _eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public Task SendAsync(string message)
        {
          return _eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
        }

    }
}
