// <Snippet2>
using System;

public class MissingEx1
{
    public static void Main()
    {
        Person p = new Person("John", "Doe");
        Console.WriteLine(p);
    }
}

public class Person
{
    static readonly InfoModule s_infoModule;

    readonly string _fName;
    readonly string _lName;

    static Person()
    {
        s_infoModule = new InfoModule(DateTime.UtcNow);
    }

    public Person(string fName, string lName)
    {
        _fName = fName;
        _lName = lName;
        s_infoModule.Increment();
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", _fName, _lName);
    }
}
// The example displays the following output if missing1a.dll is renamed or removed:
//    Unhandled Exception: System.TypeInitializationException: 
//       The type initializer for 'Person' threw an exception. ---> 
//       System.IO.FileNotFoundException: Could not load file or assembly 
//       'Missing1a, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' 
//       or one of its dependencies. The system cannot find the file specified.
//       at Person..cctor()
//       --- End of inner exception stack trace ---
//       at Person..ctor(String fName, String lName)
//       at Example.Main()
// </Snippet2>
