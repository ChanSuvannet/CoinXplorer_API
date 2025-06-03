using Microsoft.AspNetCore.Mvc;
using CoinXplorer_API.Services;
using CoinXplorer_API.DTOs;

namespace CoinXplorer_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoinController : ControllerBase
{
    private readonly CoinExternalService _externalService;

    public CoinController(CoinExternalService externalService)
    {
        _externalService = externalService;
    }

    [HttpGet("live")]
    public async Task<IActionResult> GetLiveCoins()
    {
        var coins = await _externalService.GetLiveCoinsAsync();
        return Ok(coins);
    }
}
