using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3_Data.Models;

    public class Design
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Characteristics { get; set; }
        
        public string Photo { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
