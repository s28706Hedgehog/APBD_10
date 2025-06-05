using DBFirst.Models.Client;
using DBFirst.Models.Country;

namespace DBFirst.Models.Trip;

public class TripGetDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public List<CountryGetDto> Countries { get; set; } = new();
    public List<ClientGetDto> Clients { get; set; } = new();
}