﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalVilla.Core.Contracts.Villas;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Endpoints.VillaAPI.Models.DTOs;
using RoyalVilla.Endpoints.VillaAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace RoyalVilla.Endpoints.VillaAPI.Controllers;

//[Route("api/[controller]")]
[Route("api/Villas")]
[ApiController]
public sealed class VillasController : ControllerBase
{
    private readonly IVillaRepository _villaRepository;
    private readonly IMapper _mapper;
    private readonly APIResponse _response;

    public VillasController(IVillaRepository villaRepository,IMapper mapper)
    {
        _villaRepository = villaRepository;
        _mapper = mapper;
        _response = new();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<APIResponse>> GetVillas()
    {
        try
        {
            //_logger1.LogInformation($"(Serilog) Getting All villas");
            //_logger.Log("(iLog) Getting All villas", "info");

            IEnumerable<Villa> villaList = await _villaRepository.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(200, Type = typeof(VillaDTO))]
    public async Task<ActionResult<APIResponse>> GetVilla(int id)
    {
        
        try
        {
            if (id == 0)
            {
                //_logger1.LogInformation($"(Serilog) Get Villa Error with Id {id}");
                //_logger.Log($"(iLog) Get Villa Error with Id {id}", "error");

                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var villa = await _villaRepository.GetAsync(c => c.Id == id);

            if (villa == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = _mapper.Map<VillaDTO>(villa);
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO villaDTO)
    {
        //if (!ModelState.IsValid)
        //    return BadRequest(ModelState);
        try
        {

            if (await _villaRepository.GetAsync(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "Villa already exists!");
                return BadRequest(ModelState);
            }

            if (villaDTO is null)
                return BadRequest();

            Villa villa = _mapper.Map<Villa>(villaDTO);
            await _villaRepository.CreateAsync(villa);
            _response.Result = _mapper.Map<Villa>(villaDTO);
            _response.StatusCode = System.Net.HttpStatusCode.Created;
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    
    [HttpDelete("{id:int}", Name = "DeleteVilla")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
    {
        try
        {
            if (id == 0)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var villa = await _villaRepository.GetAsync(c => c.Id == id);

            if (villa == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            await _villaRepository.RemoveAsync(villa);
            _response.StatusCode = System.Net.HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpPut("{id:int}", Name = "UpdateVilla")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaDTO)
    {
        try
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            Villa model = _mapper.Map<Villa>(villaDTO);

            await _villaRepository.UpdateAsync(model);

            _response.StatusCode = System.Net.HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }

        return _response;
    }
    
    [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
    {
        if (patchDTO == null || id == 0)
            return BadRequest();

        var villa = await _villaRepository.GetAsync(c => c.Id == id, tracked: false);

        if (villa is null)
            return NotFound();

        VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

        //Syntax for JsonPatchDocument
        patchDTO.ApplyTo(villaDTO, ModelState);
        Villa model = _mapper.Map<Villa>(villaDTO);

        await _villaRepository.UpdateAsync(model);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return NoContent();
    }
    
}
