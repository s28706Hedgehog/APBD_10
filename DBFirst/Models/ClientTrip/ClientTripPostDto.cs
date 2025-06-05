using System.ComponentModel.DataAnnotations;
using DBFirst.Models.Client;

namespace DBFirst.Models.ClientTrip;

public class ClientTripPostDto
{
    public required ClientPostDto ClientPostDto;

    public required int IdTrip { get; set; }

    [MaxLength(120)] public required string TripName { get; set; } = null!;

    public DateTime? PaymentDate { get; set; } // it may be null I guess
}