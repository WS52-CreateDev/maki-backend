namespace _1_API.Response;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime PublicationDate { get; set; } = DateTime.Now;
    public int Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Depth { get; set; }
    public string Material { get; set; }
    public int Artisan { get; set; }
    public int Category { get; set; }
}