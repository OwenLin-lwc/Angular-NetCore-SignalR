using Microsoft.AspNetCore.SignalR;
using signalr_hub.Models;
using System;
using System.Threading.Tasks;

namespace signalr_hub.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ChatMessage", "default", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Clients.Group(groupName).SendAsync("ChatMessage", "default", $"{Context.ConnectionId} has left the group {groupName}.");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task NewMessage(ChatMessage message)
        {
            try
            {
                using (var context = new ChatContext())
                {
                    context.ChatMessage.Add(message);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            await Clients.Group(message.ChatGroup.ToString()).SendAsync("MessageReceived", message);
        }
    }
}
