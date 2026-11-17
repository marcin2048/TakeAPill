using MediatR;

namespace TakeAPill.Application.IntakeSchedules.Queries.GetIntakeSchedules;

public sealed class GetIntakeSchedulesHandler(IIntakeScheduleReadStore readStore)
    : IRequestHandler<GetIntakeSchedulesQuery, IReadOnlyList<IntakeScheduleListItemDto>>
{
    public Task<IReadOnlyList<IntakeScheduleListItemDto>> Handle(
        GetIntakeSchedulesQuery query,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);
        return readStore.ListAsync(query.UserId, cancellationToken);
    }
}
