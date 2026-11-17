namespace TakeAPill.Application.IntakeSchedules.Queries.GetIntakeSchedules;

public interface IIntakeScheduleReadStore
{
    Task<IReadOnlyList<IntakeScheduleListItemDto>> ListAsync(
        string userId,
        CancellationToken cancellationToken);
}
