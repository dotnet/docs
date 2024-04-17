namespace TourOfCsharp;
public class PatternMatching
{
    // <PatternExamples>
    public static bool Or(bool left, bool right) =>
        (left, right) switch
        {
            (true, true) => true,
            (true, false) => true,
            (false, true) => true,
            (false, false) => false,
        };

    public static bool And(bool left, bool right) =>
        (left, right) switch
        {
            (true, true) => true,
            (true, false) => false,
            (false, true) => false,
            (false, false) => false,
        };
    public static bool Xor(bool left, bool right) =>
        (left, right) switch
        {
            (true, true) => false,
            (true, false) => true,
            (false, true) => true,
            (false, false) => false,
        };
    // </PatternExamples>

    // <ReducedPattern>
    public static bool ReducedAnd(bool left, bool right) =>
        (left, right) switch
        {
            (true, true) => true,
            (_, _) => false,
        };
    // </ReducedPattern>
}
