//<snippet14>
using System;

public class EmployeeListNotFoundException : Exception
{
    public EmployeeListNotFoundException()
    {
    }

    public EmployeeListNotFoundException(string message)
        : base(message)
    {
    }

    public EmployeeListNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
//</snippet14>

public class TestExample
{
    public static void Main()
    {
        EmployeeListNotFoundException e1, e2, e3;
        Exception ex = new Exception();

        e1 = new EmployeeListNotFoundException();
        e2 = new EmployeeListNotFoundException("Hi!");
        e3 = new EmployeeListNotFoundException("Hi!", ex);
    }
}
