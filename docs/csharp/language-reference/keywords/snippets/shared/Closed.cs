namespace LanguageKeywords.ClosedHierarchies;

// Setup types reused by the snippets in this file.
public closed record class JobStatus;
public record class Queued : JobStatus;
public record class Running(int PercentComplete) : JobStatus;
public record class Completed(TimeSpan Elapsed) : JobStatus;
public record class Failed(string Error) : JobStatus;

//<GenericRule>
//</GenericRule>

public static class ClosedSwitchExamples
{
    //<ExhaustiveSwitch>
    public static string Describe(JobStatus status) => status switch
    {
        Queued => "waiting to start",
        Running(var percent) => $"{percent}% complete",
        Completed(var elapsed) => $"finished in {elapsed.TotalSeconds:F1}s",
        Failed(var error) => $"failed: {error}",
        // No warning: every direct descendant of 'JobStatus' is handled.
    };
    //</ExhaustiveSwitch>

    //<NullableSwitch>
    public static string DescribeOrUnknown(JobStatus? status) => status switch
    {
        null => "unknown",
        Queued => "waiting to start",
        Running(var percent) => $"{percent}% complete",
        Completed(var elapsed) => $"finished in {elapsed.TotalSeconds:F1}s",
        Failed(var error) => $"failed: {error}",
        // No warning: every direct descendant of 'JobStatus' is handled, and null is handled.
    };
    //</NullableSwitch>

    //<TypeParameterConstrained>
    public static string DescribeJob<X>(X status) where X : JobStatus => status switch
    {
        Queued => "waiting to start",
        Running(var percent) => $"{percent}% complete",
        Completed(var elapsed) => $"finished in {elapsed.TotalSeconds:F1}s",
        Failed(var error) => $"failed: {error}",
        // No warning: 'X' is constrained to a closed type, so its direct descendants exhaust the switch.
    };
    //</TypeParameterConstrained>
}
