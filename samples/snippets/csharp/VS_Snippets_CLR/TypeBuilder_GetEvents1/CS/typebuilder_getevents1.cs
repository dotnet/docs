   // System.Reflection.Emit.TypeBuilder.GetEvents(BindingFlags)

/*
   The program demonstrates the 'GetEvents' method of the 'TypeBuilder' class.
   It builds an assembly by defining 'HelloWorld' type and creates a 'Click' and
   'MouseUp' events on the type. Then displays all events to the Console.
*/
// <Snippet1>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


public class MyApplication
{
   public delegate void MyEvent(Object temp);
   public static void Main()
   {
      TypeBuilder helloWorldClass = CreateCallee(Thread.GetDomain());

      EventInfo[] info =
         helloWorldClass.GetEvents(BindingFlags.Public | BindingFlags.Instance);
      Console.WriteLine("'HelloWorld' type has following events :");
      for(int i=0; i < info.Length; i++)
         Console.WriteLine(info[i].Name);
   }

   // Create the callee transient dynamic assembly.
   private static TypeBuilder CreateCallee(AppDomain myDomain)
   {
      AssemblyName assemblyName = new AssemblyName();
      assemblyName.Name = "EmittedAssembly";

      // Create the callee dynamic assembly.
      AssemblyBuilder myAssembly =
         myDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
      // Create a dynamic module named "CalleeModule" in the callee.
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule");

      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldClass =
         myModule.DefineType("HelloWorld", TypeAttributes.Public);

      MethodBuilder myMethod1 = helloWorldClass.DefineMethod("OnClick",
         MethodAttributes.Public, typeof(void), new Type[]{typeof(Object)});
      ILGenerator methodIL1 = myMethod1.GetILGenerator();
      methodIL1.Emit(OpCodes.Ret);
      MethodBuilder myMethod2 = helloWorldClass.DefineMethod("OnMouseUp",
         MethodAttributes.Public, typeof(void), new Type[]{typeof(Object)});
      ILGenerator methodIL2 = myMethod2.GetILGenerator();
      methodIL2.Emit(OpCodes.Ret);

      // Create the events.
      EventBuilder myEvent1 = helloWorldClass.DefineEvent("Click", EventAttributes.None,
         typeof(MyEvent));
      myEvent1.SetRaiseMethod(myMethod1);
      EventBuilder myEvent2 = helloWorldClass.DefineEvent("MouseUp", EventAttributes.None,
         typeof(MyEvent));
      myEvent2.SetRaiseMethod(myMethod2);

      helloWorldClass.CreateType();
      return(helloWorldClass);
   }
}
// </Snippet1>