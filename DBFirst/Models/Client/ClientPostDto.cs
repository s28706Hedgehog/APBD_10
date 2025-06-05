using System.ComponentModel.DataAnnotations;

namespace DBFirst.Models.Client;

public class ClientPostDto
{
    [MaxLength(120)]
    public required string FirstName { get; set; } = null!;

    [MaxLength(120)]
    public required string LastName { get; set; } = null!;

    [MaxLength(120)]
    public required string Email { get; set; } = null!;

    [MaxLength(120)]
    public required string Telephone { get; set; } = null!;

    [MaxLength(120)]
    public required string Pesel { get; set; } = null!;
}