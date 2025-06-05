using DBFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController(ITripsService tripsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTrips() // highlights issue with max time???
    {
        return Ok(await tripsService.GetTripsAsync());
    }
}