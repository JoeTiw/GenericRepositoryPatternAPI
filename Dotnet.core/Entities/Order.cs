using System.ComponentModel.DataAnnotations;

namespace Dotnet.core.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
}