using AutoMapper;
using FomulaOneApi.Controllers;
using FormulaOne.DataService.Repositories.Interfaces;

namespace FomulaOne.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}
