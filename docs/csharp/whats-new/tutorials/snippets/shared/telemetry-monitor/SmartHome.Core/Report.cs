namespace SmartHome.Core;

// <ClosedReport>
// A generic closed hierarchy. Every type parameter of a derived type must appear
// in the base type, so a single derived construction exhausts each Report<T>.
public closed record class Report<T>;
public sealed record class Single<T>(T Value) : Report<T>;
public sealed record class Group<T>(Report<T> Left, Report<T> Right) : Report<T>;
// </ClosedReport>

public static class ReportReporter
{
    // <ReportFold>
    public static int Count<T>(Report<T> report) => report switch
    {
        Single<T> => 1,
        Group<T> group => Count(group.Left) + Count(group.Right),
        // Exhaustive: Report<T> is closed and both subtypes are handled.
    };
    // </ReportFold>
}
