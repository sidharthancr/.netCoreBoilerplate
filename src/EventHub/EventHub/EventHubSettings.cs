using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub.EventHub
{
    public class EventHubSettings
    {
        public string Name { get; set; }
        public string ConsumerGroupName { get; set; }
        public string ConnectionString { get; set; }
        public string StorageContainerName { get; set; }
        public string StorageConnectionString { get; set; }
    }
}
