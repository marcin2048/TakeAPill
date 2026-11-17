namespace TakeAPill.Application.IntakeSchedules.Commands.CreateIntakeSchedule;

public interface ICreateIntakeScheduleStore
{
    Task<int> CreateAsync(
        CreateIntakeScheduleCommand command,
        CancellationToken cancellationToken);
}
