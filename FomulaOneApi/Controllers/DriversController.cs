using AutoMapper;
using FomulaOneApi.Controllers;
using FomulaOneApi.Entities;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FomulaOne.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);
        if (driver == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<GetDriverResponse>(driver);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _mapper.Map<Driver>(driver);
        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var drivers = await _unitOfWork.Drivers.All();

        var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);
        if (driver == null)
        {
            return NotFound();
        }

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
