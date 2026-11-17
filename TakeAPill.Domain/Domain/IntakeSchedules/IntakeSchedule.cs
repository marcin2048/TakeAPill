using TakeAPill.Domain.Pills;

namespace TakeAPill.Domain.IntakeSchedules;

public sealed class IntakeSchedule
{
    private IntakeSchedule()
    {
    }

    public IntakeSchedule(
        string userId,
        int pillId,
        string intakeFrequency,
        DateTimeOffset startDate,
        DateTimeOffset? endDate = null)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException("User ID is required.", nameof(userId));
        }

        if (pillId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pillId));
        }

        if (string.IsNullOrWhiteSpace(intakeFrequency))
        {
            throw new ArgumentException("Intake frequency is required.", nameof(intakeFrequency));
        }

        if (endDate.HasValue && endDate < startDate)
        {
            throw new ArgumentException("End date cannot be earlier than start date.", nameof(endDate));
        }

        UserId = userId;
        PillId = pillId;
        IntakeFrequency = intakeFrequency.Trim();
        StartDate = startDate;
        EndDate = endDate;
    }

    public int Id { get; private set; }

    public string UserId { get; private set; } = string.Empty;

    public int PillId { get; private set; }

    public string IntakeFrequency { get; private set; } = string.Empty;

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset? EndDate { get; private set; }

    public Pill Pill { get; private set; } = null!;
}
