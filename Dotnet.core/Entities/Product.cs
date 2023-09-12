using System.ComponentModel.DataAnnotations;

namespace Dotnet.core.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
}