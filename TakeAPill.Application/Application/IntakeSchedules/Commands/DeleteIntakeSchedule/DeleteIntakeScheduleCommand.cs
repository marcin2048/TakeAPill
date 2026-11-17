using MediatR;

namespace TakeAPill.Application.IntakeSchedules.Commands.DeleteIntakeSchedule;

public sealed record DeleteIntakeScheduleCommand(string UserId, int Id) : IRequest;
