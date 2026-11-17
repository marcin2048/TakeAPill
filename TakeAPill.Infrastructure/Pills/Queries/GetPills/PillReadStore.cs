using Microsoft.EntityFrameworkCore;
using TakeAPill.Application.Pills.Queries.GetPills;
using TakeAPill.Infrastructure.Data;

namespace TakeAPill.Infrastructure.Pills.Queries.GetPills;

public sealed class PillReadStore(ApplicationDbContext dbContext) : IPillReadStore
{
    public async Task<IReadOnlyList<PillListItemDto>> ListAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext.Pills
            .AsNoTracking()
            .OrderBy(pill => pill.Name)
            .Select(pill => new PillListItemDto(
                pill.Id,
                pill.Name))
            .ToListAsync(cancellationToken);
    }
}
