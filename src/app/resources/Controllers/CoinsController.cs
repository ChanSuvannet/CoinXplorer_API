using CoinXplorer_API.Services;

namespace CoinXplorer_API.Routes
{
    public static class CoinController
    {
        public static RouteGroupBuilder MapCoinRoutes(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/coins");

            group.MapGet("/live", async (CoinExternalService service) =>
            {
                var coins = await service.GetLiveCoinsAsync();
                return Results.Ok(coins);
            });

            group.MapGet("/ping", () => Results.Ok("Coin Route Alive"));

            return group;
        }
    }
}
