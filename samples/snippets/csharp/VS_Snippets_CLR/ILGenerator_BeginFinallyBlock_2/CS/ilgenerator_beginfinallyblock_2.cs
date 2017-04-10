// System.Reflection.Emit.ILGenerator.BeginExceptFilterBlock()
// System.Reflection.Emit.ILGenerator.BeginFinallyBlock()

/*
   The following program demonstrates the 'BeginExceptFilterBlock()' method and
   'BeginFinallyBlock()' of 'ILGenerator' class. Exception is raised by passing
   two integer values which are out of range, the same is caught in the
   'BeginExceptionBlock' which is non-filtered and then emits the MSIL
   instructions in 'BeginExceptFilterBlock' and 'BeginFinallyBlock'.
*/

// <Snippet1>
// <Snippet2>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

public class ILGenerator_BeginFinallyBlock
{
   public static Type AddType()
   {
      // Create an assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "AdderExceptionAsm";

      // Create dynamic assembly.
      AppDomain myAppDomain = Thread.GetDomain();
      AssemblyBuilder myAssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName,
         AssemblyBuilderAccess.Run);

      // Create a dynamic module.
      ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("AdderExceptionMod");
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("Adder");
      Type[] adderParams = new Type[] {typeof(int), typeof(int)};

      // Define method to add two numbers.
      MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod("DoAdd",MethodAttributes.Public |
         MethodAttributes.Static,typeof(int),adderParams);
      ILGenerator myAdderIL = myMethodBuilder.GetILGenerator();

      // Create constructor.
      ConstructorInfo myConstructorInfo = typeof(OverflowException).GetConstructor(
         new Type[]{typeof(string)});
      MethodInfo myExToStrMI = typeof(OverflowException).GetMethod("ToString");
      MethodInfo myWriteLineMI = typeof(Console).GetMethod("WriteLine",new Type[]
         {typeof(string),typeof(object)});

      // Declare local variable.
      LocalBuilder myLocalBuilder1 = myAdderIL.DeclareLocal(typeof(int));
      LocalBuilder myLocalBuilder2 = myAdderIL.DeclareLocal(typeof(OverflowException));

      // Define label.
      Label myFailedLabel = myAdderIL.DefineLabel();
      Label myEndOfMethodLabel = myAdderIL.DefineLabel();

      // Begin exception block.
      Label myLabel = myAdderIL.BeginExceptionBlock();

      myAdderIL.Emit(OpCodes.Ldarg_0);
      myAdderIL.Emit(OpCodes.Ldc_I4_S, 10);
      myAdderIL.Emit(OpCodes.Bgt_S, myFailedLabel);

      myAdderIL.Emit(OpCodes.Ldarg_1);
      myAdderIL.Emit(OpCodes.Ldc_I4_S, 10);
      myAdderIL.Emit(OpCodes.Bgt_S, myFailedLabel);

      myAdderIL.Emit(OpCodes.Ldarg_0);
      myAdderIL.Emit(OpCodes.Ldarg_1);
      myAdderIL.Emit(OpCodes.Add_Ovf_Un);
      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder1);
      myAdderIL.Emit(OpCodes.Br_S, myEndOfMethodLabel);

      myAdderIL.MarkLabel(myFailedLabel);
      myAdderIL.Emit(OpCodes.Ldstr, "Cannot accept values over 10 for add.");
      myAdderIL.Emit(OpCodes.Newobj, myConstructorInfo);

      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder2);
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder2);

      // Throw the exception.
      myAdderIL.ThrowException(typeof(OverflowException));

      // Call 'BeginExceptFilterBlock'.
      myAdderIL.BeginExceptFilterBlock();
      myAdderIL.EmitWriteLine("Except filter block called.");

      // Call catch block.
      myAdderIL.BeginCatchBlock(null);
      
      // Call other catch block.
      myAdderIL.BeginCatchBlock(typeof(OverflowException));

      myAdderIL.Emit(OpCodes.Ldstr, "{0}");
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder2);
      myAdderIL.EmitCall(OpCodes.Callvirt, myExToStrMI, null);
      myAdderIL.EmitCall(OpCodes.Call, myWriteLineMI, null);
      myAdderIL.Emit(OpCodes.Ldc_I4_M1);
      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder1);

      // Call finally block.
      myAdderIL.BeginFinallyBlock();
      myAdderIL.EmitWriteLine("Finally block called.");

      // End the exception block.
      myAdderIL.EndExceptionBlock();

      myAdderIL.MarkLabel(myEndOfMethodLabel);
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder1);
      myAdderIL.Emit(OpCodes.Ret);

      return myTypeBuilder.CreateType();
   }
   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      Type myAddType = AddType();
      object myObject1 = Activator.CreateInstance(myAddType);
      object[] myObject2 = new object[]{15,15};
      myAddType.InvokeMember("DoAdd", BindingFlags.InvokeMethod,
         null, myObject1, myObject2);
   }
}
// </Snippet2>
// </Snippet1>