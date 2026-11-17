using TakeAPill.Domain.IntakeSchedules;

namespace TakeAPill.Domain.Pills;

public sealed class Pill
{
    private Pill()
    {
    }

    public Pill(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Pill name is required.", nameof(name));
        }

        Name = name.Trim();
    }

    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public ICollection<IntakeSchedule> IntakeSchedules { get; private set; } = [];
}
