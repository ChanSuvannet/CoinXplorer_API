using CoinXplorer_API.Hubs;
using CoinXplorer_API.Services;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

public class CoinBroadcastService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHubContext<CoinHub> _hubContext;
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(60);

    public CoinBroadcastService(IServiceScopeFactory scopeFactory, IHubContext<CoinHub> hubContext)
    {
        _scopeFactory = scopeFactory;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var coinService = scope.ServiceProvider.GetRequiredService<CoinExternalService>();
                try
                {
                    var coins = await coinService.GetLiveCoinsAsync();

                    if (coins != null)
                    {
                        Console.WriteLine($"[{DateTime.Now}] Fetched coins.");
                        await _hubContext.Clients.All.SendAsync("ReceiveCoinUpdates", coins, cancellationToken: stoppingToken);
                    }
                    else
                    {
                        Console.WriteLine($"[{DateTime.Now}] No coins fetched or rate limited.");
                    }
                }
                catch (HttpRequestException ex) when (ex.Message.Contains("429"))
                {
                    Console.WriteLine("Rate limit hit! Waiting 1 minute before retry...");
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                    continue; // Retry after delay
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }

}