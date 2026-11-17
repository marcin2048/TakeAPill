using MediatR;

namespace TakeAPill.Application.IntakeSchedules.Commands.CreateIntakeSchedule;

public sealed record CreateIntakeScheduleCommand(
    string UserId,
    int PillId,
    string IntakeFrequency,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate) : IRequest<int>;
