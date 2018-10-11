using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlate.Config
{
    public class AppSettings
    {
        public AzureServiceBuss ServiceBus { get; set; }
        public EventHub EventHub { get; set; }
    }

    public class AzureServiceBuss
    {

        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
        public string TopicName { get; set; }
        public string SubscriptionName { get; set; }
    }

    public class EventHub
    {
        public string ConnectionString { get; set; }
        public string ConsumerGroupName { get; set; }
        public string Name { get; set; }
        public string StorageContainerName { get; set; }
        public string StorageConnectionString { get; set; }
    }
}
