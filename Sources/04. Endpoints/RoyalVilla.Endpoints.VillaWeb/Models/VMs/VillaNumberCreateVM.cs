using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalVilla.Endpoints.VillaWeb.Models.DTOs;

namespace RoyalVilla.Endpoints.VillaWeb.Models.VMs;

public class VillaNumberCreateVM
{
	public VillaNumberCreateVM()
	{
		VillaNumber = new VillaNumberCreateDTO();
	}

	public VillaNumberCreateDTO VillaNumber { get; set; }

	[ValidateNever]
	public IEnumerable<SelectListItem> VillaList { get; set; }
}
