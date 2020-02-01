using System.Threading.Tasks;

namespace SignalRHub.Interfaces
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
