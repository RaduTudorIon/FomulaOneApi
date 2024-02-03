using FomulaOneApi.Entities;

namespace FormulaOne.DataService.Repositories.Interfaces;
public interface IAchievementsRepository: IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievementAsync(Guid driverId);
}