using CoinXplorer_API.Routes;

namespace AppRoute.Routes
{
    public static class AppRoutes
    {
        public static void MapAppRoutes(this IEndpointRouteBuilder app)
        {
            // Map the root route
            var apiGroup = app.MapGroup("/api");
            apiGroup.MapCoinRoutes();
        }
    }
}
