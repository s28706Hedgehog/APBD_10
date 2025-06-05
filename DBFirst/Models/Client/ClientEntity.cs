namespace DBFirst.Models.Client;

public partial class ClientEntity
{
    public int IdClient { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public virtual ICollection<ClientTrip.ClientTripEntity> ClientTrips { get; set; } = new List<ClientTrip.ClientTripEntity>();
}
