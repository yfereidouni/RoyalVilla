using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoyalVilla.Endpoints.VillaWeb.Models;
using RoyalVilla.Endpoints.VillaWeb.Models.DTOs;
using RoyalVilla.Endpoints.VillaWeb.Services.IServices;
using System.Diagnostics;

namespace RoyalVilla.Endpoints.VillaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public HomeController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> list = new();

            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

    }
}