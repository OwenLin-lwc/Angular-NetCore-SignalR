using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace signalr_hub.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("NotifyMessage", "default", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Clients.Group(groupName).SendAsync("NotifyMessage", "default", $"{Context.ConnectionId} has left the group {groupName}.");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
