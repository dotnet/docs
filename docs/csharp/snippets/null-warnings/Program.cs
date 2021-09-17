using System.Diagnostics.CodeAnalysis;

[return:NotNull]
string? TryGetMessage(int id) => "";

string msg = TryGetMessage(42);  // Possible null assignment.

msg = TryGetMessage(42) ?? "Unknown message id: 42";

class Test
{
    // <PrivateNullTest>
    public void WriteMessage(string? message)
    {
        if (IsNotNull(message))
            Console.WriteLine(message.Length);
    }
    // </PrivateNullTest>

    // <AnnotatedNullCheck>
    private static bool IsNotNull([NotNullWhen(true)]object? obj) => obj != null;
    // </AnnotatedNullCheck>

    // <ViolateAttribute>
    public bool TryGetMessage(int id, [NotNullWhen(true)]out string? message)
    {
        message = null;
        return true;

    }
    // </ViolateAttribute>

}
