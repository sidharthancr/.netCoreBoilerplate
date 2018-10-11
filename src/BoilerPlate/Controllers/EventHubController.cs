using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.Contract;
using BoilerPlate.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventHubController : ControllerBase
    {

        private readonly IEventHubService _eventHubService;
        public EventHubController(IEventHubService eventHubService)
        {
            _eventHubService = eventHubService;
        }
        [HttpPost]
        public void Send([FromBody] Message message)
        {
            _eventHubService.SendAsync(message.Text);
        }

        [HttpPut("Register")]
        public void Register()
        {
            _eventHubService.Register();
        }

        [HttpPut("UnRegister")]
        public void UnRegister()
        {
            _eventHubService.UnRegister();
        }
    }
}