using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Product
{
    public UInt32 Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Production date is required.")]
    public DateTime? ProductionDate { get; set; }

    [Required(ErrorMessage = "Expiration date is required.")]
    public DateTime? ExpirationDate { get; set; }

    [Required(ErrorMessage = "Manufacturer is required.")]
    public string? Manufacturer { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    public string? Country { get; set; }
}