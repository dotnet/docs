//<Snippet1>
using System;
using System.Reflection;

// The base class B contains an overloaded method M.
//
public class B
{
    public virtual void M()
    {
        Console.WriteLine("B's M()");
    }
    public virtual void M(int x)
    {
        Console.WriteLine("B's M({0})", x);
    }
}

// The derived class D hides one overload of the inherited 
// method M.
//
public class D:
    B
{
    new public void M(int i)
    {
        Console.WriteLine("D's M({0})", i);
    }
}

public class Test
{
    public static void Main()
    {
        D dinst = new D();
        // In C#, the method in the derived class hides by name and by
        // signature, so the overload in the derived class hides only one
        // of the overloads in the base class.
        //
        Console.WriteLine("------ List the overloads of M in the derived class D ------");
        Type t = dinst.GetType();
        foreach( MethodInfo minfo in t.GetMethods() )
        {
            if (minfo.Name=="M") {Console.WriteLine("Overload of M: {0}  IsHideBySig = {1}, DeclaringType = {2}", minfo, minfo.IsHideBySig, minfo.DeclaringType);}
        }

        // The method M in the derived class hides one overload of the 
        // method in B.  Contrast this with Visual Basic, which hides by
        // name instead of by name and signature.  In Visual Basic, the
        // parameterless overload of M would be unavailable from D.
        //
        Console.WriteLine("------ Call the overloads of M available in D ------");
        dinst.M();
        dinst.M(42);
        
        // If D is cast to the base type B, both overloads of the 
        // shadowed method can be called.
        //
        Console.WriteLine("------ Call the shadowed overloads of M ------");
        B binst = dinst;
        binst.M();
        binst.M(42);
    } //Main
} //Test

/* This code example produces the following output:

------ List the overloads of M in the derived class D ------
Overload of M: Void M(Int32)  IsHideBySig = True, DeclaringType = B
Overload of M: Void M()  IsHideBySig = True, DeclaringType = B
Overload of M: Void M(Int32)  IsHideBySig = True, DeclaringType = D
------ Call the overloads of M available in D ------
B's M()
D's M(42)
------ Call the shadowed overloads of M ------
B's M()
B's M(42)
*/

//</Snippet1>

