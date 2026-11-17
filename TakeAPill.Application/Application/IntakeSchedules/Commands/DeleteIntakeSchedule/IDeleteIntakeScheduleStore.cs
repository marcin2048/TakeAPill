namespace TakeAPill.Application.IntakeSchedules.Commands.DeleteIntakeSchedule;

public interface IDeleteIntakeScheduleStore
{
    Task DeleteAsync(
        DeleteIntakeScheduleCommand command,
        CancellationToken cancellationToken);
}
