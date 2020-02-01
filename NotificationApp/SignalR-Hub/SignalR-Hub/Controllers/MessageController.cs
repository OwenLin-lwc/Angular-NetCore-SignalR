using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;
using SignalRHub.Interfaces;
using SignalRHub.Models;
using System;

namespace SignalR_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody] Message message)
        {
            string retMessage;
            try
            {
                _hubContext.Clients.All.BroadcastMessage(message.Type, message.Payload);
                retMessage = "Success";
            }
            catch(Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}