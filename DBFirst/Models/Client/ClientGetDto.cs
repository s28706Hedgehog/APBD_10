﻿using System.ComponentModel.DataAnnotations;

namespace DBFirst.Models.Client;

public class ClientGetDto
{
    public required string FirstName { get; set; } = null!;
    public required string LastName { get; set; } = null!;
    public required string Email { get; set; } = null!;
    public required string Telephone { get; set; } = null!;
    public required string Pesel { get; set; } = null!;
}