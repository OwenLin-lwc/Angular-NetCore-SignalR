﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartApp_Server.DataStorage;
using ChartApp_Server.HubConfig;
using ChartApp_Server.TimerFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChartApp_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            //_hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData());
            return Ok(new { Message = "Request Completed" });
        }
    }
}