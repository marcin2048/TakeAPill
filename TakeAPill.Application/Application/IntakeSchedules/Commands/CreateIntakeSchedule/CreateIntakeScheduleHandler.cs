using MediatR;

namespace TakeAPill.Application.IntakeSchedules.Commands.CreateIntakeSchedule;

public sealed class CreateIntakeScheduleHandler(ICreateIntakeScheduleStore store)
    : IRequestHandler<CreateIntakeScheduleCommand, int>
{
    public Task<int> Handle(
        CreateIntakeScheduleCommand command,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        return store.CreateAsync(command, cancellationToken);
    }
}
