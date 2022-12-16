namespace RefSafety;

public class EscapeScopes
{
    // <SafeToEscapeScope>
    public static int OuterMethod()
    {
        int n; // The safe to escape scope of n is the entire OuterMethod
        n = InnerMethod();
        return n; // n is safe to return
    }

    private static int InnerMethod()
    {
        int m = 5; // The safe to escape scope of m is the entire InnerMethod
        return m; // m is safe to return
    }
    // </SafeToEscapeScope>

    // <RefSafeToEscapeScopes>
    private int anIndex;

    public ref int RetrieveIndexRef()
    {
        return ref anIndex;
    }
    // </RefSafeToEscapeScopes>
}