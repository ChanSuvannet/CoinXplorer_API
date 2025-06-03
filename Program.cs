using CoinXplorer_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers service to enable API controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<CoinExternalService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable routing for API controllers
app.MapControllers();

app.Run();
