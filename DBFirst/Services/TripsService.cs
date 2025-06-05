using DBFirst.Data;
using DBFirst.Models.Client;
using DBFirst.Models.ClientTrip;
using DBFirst.Models.Country;
using DBFirst.Models.Trip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Services;

public interface ITripsService
{
    public Task<List<TripGetDto>> GetTripsAsync();
    public Task<Boolean> AssignClientToTripAsync(ClientTripPostDto clientTripPostDto);
}

public class TripsService(Apbd10Context context) : ITripsService
{
    public async Task<List<TripGetDto>> GetTripsAsync()
    {
        var tripDtos = await context.Trips
            .Select(t => new TripGetDto
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries
                    .Select(c => new CountryGetDto()
                    {
                        Name = c.Name
                    }).ToList(),
                Clients = t.ClientTrips
                    .Select(ct => new ClientShortGetDto()
                    {
                        FirstName = ct.IdClientEntityNavigation.FirstName,
                        LastName = ct.IdClientEntityNavigation.LastName
                    }).ToList()
            })
            .OrderByDescending(t => t.DateFrom)
            .ToListAsync();

        return tripDtos;
    }

    public async Task<Boolean> AssignClientToTripAsync(ClientTripPostDto clientTripPostDto)
    {
        // Does exist with specified pesel*
        var cl = await context.Clients
            .FirstAsync(cl => cl.Pesel == clientTripPostDto.ClientPostDto.Pesel);

        if (cl == null)
        {
            throw new PeselNotFoundException();
        }

        var isRegisteredForTrip = await context.ClientTrips
            .AnyAsync(clTr => clTr.IdClient == cl.IdClient
                              && clTr.IdTrip == clientTripPostDto.IdTrip);

        if (isRegisteredForTrip)
        {
            throw new AlreadyRegisteredForTripException();
        }

        // Will throw exception when not found
        var tripEntity = await context.Trips
            .SingleAsync(tr => tr.IdTrip == clientTripPostDto.IdTrip);

        if (tripEntity.DateFrom < DateTime.Now)
        {
            throw new OldTripException();
        }

        await context.ClientTrips
            .AddAsync(new ClientTripEntity(
                cl.IdClient,
                tripEntity.IdTrip,
                DateTime.UtcNow,
                clientTripPostDto.PaymentDate
            ));

        return true;
    }
}