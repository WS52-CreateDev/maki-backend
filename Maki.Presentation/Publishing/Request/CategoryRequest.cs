using System.ComponentModel.DataAnnotations;

namespace _1_API.Request;

public class CategoryRequest
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
}