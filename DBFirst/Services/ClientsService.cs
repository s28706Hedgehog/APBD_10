using DBFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Services;

public interface IClientsService
{
    public Task<bool> DeleteClientAsync(int clientId);
}

public class ClientsService(Apbd10Context context) : IClientsService
{
    public async Task<bool> DeleteClientAsync(int clientId)
    {
        var hasTrips = await context.ClientTrips
            .AnyAsync(clTr => clTr.IdClient == clientId);
        if (!hasTrips)
        {
            throw new ExistingTripsException(clientId);
        }

        var client = await context.Clients
            .SingleAsync(cl => cl.IdClient == clientId);
        // Throws exception if there's no element or if there's more than one

        context.Clients.Remove(client);
        await context.SaveChangesAsync();

        return true;
    }
}