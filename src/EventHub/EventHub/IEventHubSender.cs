using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.EventHub
{
    public interface IEventHubSender
    {
        Task SendAsync(string message);
    }
}
