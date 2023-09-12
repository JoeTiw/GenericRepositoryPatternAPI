using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dotnet.core.Entities;

public class OrderItem
{
    [Key]
    [JsonIgnore]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; } 
}