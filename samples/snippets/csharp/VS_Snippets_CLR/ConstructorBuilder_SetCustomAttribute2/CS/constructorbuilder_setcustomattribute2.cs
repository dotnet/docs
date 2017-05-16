// System.Reflection.Emit.ConstructorBuilder.SetCustomAttribute(ConstructorInfo, byte[])
/*
   The following program demonstrates the 'SetCustomAttribute(ConstructorInfo, byte[])'
   method of 'ConstructorBuilder' class. It defines a 'MyAttribute' class which is derived
   from 'Attribute' class. It builds a constructor by setting 'MyAttribute' custom attribute
   and defines 'Helloworld' type. Then it gets the custom attributes of 'HelloWorld' type
   and displays its contents to the console.
*/
// <Snippet1>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class MyAttribute : Attribute
{
   public bool myBoolean;

   public MyAttribute(bool myBoolean)
   {
      this.myBoolean = myBoolean;
   }
}

public class MyConstructorBuilder
{
   public static void Main()
   {
      Type myHelloworld = MyCreateCallee(Thread.GetDomain());
      ConstructorInfo myConstructor = myHelloworld.GetConstructor(new Type[]{typeof(String)});
      object[] myAttributes1 = myConstructor.GetCustomAttributes(true);
      Console.WriteLine("MyAttribute custom attribute contains  ");
      for(int index=0; index < myAttributes1.Length; index++)
      {
         if(myAttributes1[index] is MyAttribute)
         {
            Console.WriteLine("myBoolean : " + ((MyAttribute)myAttributes1[index]).myBoolean);
         }
      }
   }

   private static Type MyCreateCallee(AppDomain domain)
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";
      // Define a dynamic assembly in the current application domain.
      AssemblyBuilder myAssembly =
                  domain.DefineDynamicAssembly(myAssemblyName,AssemblyBuilderAccess.Run);
      // Define a dynamic module in this assembly.
      ModuleBuilder myModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule");
      // Construct a 'TypeBuilder' given the name and attributes.
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("HelloWorld",
         TypeAttributes.Public);
      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
               MethodAttributes.Public, CallingConventions.Standard, new Type[]{typeof(String)});
      ILGenerator myILGenerator = myConstructor.GetILGenerator();
      myILGenerator.Emit(OpCodes.Ldstr, "Constructor is invoked");
      myILGenerator.Emit(OpCodes.Ldarg_1);
      MethodInfo myMethodInfo =
                     typeof(Console).GetMethod("WriteLine",new Type[]{typeof(string)});
      myILGenerator.Emit(OpCodes.Call, myMethodInfo);
      myILGenerator.Emit(OpCodes.Ret);
      Type myType = typeof(MyAttribute);
      ConstructorInfo myConstructorInfo = myType.GetConstructor(new Type[]{typeof(bool)});
      try
      {
         myConstructor.SetCustomAttribute(myConstructorInfo, new byte[]{01,00,01});
      }
      catch(ArgumentNullException ex)
      {
         Console.WriteLine("The following exception has occured : "+ex.Message);
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception has occured : "+ex.Message);
      }
      return myTypeBuilder.CreateType();
   }
}
// </Snippet1>