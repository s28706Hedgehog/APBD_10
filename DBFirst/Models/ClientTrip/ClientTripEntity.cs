using DBFirst.Models.Client;
using DBFirst.Models.Trip;

namespace DBFirst.Models.ClientTrip;

public partial class ClientTripEntity
{
    public ClientTripEntity(int idClient, int idTrip, DateTime registeredAt, DateTime? paymentDate)
    {
        IdClient = idClient;
        IdTrip = idTrip;
        RegisteredAt = registeredAt;
        PaymentDate = paymentDate;
    }

    public int IdClient { get; set; }

    public int IdTrip { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Client.ClientEntity IdClientEntityNavigation { get; set; } = null!;

    public virtual Trip.TripEntity IdTripEntityNavigation { get; set; } = null!;
}
