using Microsoft.EntityFrameworkCore;
using TakeAPill.Application.IntakeSchedules.Queries.GetIntakeSchedules;
using TakeAPill.Infrastructure.Data;

namespace TakeAPill.Infrastructure.IntakeSchedules.Queries.GetIntakeSchedules;

public sealed class IntakeScheduleReadStore(ApplicationDbContext dbContext) : IIntakeScheduleReadStore
{
    public async Task<IReadOnlyList<IntakeScheduleListItemDto>> ListAsync(
        string userId,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userId);

        return await dbContext.IntakeSchedules
            .AsNoTracking()
            .Where(schedule => schedule.UserId == userId)
            .OrderBy(schedule => schedule.StartDate)
            .Select(schedule => new IntakeScheduleListItemDto(
                schedule.Id,
                schedule.PillId,
                schedule.Pill.Name,
                schedule.IntakeFrequency,
                schedule.StartDate,
                schedule.EndDate))
            .ToListAsync(cancellationToken);
    }
}

