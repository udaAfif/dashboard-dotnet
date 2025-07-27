using System.ComponentModel.DataAnnotations;

namespace dotNetDashboard.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public string Email { get; set; }

    public bool Status { get; set; } = true;

    public string Role { get; set; }
}
