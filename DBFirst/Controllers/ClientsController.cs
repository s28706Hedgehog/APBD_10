using DBFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientsService service) : ControllerBase
{
    [HttpDelete("/{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        try
        {
            var deleted = await service.DeleteClientAsync(idClient);
        }
        catch (ExistingTripsException e)
        {
            return Conflict("Client has existing trips and cannot be deleted");
        }
        catch (InvalidOperationException e)
        {
            return NotFound("Client not found");
        }

        return Ok();
    }
}