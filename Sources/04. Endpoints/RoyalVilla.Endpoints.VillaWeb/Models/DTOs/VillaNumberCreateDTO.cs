﻿using System.ComponentModel.DataAnnotations;

namespace RoyalVilla.Endpoints.VillaWeb.Models.DTOs;

public sealed class VillaNumberCreateDTO
{
    [Required]
    public int VillaNo { get; set; }
    [Required]
    public int VillaId { get; set; }
    public string SpecialDetails { get; set; }
}
