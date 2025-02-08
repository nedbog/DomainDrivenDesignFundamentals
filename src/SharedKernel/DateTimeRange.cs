using Ardalis.GuardClauses;

namespace SharedKernel;

public class DateTimeRange : ValueObject
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public DateTimeRange(DateTime start, DateTime end)
    {
        Guard.Against.OutOfRange(start, nameof(start), start, end);
        Start = start;
        End = end;
    }

    public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
    {
    }

    public int DurationInMinutes => (int)Math.Round((End - Start).TotalMinutes, 0);

    public DateTimeRange NewDuration(TimeSpan newDuration) => new(Start, newDuration);

    public DateTimeRange NewStart(DateTime newStart) => new(newStart, End);

    public DateTimeRange NewEnd(DateTime newEnd) => new(Start, newEnd);

    public bool Overlaps(DateTimeRange other) => Start < other.End && other.Start < End;

    public static DateTimeRange CreateOneDayRange(DateTime day) => new(day, day.AddDays(1));

    public static DateTimeRange CreateOneWeekRange(DateTime day) => new(day, day.AddDays(7));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
