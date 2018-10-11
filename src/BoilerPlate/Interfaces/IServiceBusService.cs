using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.Common;

namespace BoilerPlate.Interfaces
{
    public interface IServiceBusService
    {
        void Send(Message message);
        void Receive();
    }
}
