﻿namespace DBFirst.Models.Trip;

public partial class TripEntity
{
    public int IdTrip { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public virtual ICollection<ClientTrip.ClientTripEntity> ClientTrips { get; set; } = new List<ClientTrip.ClientTripEntity>();

    public virtual ICollection<Country.CountryEntity> IdCountries { get; set; } = new List<Country.CountryEntity>();
}
