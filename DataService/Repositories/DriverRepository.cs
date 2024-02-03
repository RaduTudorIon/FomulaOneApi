using DataService;
using FomulaOneApi.Entities;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;
public class DriverRepository: GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(AppDbContext context,ILogger logger) : base(context, logger)
    {}

    public override async Task<IEnumerable<Driver>> All()
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
            logger.LogError(ex, "Error in DriverRepository.All()");
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var driver = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null)
            {
                return false;
            }
            driver.Status = 0;
            driver.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in DriverRepository.Delete()");
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try
        {
            var result = await dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);
            if (result == null)
            {
                return false;
            }

            result.UpdatedDate = DateTime.UtcNow;
            result.DriversNumber = driver.DriversNumber;
            result.FirstName = driver.FirstName;
            result.LastName = driver.LastName;
            result.DateOfBirth = driver.DateOfBirth;

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in DriverRepository.Update()");
            throw;
        }
    }
}
