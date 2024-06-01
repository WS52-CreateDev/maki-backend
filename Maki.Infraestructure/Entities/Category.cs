using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models;

public class Category
{
    public int Id { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string Name { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public List<Product> Products { get; set; }
}