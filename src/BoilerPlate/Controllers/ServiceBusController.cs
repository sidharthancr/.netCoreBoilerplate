using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.Common;
using BoilerPlate.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    public class ServiceBusController : Controller
    {

        private IServiceBusService _serviceBusService;

        public ServiceBusController(IServiceBusService serviceBusService)
        {
            _serviceBusService = serviceBusService;
        }

        [HttpGet]
        public void Receive()
        {
           
            _serviceBusService.Receive();
        }

        [HttpPost]
        public void Send([FromBody] Message value)
        {
            _serviceBusService.Send(value);
        }
    }
}