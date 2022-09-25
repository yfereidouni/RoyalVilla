using System.ComponentModel.DataAnnotations;

namespace RoyalVilla.Endpoints.VillaAPI.Models.DTOs;

public sealed class VillaNumberUpdateDTO
{
    [Required]
    public int VillaNo { get; set; }
    [Required]
    public int VillaId { get; set; }
    public string SpecialDetails { get; set; }
}