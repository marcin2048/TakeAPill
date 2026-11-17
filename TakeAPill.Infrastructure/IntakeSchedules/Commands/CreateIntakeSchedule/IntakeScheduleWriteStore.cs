using Microsoft.EntityFrameworkCore;
using TakeAPill.Application.IntakeSchedules.Commands.CreateIntakeSchedule;
using TakeAPill.Infrastructure.Data;
using TakeAPill.Domain.IntakeSchedules;

namespace TakeAPill.Infrastructure.IntakeSchedules.Commands.CreateIntakeSchedule;

public sealed class IntakeScheduleWriteStore(ApplicationDbContext dbContext) : ICreateIntakeScheduleStore
{
    public async Task<int> CreateAsync(
        CreateIntakeScheduleCommand command,
        CancellationToken cancellationToken)
    {
        var pillExists = await dbContext.Pills
            .AnyAsync(pill => pill.Id == command.PillId, cancellationToken);

        if (!pillExists)
        {
            throw new InvalidOperationException($"Pill with id {command.PillId} was not found.");
        }

        var schedule = new IntakeSchedule(
            command.UserId,
            command.PillId,
            command.IntakeFrequency,
            command.StartDate,
            command.EndDate);

        dbContext.IntakeSchedules.Add(schedule);
        await dbContext.SaveChangesAsync(cancellationToken);

        return schedule.Id;
    }
}

