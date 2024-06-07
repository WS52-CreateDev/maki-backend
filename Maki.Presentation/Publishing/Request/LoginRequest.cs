using System.ComponentModel.DataAnnotations;

namespace _1_API.Request;

public class LoginRequest
{
    [Microsoft.Build.Framework.Required]
    [EmailAddress]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required] public string Password { get; set; }
}