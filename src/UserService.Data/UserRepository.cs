using Microsoft.EntityFrameworkCore;
using UserService.Data.Interfaces;
using UserService.Data.Provider;
using UserService.Models.Db;

namespace UserService.Data;

public class UserRepository(IDataProvider provider) : IUserRepository
{
    public async Task<Guid> CreateAsync(
        DbUser dbUser, CancellationToken cancellationToken)
    {
        await provider.Users.AddAsync(dbUser, cancellationToken);

        await provider.SaveAsync(cancellationToken);

        return dbUser.Id;
    }

    public async Task<bool> DeleteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var dbUser = await provider.Users
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (dbUser is null)
            return false;

        dbUser.IsActive = false;

        await provider.SaveAsync(cancellationToken);

        return true;
    }

    public async Task<DbUser?> GetAsync(
        Guid id, CancellationToken cancellationToken)
    {
        return await provider.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<List<DbUser>> GetUserIdsByTeamAsync(
        Guid teamId, CancellationToken cancellationToken)
    {
        return await provider.Users
            .AsNoTracking()
            .Include(u => u.Worker)
            .Where(u => u.Worker != null && u.Worker.TeamId == teamId)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(
        DbUser dbUser, CancellationToken cancellationToken)
    {
        await provider.SaveAsync(cancellationToken);

        return true;
    }
}
