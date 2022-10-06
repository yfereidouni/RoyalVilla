﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoyalVilla.Endpoints.VillaWeb.Models;
using RoyalVilla.Endpoints.VillaWeb.Models.DTOs;
using RoyalVilla.Endpoints.VillaWeb.Services.IServices;

namespace RoyalVilla.Endpoints.VillaWeb.Controllers;

public class VillaController : Controller
{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;

    public VillaController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }

    public async Task<IActionResult> IndexVilla()
    {
        List<VillaDTO> list = new();

        var response = await _villaService.GetAllAsync<APIResponse>();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
        }

        return View(list);
    }

    [HttpGet]
    public IActionResult CreateVilla()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _villaService.CreateAsync<APIResponse>(model);
            if (response != null && response.IsSuccess == true)
            {
                return RedirectToAction(nameof(IndexVilla));
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateVilla(int villaId)
    {
        var response = await _villaService.GetAsync<APIResponse>(villaId);
        if (response != null && response.IsSuccess)
        {
            VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
            return View(_mapper.Map<VillaUpdateDTO>(model));
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _villaService.UpdateAsync<APIResponse>(model);
            if (response != null && response.IsSuccess == true)
            {
                return RedirectToAction(nameof(IndexVilla));
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteVilla(int villaId)
    {
        var response = await _villaService.GetAsync<APIResponse>(villaId);
        if (response != null && response.IsSuccess)
        {
            VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
            return View(model);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteVilla(VillaDTO model)
    {
        var response = await _villaService.DeleteAsync<APIResponse>(model.Id);
        if (response != null && response.IsSuccess == true)
        {
            return RedirectToAction(nameof(IndexVilla));
        }
        return View(model);
    }
}
