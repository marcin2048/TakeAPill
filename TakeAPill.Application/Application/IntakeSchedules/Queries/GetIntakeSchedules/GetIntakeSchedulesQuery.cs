using MediatR;

namespace TakeAPill.Application.IntakeSchedules.Queries.GetIntakeSchedules;

public sealed record GetIntakeSchedulesQuery(string UserId)
    : IRequest<IReadOnlyList<IntakeScheduleListItemDto>>;
