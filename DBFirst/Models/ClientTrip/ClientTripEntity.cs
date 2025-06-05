namespace DBFirst.Models.ClientTrip;

public partial class ClientTripEntity
{
    public int IdClient { get; set; }

    public int IdTrip { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Client.ClientEntity IdClientEntityNavigation { get; set; } = null!;

    public virtual Trip.TripEntity IdTripEntityNavigation { get; set; } = null!;
}
