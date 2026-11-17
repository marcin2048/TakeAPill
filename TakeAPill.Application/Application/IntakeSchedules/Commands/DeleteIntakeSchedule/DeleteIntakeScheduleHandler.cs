using MediatR;

namespace TakeAPill.Application.IntakeSchedules.Commands.DeleteIntakeSchedule;

public sealed class DeleteIntakeScheduleHandler(IDeleteIntakeScheduleStore store)
    : IRequestHandler<DeleteIntakeScheduleCommand>
{
    public Task Handle(
        DeleteIntakeScheduleCommand command,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        return store.DeleteAsync(command, cancellationToken);
    }
}
