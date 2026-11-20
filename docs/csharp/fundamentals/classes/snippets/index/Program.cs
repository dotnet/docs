// <IndependentInstances>
Console.WriteLine(VisitCounter.GetTotal()); // => 0
var first = new VisitCounter();
var second = new VisitCounter();

first.AddVisit();
Console.WriteLine(first.GetCount()); // => 1
Console.WriteLine(second.GetCount()); // => 0
Console.WriteLine(VisitCounter.GetTotal()); // => 1

second.AddVisit();
second.AddVisit();
Console.WriteLine(first.GetCount()); // => 1
Console.WriteLine(second.GetCount()); // => 2
Console.WriteLine(VisitCounter.GetTotal()); // => 3
// </IndependentInstances>

Console.WriteLine(VisitCounter.GetTotalExcluding(first)); // => 2

// <ReferenceAssignment>
var alias = first;
alias.AddVisit();
Console.WriteLine(first.GetCount()); // => 2
Console.WriteLine(ReferenceEquals(first, alias)); // => True
Console.WriteLine(first == second); // => False
// </ReferenceAssignment>

// <PublicAccess>
var counter = new VisitCounter();
counter.AddVisit();
Console.WriteLine(counter.GetCount()); // => 1
// </PublicAccess>

#if INACCESSIBLE
counter.count = 10;
#endif

// <StaticClass>
Console.WriteLine(Math.Abs(-5)); // => 5
// </StaticClass>

// <UseConstants>
Console.WriteLine(TimeUnits.SecondsPerMinute); // => 60
Console.WriteLine(TimeUnits.SecondsPerHour); // => 3600
// </UseConstants>

var notebook = new Notebook();
notebook.Write("Try a new route.");
Console.WriteLine(notebook.Read()); // => Try a new route.
Console.WriteLine(new Reminder().GetText()); // => Take a break
Console.WriteLine(new LocalCounter().GetCount()); // => 0
_ = new Session().GetStartTime();
Console.WriteLine(ReminderSettings.Interval.TotalMinutes); // => 15

// <CounterDeclaration>
public class VisitCounter
{
    private int count;
    private static int total;

    public void AddVisit()
    {
        count++;
        total++;
    }

    public int GetCount() => count;

    public static int GetTotal() => total;

    // <StaticMemberWithInstance>
    public static int GetTotalExcluding(VisitCounter counter) =>
        total - counter.count;
    // </StaticMemberWithInstance>
}
// </CounterDeclaration>

// <NestedType>
public class Notebook
{
    private class Entry
    {
        public string Text = "";
    }

    private readonly Entry entry = new Entry();

    public void Write(string text) => entry.Text = text;

    public string Read() => entry.Text;
}
// </NestedType>

// <DefaultAccess>
class LocalCounter
{
    int count = 0;

    public int GetCount() => count;
}
// </DefaultAccess>

// <FieldInitializers>
public class Reminder
{
    private string text = "Take a break";

    public string GetText() => text;
}
// </FieldInitializers>

// <Constants>
public static class TimeUnits
{
    public const int SecondsPerMinute = 60;
    public const int SecondsPerHour = 60 * SecondsPerMinute;
}
// </Constants>

// <ReadonlyField>
public class Session
{
    private readonly DateTime startedAt = DateTime.UtcNow;

    public DateTime GetStartTime() => startedAt;
}
// </ReadonlyField>

// <RuntimeConstant>
public static class ReminderSettings
{
    public static readonly TimeSpan Interval = TimeSpan.FromMinutes(15);
}
// </RuntimeConstant>
