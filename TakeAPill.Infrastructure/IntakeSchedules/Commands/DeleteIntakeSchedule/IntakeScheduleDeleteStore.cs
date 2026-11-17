using Microsoft.EntityFrameworkCore;
using TakeAPill.Application.IntakeSchedules.Commands.DeleteIntakeSchedule;
using TakeAPill.Infrastructure.Data;

namespace TakeAPill.Infrastructure.IntakeSchedules.Commands.DeleteIntakeSchedule;

public sealed class IntakeScheduleDeleteStore(ApplicationDbContext dbContext) : IDeleteIntakeScheduleStore
{
    public async Task DeleteAsync(
        DeleteIntakeScheduleCommand command,
        CancellationToken cancellationToken)
    {
        var schedule = await dbContext.IntakeSchedules
            .SingleOrDefaultAsync(item => item.Id == command.Id && item.UserId == command.UserId, cancellationToken);

        if (schedule is null)
        {
            return;
        }

        dbContext.IntakeSchedules.Remove(schedule);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
