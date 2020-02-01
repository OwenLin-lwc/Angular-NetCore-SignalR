using ChartApp_Server.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChartApp_Server.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) => 
            await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
