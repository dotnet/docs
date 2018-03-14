// REDMOND\glennha
//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

// These classes are for demonstration purposes.
//
public class Example
{
    private int id = 0;
    public Example(int id)
    {
        this.id = id;
    }
    public int ID { get { return id; }}
}

public class DerivedFromExample : Example
{
    public DerivedFromExample(int id) : base(id) {} 
}

// Two delegates are declared: UseLikeInstance treats the dynamic
// method as if it were an instance method, and UseLikeStatic
// treats the dynamic method in the ordinary fashion.
// 
public delegate int UseLikeInstance(int newID);
public delegate int UseLikeStatic(Example ex, int newID);

public class Demo
{
    public static void Main()
    {
        // This dynamic method changes the private id field. It has
        // no name; it returns the old id value (return type int);
        // it takes two parameters, an instance of Example and 
        // an int that is the new value of id; and it is declared 
        // with Example as the owner type, so it can access all 
        // members, public and private.
        //
        DynamicMethod changeID = new DynamicMethod(
            "",
            typeof(int),
            new Type[] { typeof(Example), typeof(int) },
            typeof(Example)
        );

        // Get a FieldInfo for the private field 'id'.
        FieldInfo fid = typeof(Example).GetField(
            "id",
            BindingFlags.NonPublic | BindingFlags.Instance
        );
    
        ILGenerator ilg = changeID.GetILGenerator();

        // Push the current value of the id field onto the 
        // evaluation stack. It's an instance field, so load the
        // instance of Example before accessing the field.
        ilg.Emit(OpCodes.Ldarg_0);
        ilg.Emit(OpCodes.Ldfld, fid);

        // Load the instance of Example again, load the new value 
        // of id, and store the new field value. 
        ilg.Emit(OpCodes.Ldarg_0);
        ilg.Emit(OpCodes.Ldarg_1);
        ilg.Emit(OpCodes.Stfld, fid);

        // The original value of the id field is now the only 
        // thing on the stack, so return from the call.
        ilg.Emit(OpCodes.Ret);


        // Create a delegate that uses changeID in the ordinary
        // way, as a static method that takes an instance of
        // Example and an int.
        //
        UseLikeStatic uls = 
            (UseLikeStatic) changeID.CreateDelegate(
                typeof(UseLikeStatic)
            );

        // Create an instance of Example with an id of 42.
        //
        Example ex = new Example(42);

        // Create a delegate that is bound to the instance of 
        // of Example. This is possible because the first 
        // parameter of changeID is of type Example. The 
        // delegate has all the parameters of changeID except
        // the first.
        UseLikeInstance uli = 
            (UseLikeInstance) changeID.CreateDelegate(
                typeof(UseLikeInstance),
                ex
            );

        // First, change the value of id by calling changeID as
        // a static method, passing in the instance of Example.
        //
        Console.WriteLine(
            "Change the value of id; previous value: {0}",
            uls(ex, 1492)
        );

        // Change the value of id again using the delegate bound
        // to the instance of Example.
        //
        Console.WriteLine(
            "Change the value of id; previous value: {0}",
            uli(2700)
        );

        Console.WriteLine("Final value of id: {0}", ex.ID);


        // Now repeat the process with a class that derives
        // from Example.
        //
        DerivedFromExample dfex = new DerivedFromExample(71);

        uli = (UseLikeInstance) changeID.CreateDelegate(
                typeof(UseLikeInstance),
                dfex
            );

        Console.WriteLine(
            "Change the value of id; previous value: {0}",
            uls(dfex, 73)
        );
        Console.WriteLine(
            "Change the value of id; previous value: {0}",
            uli(79)
        );
        Console.WriteLine("Final value of id: {0}", dfex.ID);
    }
}

/* This code example produces the following output:

Change the value of id; previous value: 42
Change the value of id; previous value: 1492
Final value of id: 2700
Change the value of id; previous value: 71
Change the value of id; previous value: 73
Final value of id: 79
 */
//</Snippet1>