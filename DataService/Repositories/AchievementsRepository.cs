using DataService;
using FomulaOneApi.Entities;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;
public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
{
    public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
    { }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Error in AchievementsRepository.GetDriverAchievementAsync()");
            throw;
        }
    }


    public override async Task<IEnumerable<Achievement>> All()
    {
        try
        {
            return await dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in AchievementsRepository.All()");
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var achievement = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (achievement == null)
            {
                return false;
            }
            achievement.Status = 0;
            achievement.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in AchievementsRepository.Delete()");
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            var result = await dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
            if (result == null)
            {
                return false;
            }

            result.UpdatedDate = DateTime.UtcNow;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionship = achievement.WorldChampionship;
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in AchievementsRepository.Update()");
            throw;
        }
    }
}
