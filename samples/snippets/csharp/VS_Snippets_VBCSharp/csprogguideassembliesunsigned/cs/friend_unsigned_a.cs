//<Snippet1>
// friend_unsigned_A.cs
// Compile with: 
// csc /target:library friend_unsigned_A.cs
using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("friend_unsigned_B")]

// Type is internal by default.
class Class1
{
    public void Test()
    {
        Console.WriteLine("Class1.Test");
    }
}

// Public type with internal member.
public class Class2
{
    internal void Test()
    {
        Console.WriteLine("Class2.Test");
    }
}
//</Snippet1>