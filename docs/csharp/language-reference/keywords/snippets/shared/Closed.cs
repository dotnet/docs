namespace LanguageKeywords.ClosedHierarchies;

// Setup types reused by the snippets in this file.
public closed record class GateState;
public record class Closed : GateState;
public record class Open(float Percent) : GateState;

//<GenericRule>
public closed class C<T> { }

public class D1<U> : C<U> { }    // OK: 'U' appears in the base class
public class D2<V> : C<V[]> { }  // OK: 'V' appears in the base class
// public class D3<W> : C<int> { } // Error: 'W' isn't used in the base class
//</GenericRule>

public static class ClosedSwitchExamples
{
    //<ExhaustiveSwitch>
    public static string Describe(GateState state) => state switch
    {
        Closed => "closed",
        Open(var percent) => $"{percent}% open",
        // No warning: every direct descendant of 'GateState' is handled.
    };
    //</ExhaustiveSwitch>

    //<NullableSwitch>
    public static string DescribeOrUnknown(GateState? state) => state switch
    {
        null => "unknown",
        Closed => "closed",
        Open(var percent) => $"{percent}% open",
        // No warning: every direct descendant of 'GateState' is handled, and null is handled.
    };
    //</NullableSwitch>
}
