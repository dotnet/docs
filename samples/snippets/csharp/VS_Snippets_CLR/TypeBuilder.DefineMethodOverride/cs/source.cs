//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

public interface I 
{
    void M();
}

public class A 
{
    public virtual void M() { Console.WriteLine("In method A.M"); }
}

// The object of this code example is to emit code equivalent to
// the following C# code:
//
public class C : A, I 
{
    public override void M() 
    { 
        Console.WriteLine("Overriding A.M from C.M"); 
    }

    // In order to provide a different implementation from C.M when 
    // emitting the following explicit interface implementation, 
    // it is necessary to use a MethodImpl.
    //
    void I.M() 
    {
        Console.WriteLine("The I.M implementation of C"); 
    }
}

class Test 
{
    static void Main() 
    {
        string name = "DefineMethodOverrideExample";
        AssemblyName asmName = new AssemblyName(name);
        AssemblyBuilder ab = 
            AppDomain.CurrentDomain.DefineDynamicAssembly(
                asmName, AssemblyBuilderAccess.RunAndSave);
        ModuleBuilder mb = ab.DefineDynamicModule(name, name + ".dll");

        TypeBuilder tb = 
            mb.DefineType("C", TypeAttributes.Public, typeof(A));
        tb.AddInterfaceImplementation(typeof(I));

        // Build the method body for the explicit interface 
        // implementation. The name used for the method body 
        // can be anything. Here, it is the name of the method,
        // qualified by the interface name.
        //
        MethodBuilder mbIM = tb.DefineMethod("I.M", 
            MethodAttributes.Private | MethodAttributes.HideBySig |
                MethodAttributes.NewSlot | MethodAttributes.Virtual | 
                MethodAttributes.Final,
            null,
            Type.EmptyTypes);
        ILGenerator il = mbIM.GetILGenerator();
        il.Emit(OpCodes.Ldstr, "The I.M implementation of C");
        il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", 
            new Type[] { typeof(string) }));
        il.Emit(OpCodes.Ret);

        // DefineMethodOverride is used to associate the method 
        // body with the interface method that is being implemented.
        //
        tb.DefineMethodOverride(mbIM, typeof(I).GetMethod("M"));

        MethodBuilder mbM = tb.DefineMethod("M", 
            MethodAttributes.Public | MethodAttributes.ReuseSlot | 
                MethodAttributes.Virtual | MethodAttributes.HideBySig, 
            null, 
            Type.EmptyTypes);
        il = mbM.GetILGenerator();
        il.Emit(OpCodes.Ldstr, "Overriding A.M from C.M");
        il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", 
            new Type[] { typeof(string) }));
        il.Emit(OpCodes.Ret);

        Type tc = tb.CreateType();

        // Save the emitted assembly, to examine with Ildasm.exe.
        ab.Save(name + ".dll");

        Object test = Activator.CreateInstance(tc);

        MethodInfo mi = typeof(I).GetMethod("M");
        mi.Invoke(test, null);

        mi = typeof(A).GetMethod("M");
        mi.Invoke(test, null);
    }
}

/* This code example produces the following output:

The I.M implementation of C
Overriding A.M from C.M
 */
//</Snippet1>
