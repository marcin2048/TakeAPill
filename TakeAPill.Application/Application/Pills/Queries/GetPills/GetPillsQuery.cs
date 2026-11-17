using MediatR;

namespace TakeAPill.Application.Pills.Queries.GetPills;

public sealed record GetPillsQuery : IRequest<IReadOnlyList<PillListItemDto>>;
