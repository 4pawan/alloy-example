using System.ComponentModel.DataAnnotations;

namespace alloy_example.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
