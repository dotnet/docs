using System;
using System.Runtime.InteropServices;

public class InteropCharSet
{
    // <Snippet1>
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct MyPerson
    {
        public String first;
        public String last;
    }
    // </Snippet1>

    public static void Main()
    {
        MyPerson aperson;

        aperson.first = "FirstName";
        aperson.last = "LastName";
    }
}