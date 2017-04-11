// System.Reflection.Emit.TypeBuilder.DefineUninitializedData(string,int,FieldAttributes)

/*
   The following program demonstrates the 'DefineUninitializedData'
   method of 'TypeBuilder' class. It builds an assembly by defining 'MyHelloWorld' type and
   it has 'MyGreeting' field. Then it displays the initial value of 'MyGreeting'
   field to the console.
*/

// <Snippet1>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Permissions;

public sealed class Example
{
   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      Type myHelloWorldType = CreateCallee(Thread.GetDomain());
      object myHelloWorldInstance =
      Activator.CreateInstance(myHelloWorldType);
      FieldInfo myGreetingFieldInfo =
      myHelloWorldType.GetField("MyGreeting");
      object oval = Activator.CreateInstance(myGreetingFieldInfo.FieldType);
      IntPtr myIntPtr = Marshal.AllocHGlobal(4);
      Random rand = new Random();
      int iTempSeed = rand.Next();
      byte[] bINITBYTE = GetRandBytes( iTempSeed, 4);
      IntPtr intptrTemp = myIntPtr;
      for ( int j = 0; j < 4; j++ )
      {
         Marshal.WriteByte( myIntPtr, bINITBYTE[j]);
         myIntPtr = (IntPtr)((int)myIntPtr + 1);
      }
      myIntPtr = intptrTemp;
      Object oValNew = Marshal.PtrToStructure( myIntPtr, myGreetingFieldInfo.FieldType);
      Marshal.FreeHGlobal( myIntPtr );

      myIntPtr = Marshal.AllocHGlobal(4);
      object myObj = myGreetingFieldInfo.GetValue(myHelloWorldInstance);
      Marshal.StructureToPtr(myObj, myIntPtr, true);
      intptrTemp = myIntPtr;
      Console.WriteLine("The value of 'MyGreeting' field : ");
      for ( int j = 0; j < 4; j++ )
      {
         Marshal.WriteByte( myIntPtr, bINITBYTE[j]);
         Console.WriteLine(bINITBYTE[j]);
         myIntPtr = (IntPtr)((int)myIntPtr + 1);
      }
   }

   private static byte[] GetRandBytes( int iRandSeed, int iSize )
   {
      byte[] barr = new byte[iSize];
      Random randTemp = new Random( iRandSeed );
      randTemp.NextBytes( barr );
      return barr;
   }

   // Create the callee transient dynamic assembly.
   private static Type CreateCallee(AppDomain myDomain)
   {
      // Create a simple name for the callee assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedClass";

      // Create the callee dynamic assembly.
      AssemblyBuilder myAssembly =
         myDomain.DefineDynamicAssembly(myAssemblyName,AssemblyBuilderAccess.Run);

      // Create a dynamic module in the callee assembly.
      ModuleBuilder myModule =
         myAssembly.DefineDynamicModule("EmittedModule");

      // Define a public class named "MyHelloWorld"
      TypeBuilder myHelloWorldType =
         myModule.DefineType("MyHelloWorld", TypeAttributes.Public);

      // Define a 'MyGreeting' field and initialize it.
      FieldBuilder myFieldBuilder =
         myHelloWorldType.DefineUninitializedData("MyGreeting",4,FieldAttributes.Public);

      // Create the 'MyHelloWorld' class.
      return(myHelloWorldType.CreateType());
   }

   private Example() {}
}
// </Snippet1>

