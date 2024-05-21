﻿using System.ComponentModel.DataAnnotations;

namespace _3_Data.Models;

public class Product
{
    public int Id { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string Name { get; set; }
    public DateTime PublicationDate { get; set; } = DateTime.Now;
    [Required]
    public int Price { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Width { get; set; }
    [Required]
    public string Height { get; set; }
    [Required]
    public string Depth { get; set; }
    [Required]
    public string Material { get; set; }
    [Required]
    public int Artisan { get; set; }
    [Required]
    public int Category { get; set; }
    
}