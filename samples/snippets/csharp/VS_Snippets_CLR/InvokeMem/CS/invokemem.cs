// <Snippet1>
using System;
using System.Reflection;

// This sample class has a field, constructor, method, and property.
class MyType 
{
    Int32 myField;
    public MyType(ref Int32 x) {x *= 5;}
    public override String ToString() {return myField.ToString();}
    public Int32 MyProp 
    {
        get {return myField;}
        set 
        { 
            if (value < 1) 
                throw new ArgumentOutOfRangeException("value", value, "value must be > 0");
            myField = value;
        }
    }
}

class MyApp 
{
    static void Main() 
    {
        Type t = typeof(MyType);
        // Create an instance of a type.
        Object[] args = new Object[] {8};
        Console.WriteLine("The value of x before the constructor is called is {0}.", args[0]);
        Object obj = t.InvokeMember(null, 
            BindingFlags.DeclaredOnly | 
            BindingFlags.Public | BindingFlags.NonPublic | 
            BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);
        Console.WriteLine("Type: " + obj.GetType().ToString());
        Console.WriteLine("The value of x after the constructor returns is {0}.", args[0]);

        // Read and write to a field.
        t.InvokeMember("myField", 
            BindingFlags.DeclaredOnly | 
            BindingFlags.Public | BindingFlags.NonPublic | 
            BindingFlags.Instance | BindingFlags.SetField, null, obj, new Object[] {5});
        Int32 v = (Int32) t.InvokeMember("myField", 
            BindingFlags.DeclaredOnly | 
            BindingFlags.Public | BindingFlags.NonPublic | 
            BindingFlags.Instance | BindingFlags.GetField, null, obj, null);
        Console.WriteLine("myField: " + v);

        // Call a method.
        String s = (String) t.InvokeMember("ToString", 
            BindingFlags.DeclaredOnly | 
            BindingFlags.Public | BindingFlags.NonPublic | 
            BindingFlags.Instance | BindingFlags.InvokeMethod, null, obj, null);
        Console.WriteLine("ToString: " + s);

        // Read and write a property. First, attempt to assign an
        // invalid value; then assign a valid value; finally, get
        // the value.
        try 
        {
            // Assign the value zero to MyProp. The Property Set 
            // throws an exception, because zero is an invalid value.
            // InvokeMember catches the exception, and throws 
            // TargetInvocationException. To discover the real cause
            // you must catch TargetInvocationException and examine
            // the inner exception. 
            t.InvokeMember("MyProp", 
                BindingFlags.DeclaredOnly | 
                BindingFlags.Public | BindingFlags.NonPublic | 
                BindingFlags.Instance | BindingFlags.SetProperty, null, obj, new Object[] {0});
        } 
        catch (TargetInvocationException e) 
        {
            // If the property assignment failed for some unexpected
            // reason, rethrow the TargetInvocationException.
            if (e.InnerException.GetType() != 
                typeof(ArgumentOutOfRangeException)) 
                throw;
            Console.WriteLine("An invalid value was assigned to MyProp.");
        }
        t.InvokeMember("MyProp", 
            BindingFlags.DeclaredOnly | 
            BindingFlags.Public | BindingFlags.NonPublic | 
            BindingFlags.Instance | BindingFlags.SetProperty, null, obj, new Object[] {2});
        v = (Int32) t.InvokeMember("MyProp", 
            BindingFlags.DeclaredOnly | 
            BindingFlags.Public | BindingFlags.NonPublic | 
            BindingFlags.Instance | BindingFlags.GetProperty, null, obj, null);
        Console.WriteLine("MyProp: " + v);
    }
}
// </Snippet1>