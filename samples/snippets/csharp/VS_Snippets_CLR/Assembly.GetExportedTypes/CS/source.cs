//<Snippet1>
using System;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        foreach (Type t in typeof(Example).Assembly.GetExportedTypes())
        {
            Console.WriteLine(t);
        }
    }
}

public class PublicClass
{
    public class PublicNestedClass {}

    protected class ProtectedNestedClass {}
 
    internal class FriendNestedClass {}

    private class PrivateNestedClass {}
}

internal class FriendClass
{
    public class PublicNestedClass {}

    protected class ProtectedNestedClass {}

    internal class FriendNestedClass {}

    private class PrivateNestedClass {}
}
//</Snippet1>
