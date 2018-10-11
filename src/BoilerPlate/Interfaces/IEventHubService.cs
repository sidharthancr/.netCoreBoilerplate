using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlate.Interfaces
{
    public interface IEventHubService
    {
        Task SendAsync(string message);
        Task Register();
        Task UnRegister();
    }
}
