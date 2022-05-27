using System.Diagnostics.CodeAnalysis;

namespace null_warnings
{
    class NullTests
    {
        // <PrivateNullTest>
        public void WriteMessage(string? message)
        {
            if (IsNotNull(message))
                Console.WriteLine(message.Length);
        }
        // </PrivateNullTest>

        // <AnnotatedNullCheck>
        private static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
        // </AnnotatedNullCheck>

        // <ViolateAttribute>
        public bool TryGetMessage(int id, [NotNullWhen(true)] out string? message)
        {
            message = null;
            return true;

        }
        // </ViolateAttribute>

    }
}
