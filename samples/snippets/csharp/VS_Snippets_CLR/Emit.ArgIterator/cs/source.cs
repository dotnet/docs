// Created 4-5-2006 by GlennHa from sample code by HaiboLuo...Thx, Haibo!
//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class Example
{
    static void Main() 
    {
        string name = "InMemory";

        AssemblyBuilder asmBldr = 
           AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(name), 
              AssemblyBuilderAccess.Run);
        ModuleBuilder modBldr = asmBldr.DefineDynamicModule(name); 

        TypeBuilder tb = modBldr.DefineType("DemoVararg");

        // Create a vararg method with no return value and one 
        // string argument. (The string argument type is the only
        // element of an array of Type objects.)
        //
        MethodBuilder mb1 = tb.DefineMethod("VarargMethod",
            MethodAttributes.Public | MethodAttributes.Static,
            CallingConventions.VarArgs,
            null, 
            new Type[] { typeof(string) });

        ILGenerator il1 = mb1.GetILGenerator();

        LocalBuilder locAi = il1.DeclareLocal(typeof(ArgIterator));
        LocalBuilder locNext = il1.DeclareLocal(typeof(bool));

        Label labelCheckCondition = il1.DefineLabel();
        Label labelNext = il1.DefineLabel();

        // Load the fixed argument and print it.
        il1.Emit(OpCodes.Ldarg_0);
        il1.Emit(OpCodes.Call, typeof(Console).GetMethod("Write", new Type[] { typeof(string) }));

        // Load the address of the local variable represented by
        // locAi, which will hold the ArgIterator.
        il1.Emit(OpCodes.Ldloca_S, locAi);

        // Load the address of the argument list, and call the 
        // ArgIterator constructor that takes an array of runtime
        // argument handles. 
        il1.Emit(OpCodes.Arglist);
        il1.Emit(OpCodes.Call, typeof(ArgIterator).GetConstructor(new Type[] { typeof(RuntimeArgumentHandle) }));

        // Enter the loop at the point where the remaining argument
        // count is tested.
        il1.Emit(OpCodes.Br_S, labelCheckCondition);

        // At the top of the loop, call GetNextArg to get the next 
        // argument from the ArgIterator. Convert the typed reference
        // to an object reference and write the object to the console.
        il1.MarkLabel(labelNext);
        il1.Emit(OpCodes.Ldloca_S, locAi);
        il1.Emit(OpCodes.Call, typeof(ArgIterator).GetMethod("GetNextArg", Type.EmptyTypes));
        il1.Emit(OpCodes.Call, typeof(TypedReference).GetMethod("ToObject"));
        il1.Emit(OpCodes.Call, typeof(Console).GetMethod("Write", new Type[] { typeof(object) }));

        il1.MarkLabel(labelCheckCondition);
        il1.Emit(OpCodes.Ldloca_S, locAi);
        il1.Emit(OpCodes.Call, typeof(ArgIterator).GetMethod("GetRemainingCount"));

        // If the remaining count is greater than zero, go to
        // the top of the loop.
        il1.Emit(OpCodes.Ldc_I4_0);
        il1.Emit(OpCodes.Cgt);
        il1.Emit(OpCodes.Stloc_1);
        il1.Emit(OpCodes.Ldloc_1);
        il1.Emit(OpCodes.Brtrue_S, labelNext);

        il1.Emit(OpCodes.Ret);

        // Create a method that contains a call to the vararg 
        // method.
        MethodBuilder mb2 = tb.DefineMethod("CallVarargMethod",
            MethodAttributes.Public | MethodAttributes.Static,
            CallingConventions.Standard,
            typeof(void), Type.EmptyTypes);
        ILGenerator il2 = mb2.GetILGenerator();

        // Push arguments on the stack: one for the fixed string
        // parameter, and two for the list.
        il2.Emit(OpCodes.Ldstr, "Hello ");
        il2.Emit(OpCodes.Ldstr, "world ");
        il2.Emit(OpCodes.Ldc_I4, 2006);

        // Call the vararg method, specifying the types of the 
        // arguments in the list.
        il2.EmitCall(OpCodes.Call, mb1, new Type[] { typeof(string), typeof(int) });

        il2.Emit(OpCodes.Ret);

        Type type = tb.CreateType();
        type.GetMethod("CallVarargMethod").Invoke(null, null);
    }
}

/* This code example produces the following output:

Hello world 2006
 */
//</Snippet1>


