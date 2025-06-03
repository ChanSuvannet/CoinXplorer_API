using CoinXplorer_API.Services;
using CoinXplorer_API.Hubs;
using AppRoute.Routes;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// HttpClient can be singleton, no problem
builder.Services.AddHttpClient();

// Register CoinExternalService as scoped (good practice if it uses HttpClient)
builder.Services.AddScoped<CoinExternalService>();

// SignalR
builder.Services.AddSignalR();

// Register the background service (singleton by default)
builder.Services.AddHostedService<CoinBroadcastService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); 

app.MapControllers();
app.MapAppRoutes();

app.MapHub<CoinHub>("/coinhub");

app.Run();