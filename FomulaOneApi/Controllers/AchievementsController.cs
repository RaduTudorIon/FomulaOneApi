using AutoMapper;
using FomulaOneApi.Controllers;
using FormulaOne.DataService.Repositories.Interfaces;

namespace FomulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}
