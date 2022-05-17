using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Hubs
{
    public class BinanceHub : Hub
    {
        public async Task SendMessage(string body, string recipient)
        {
            await Clients.All.SendAsync("ReceiveMessage", body, recipient);
        }
    }
}
