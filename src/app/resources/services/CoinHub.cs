using Microsoft.AspNetCore.SignalR;

namespace CoinXplorer_API.Hubs
{
    public class CoinHub : Hub
    {
        // Optional: add hub methods here for client calls
        public async Task SendCoinUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveCoinUpdate", message);
        }
    }
}
