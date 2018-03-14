// REDMOND\glennha
// Showing all the things D(A) can bind to.
//
//<Snippet1>
using System;
using System.Reflection;
using System.Security.Permissions;

// Declare a delegate type. The object of this code example
// is to show all the methods this delegate can bind to.
//
public delegate void D(C c);

// Declare two sample classes, C and F. Class C has an ID
// property so instances can be identified.
//
public class C
{
    private int id;
    public int ID { get { return id; }}
    public C(int id) { this.id = id; }

    public void M1(C c) 
    { 
        Console.WriteLine("Instance method M1(C c) on C:  this.id = {0}, c.ID = {1}",
            this.id, c.ID);
    }
  
    public void M2() 
    { 
        Console.WriteLine("Instance method M2() on C:  this.id = {0}",
            this.id);
    }
  
    public static void M3(C c)
    { 
        Console.WriteLine("Static method M3(C c) on C:  c.ID = {0}", c.ID); 
    }

    public static void M4(C c1, C c2) 
    { 
        Console.WriteLine("Static method M4(C c1, C c2) on C:  c1.ID = {0}, c2.ID = {1}",
            c1.ID, c2.ID);
    }
}

public class F
{
    public void M1(C c) 
    { 
        Console.WriteLine("Instance method M1(C c) on F:  c.ID = {0}",
            c.ID);
    }
  
    public static void M3(C c)
    { 
        Console.WriteLine("Static method M3(C c) on F:  c.ID = {0}", c.ID); 
    }

    public static void M4(F f, C c) 
    { 
        Console.WriteLine("Static method M4(F f, C c) on F:  c.ID = {0}",
            c.ID);
    }
}


public class Example
{
    public static void Main()
    {
        C c1 = new C(42);
        C c2 = new C(1491);
        F f1 = new F();

        D d;

        // Instance method with one argument of type C.
        MethodInfo cmi1 = typeof(C).GetMethod("M1"); 
        // Instance method with no arguments.
        MethodInfo cmi2 = typeof(C).GetMethod("M2"); 
        // Static method with one argument of type C.
        MethodInfo cmi3 = typeof(C).GetMethod("M3"); 
        // Static method with two arguments of type C.
        MethodInfo cmi4 = typeof(C).GetMethod("M4"); 

        // Instance method with one argument of type C.
        MethodInfo fmi1 = typeof(F).GetMethod("M1");
        // Static method with one argument of type C.
        MethodInfo fmi3 = typeof(F).GetMethod("M3"); 
        // Static method with an argument of type F and an argument 
        // of type C.
        MethodInfo fmi4 = typeof(F).GetMethod("M4"); 

        Console.WriteLine("\nAn instance method on any type, with an argument of type C.");
        // D can represent any instance method that exactly matches its
        // signature. Methods on C and F are shown here.
        //
        d = (D) Delegate.CreateDelegate(typeof(D), c1, cmi1);
        d(c2);
        d = (D) Delegate.CreateDelegate(typeof(D), f1, fmi1);
        d(c2);

        Console.WriteLine("\nAn instance method on C with no arguments.");
        // D can represent an instance method on C that has no arguments;
        // in this case, the argument of D represents the hidden first
        // argument of any instance method. The delegate acts like a 
        // static method, and an instance of C must be passed each time
        // it is invoked.
        //
        d = (D) Delegate.CreateDelegate(typeof(D), null, cmi2);
        d(c1);

        Console.WriteLine("\nA static method on any type, with an argument of type C.");
        // D can represent any static method with the same signature.
        // Methods on F and C are shown here.
        //
        d = (D) Delegate.CreateDelegate(typeof(D), null, cmi3);
        d(c1);
        d = (D) Delegate.CreateDelegate(typeof(D), null, fmi3);
        d(c1);

        Console.WriteLine("\nA static method on any type, with an argument of");
        Console.WriteLine("    that type and an argument of type C.");
        // D can represent any static method with one argument of the
        // type the method belongs and a second argument of type C.
        // In this case, the method is closed over the instance of
        // supplied for the its first argument, and acts like an instance
        // method. Methods on F and C are shown here.
        //
        d = (D) Delegate.CreateDelegate(typeof(D), c1, cmi4);
        d(c2);
        Delegate test = 
            Delegate.CreateDelegate(typeof(D), f1, fmi4, false);

        // This final example specifies false for throwOnBindFailure 
        // in the call to CreateDelegate, so the variable 'test'
        // contains Nothing if the method fails to bind (for 
        // example, if fmi4 happened to represent a method of  
        // some class other than F).
        //
        if (test != null)
        {
            d = (D) test;
            d(c2);
        }
    }
}

/* This code example produces the following output:

An instance method on any type, with an argument of type C.
Instance method M1(C c) on C:  this.id = 42, c.ID = 1491
Instance method M1(C c) on F:  c.ID = 1491

An instance method on C with no arguments.
Instance method M2() on C:  this.id = 42

A static method on any type, with an argument of type C.
Static method M3(C c) on C:  c.ID = 42
Static method M3(C c) on F:  c.ID = 42

A static method on any type, with an argument of
    that type and an argument of type C.
Static method M4(C c1, C c2) on C:  c1.ID = 42, c2.ID = 1491
Static method M4(F f, C c) on F:  c.ID = 1491
*/
//</Snippet1>
