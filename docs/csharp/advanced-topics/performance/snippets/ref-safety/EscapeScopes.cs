namespace RefSafety;

public class EscapeScopes
{
    // <SafeToEscapeScope>
    private string longMessage = "This is a long message";

    public ReadOnlySpan<char> Safe()
    {
        var span = longMessage.AsSpan();
        return span;
    }
    // </SafeToEscapeScope>

    // <RefSafeToEscapeScopes>
    private int anIndex;

    public ref int RetrieveIndexRef()
    {
        return ref anIndex;
    }

    public ref int RefMin(ref int left, ref int right)
    {
        if (left < right)
            return ref left;
        else
            return ref right;
    }
    // </RefSafeToEscapeScopes>
}