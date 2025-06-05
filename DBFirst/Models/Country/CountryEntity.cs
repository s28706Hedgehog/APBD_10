namespace DBFirst.Models.Country;

public partial class CountryEntity
{
    public int IdCountry { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Trip.TripEntity> IdTrips { get; set; } = new List<Trip.TripEntity>();
}
