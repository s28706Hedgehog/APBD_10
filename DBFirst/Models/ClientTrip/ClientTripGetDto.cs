namespace DBFirst.Models.ClientTrip;

public class ClientTripGetDto
{
    public int IdClient { get; set; }
    public int IdTrip { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
}