namespace TakeAPill.Application.Pills.Queries.GetPills;

public interface IPillReadStore
{
    Task<IReadOnlyList<PillListItemDto>> ListAsync(
        CancellationToken cancellationToken);
}
