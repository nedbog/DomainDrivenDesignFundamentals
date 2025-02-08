namespace SharedKernel;

public class DateTimeOffsetRange : ValueObject
{
    public DateTimeOffset Start { get; private set; }
    public DateTimeOffset End { get; private set; }

    public DateTimeOffsetRange(DateTimeOffset start, DateTimeOffset end)
    {
        Start = start;
        End = end;
    }

    public DateTimeOffsetRange(DateTimeOffset start, TimeSpan duration) : this(start, start.Add(duration))
    {
    }

    public int DurationInMinutes => (int)Math.Round((End - Start).TotalMinutes, 0);

    public DateTimeOffsetRange NewDuration(TimeSpan newDuration) => new(Start, newDuration);

    public DateTimeOffsetRange NewStart(DateTimeOffset newStart) => new(newStart, End);

    public DateTimeOffsetRange NewEnd(DateTimeOffset newEnd) => new(Start, newEnd);

    public bool Overlaps(DateTimeOffsetRange other) => Start < other.End && other.Start < End;

    public static DateTimeOffsetRange CreateOneDayRange(DateTimeOffset day) => new(day, day.AddDays(1));

    public static DateTimeOffsetRange CreateOneWeekRange(DateTimeOffset day) => new(day, day.AddDays(7));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
