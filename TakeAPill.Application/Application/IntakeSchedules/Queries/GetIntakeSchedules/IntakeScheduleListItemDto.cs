namespace TakeAPill.Application.IntakeSchedules.Queries.GetIntakeSchedules;

public sealed record IntakeScheduleListItemDto(
    int Id,
    int PillId,
    string PillName,
    string IntakeFrequency,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate);
