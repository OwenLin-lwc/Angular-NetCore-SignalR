using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalr_hub.Hubs;
using signalr_hub.Models;
using System;

namespace signalr_hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<NotifyHub> _hubContext;

        public MessageController(IHubContext<NotifyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody] Message message)
        {
            string retMessage;
            try
            {
                _hubContext.Clients.Group(message.UserGroup).SendAsync("NotifyMessage", message.Type, message.Payload);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}