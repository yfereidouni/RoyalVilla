using System.ComponentModel.DataAnnotations;

namespace RoyalVilla.Endpoints.VillaAPI.Models.DTOs;

public sealed class VillaNumberDTO
{
    [Required]
    public int VillaNo { get; set; }
    public string SpecialDetails { get; set; }
}