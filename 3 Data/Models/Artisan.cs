using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models;

public class Artisan
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Photo { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string Province { get; set; }
    [Required]
    public string Info { get; set; }
    [Required]
    [MaxLength(12)]
    [MinLength(6)]
    public string Password { get; set; }
    [Required]
    public string BusinessName { get; set; }
    [Required]
    public string BusinessAddress { get; set; }
}