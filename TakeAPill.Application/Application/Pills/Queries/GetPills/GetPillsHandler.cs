using MediatR;

namespace TakeAPill.Application.Pills.Queries.GetPills;

public sealed class GetPillsHandler(IPillReadStore readStore)
    : IRequestHandler<GetPillsQuery, IReadOnlyList<PillListItemDto>>
{
    public Task<IReadOnlyList<PillListItemDto>> Handle(
        GetPillsQuery query,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);
        return readStore.ListAsync(cancellationToken);
    }
}
