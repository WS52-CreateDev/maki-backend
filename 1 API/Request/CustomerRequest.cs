using System.ComponentModel.DataAnnotations;

namespace _1_API.Request;

public class CustomerRequest 
{
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Photo { get; set; }
    [Required]
    [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
    public int Age { get; set; }
    [Required]
    public string Province { get; set; }
    [Required]
    public string Info { get; set; }
    [Required] 
    [MaxLength(12)]
    [MinLength(6)]
    public string Password { get; set; }

}