﻿using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalVilla.Core.Contracts.Villas;
using RoyalVilla.Core.Contracts.VillasNumbers;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Core.Entities.VillasNumbers;
using RoyalVilla.Endpoints.VillaAPI.Models;
using RoyalVilla.Endpoints.VillaAPI.Models.DTOs;
using System.Reflection.Metadata;

namespace MagicVilla.VillaAPI.Controllers;

//[Route("api/[controller]")]
[Route("api/VillasNumbers")]
[ApiController]
public sealed class VillasNumbersController : ControllerBase
{
    protected APIResponse _response;
    private readonly IVillaRepository _villaRepository;
    private readonly IVillaNumberRepository _villaNumberRepository;
    private readonly IMapper _mapper;
    //private readonly ILogging _logger;
    private readonly ILogger<VillasNumbersController> _logger1;

    public VillasNumbersController(
        IVillaRepository villaRepository,
        IVillaNumberRepository villaNumberRepository,
        IMapper mapper,
        //ILogging logger,
        ILogger<VillasNumbersController> logger1)
    {
        _villaRepository = villaRepository;
        _villaNumberRepository = villaNumberRepository;
        _mapper = mapper;
        //_logger = logger;
        _logger1 = logger1;

        _response = new();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<APIResponse>> GetVillaNumbers()
    {
        try
        {
            //_logger1.LogInformation($"(Serilog) Getting All villas");
            //_logger.Log("(iLog) Getting All villas", "info");

            IEnumerable<VillaNumber> villaList = await _villaNumberRepository.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaList);
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

    [HttpGet("villaNo", Name = "GetVillaNumber")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(200, Type = typeof(VillaDTO))]
    public async Task<ActionResult<APIResponse>> GetVillaNumber(int vilaNo)
    {
        try
        {
            if (vilaNo == 0)
            {
                //_logger1.LogInformation($"(Serilog) Get Villa Error with Id {vilaNo}");
                //_logger.Log($"(iLog) Get Villa Error with Id {vilaNo}", "error");

                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var villa = await _villaNumberRepository.GetAsync(c => c.VillaNo == vilaNo);

            if (villa == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = _mapper.Map<VillaNumberDTO>(villa);
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
    public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO villaDTO)
    {
        //if (!ModelState.IsValid)
        //    return BadRequest(ModelState);
        try
        {

            if (await _villaNumberRepository.GetAsync(u => u.VillaNo == villaDTO.VillaNo) != null)
            {
                ModelState.AddModelError("", "VillaNumber already exists!");
                return BadRequest(ModelState);
            }

            if (await _villaRepository.GetAsync(u => u.Id == villaDTO.VillaId) == null)
            {
                ModelState.AddModelError("CustomError","Villa ID is Invalid!");
                return BadRequest(ModelState);
            }

            if (villaDTO is null)
                return BadRequest();

            VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);
            await _villaNumberRepository.CreateAsync(model);
            _response.Result = _mapper.Map<VillaNumber>(villaDTO);
            _response.StatusCode = System.Net.HttpStatusCode.Created;
            return CreatedAtRoute("GetVillaNumber", new { id = model.VillaNo }, _response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpDelete("villaNo", Name = "DeleteVillaNumber")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int villaNo)
    {
        try
        {
            if (villaNo == 0)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var villaNumber = await _villaNumberRepository.GetAsync(c => c.VillaNo == villaNo);

            if (villaNumber == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            await _villaNumberRepository.RemoveAsync(villaNumber);
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

    [HttpPut("villaNo", Name = "UpdateVillaNumber")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int villaNo, [FromBody] VillaNumberUpdateDTO villaDTO)
    {
        try
        {
            if (villaDTO == null || villaNo != villaDTO.VillaNo)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            #region process-with-Id-and-BaseEntity
            //var villaNumberUpdate = await _villaNumberRepository.GetAsync(c => c.VillaNo == villaNo);
            //villaNumberUpdate.VillaNo = villaDTO.VillaNo;
            //villaNumberUpdate.UpdatedDate= DateTime.Now;
            //villaNumberUpdate.SpecialDetails = villaDTO.SpecialDetails;
            #endregion

            VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);

            await _villaNumberRepository.UpdateAsync(model);

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

    [HttpPatch("villaNo", Name = "UpdatePartialVillaNumber")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePartialVilla(int villaNo, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
    {
        if (patchDTO == null || villaNo == 0)
            return BadRequest();

        var villa = await _villaNumberRepository.GetAsync(c => c.VillaNo == villaNo, tracked: false);

        if (villa is null)
            return NotFound();


        VillaNumberUpdateDTO villaDTO = _mapper.Map<VillaNumberUpdateDTO>(villa);

        //Syntax for JsonPatchDocument
        patchDTO.ApplyTo(villaDTO, ModelState);

        VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);

        //var villaNumberPatch = await _villaNumberRepository.GetAsync(c => c.VillaNo == villaNo);
        //villaNumberPatch.VillaNo = villaDTO.VillaNo;
        //villaNumberPatch.UpdatedDate = DateTime.Now;
        //villaNumberPatch.SpecialDetails = villaDTO.SpecialDetails;

        if (await _villaRepository.GetAsync(u => u.Id == villaDTO.VillaId) == null)
        {
            ModelState.AddModelError("CustomError", "Villa ID is Invalid!");
            return BadRequest(ModelState);
        }

        await _villaNumberRepository.UpdateAsync(model);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return NoContent();
    }
    
}
