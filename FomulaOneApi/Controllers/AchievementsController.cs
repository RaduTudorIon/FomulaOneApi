using AutoMapper;
using FomulaOneApi.Controllers;
using FomulaOneApi.Entities;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FomulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var achievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
        if(achievements == null)
        {
            return NotFound("Achievement not found");
        }
        return Ok(_mapper.Map<DriverAchievementResponse>(achievements));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriverAchievement([FromBody] CreateDriverAchievementRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var achievement = _mapper.Map<Achievement>(request);
        if (achievement == null)
        {
            return NotFound("Achievement not found");
        }
        await _unitOfWork.Achievements.Add(achievement);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(CreateDriverAchievement), new { driverid = achievement.DriverId }, achievement);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriverAchievement([FromBody] UpdateDriverAchievementRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _mapper.Map<Achievement>(request);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
