using DBFirst.Data;
using DBFirst.Models.Client;
using DBFirst.Models.Country;
using DBFirst.Models.Trip;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Services;

public interface ITripsService
{
    public Task<List<TripGetDto>> GetTripsAsync();
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
                    .Select(ct => new ClientGetDto()
                    {
                        FirstName = ct.IdClientEntityNavigation.FirstName,
                        LastName = ct.IdClientEntityNavigation.LastName
                    }).ToList()
            })
            .OrderByDescending(t => t.DateFrom)
            .ToListAsync();

        return tripDtos;
    }
}