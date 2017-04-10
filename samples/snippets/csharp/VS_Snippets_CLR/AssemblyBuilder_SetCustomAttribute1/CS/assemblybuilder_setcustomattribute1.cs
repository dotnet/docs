// System.Reflection.Emit.SetCustomAttribute(CustomAttributeBuilder)
/*
   The following program demonstrates the 'SetCustomAttribute(CustomAttributeBuilder)'
   method of 'AssemblyBuilder' class. It defines a 'MyAttribute' class which is derived
   from 'Attribute' class. It builds an assembly by setting 'MyAttribute' custom attribute
   and defines 'HelloWorld' type. Then it gets the custom attributes of 'HelloWorld' type
   and displays its contents to the console.
*/

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

// <Snippet1>
[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class MyAttribute : Attribute
{
   public String s;
   public int x;

   public MyAttribute(String s, int x)
   {
      this.s = s;
      this.x = x;
   }
}

class MyApplication
{
   public static void Main()
   {
      Type customAttribute = CreateCallee(Thread.GetDomain());
      object[] attributes = customAttribute.Assembly.GetCustomAttributes(true);
      Console.WriteLine("MyAttribute custom attribute contains : ");
      for(int index=0; index < attributes.Length; index++)
      {
         if(attributes[index] is MyAttribute)
         {
            Console.WriteLine("s : " + ((MyAttribute)attributes[index]).s);
            Console.WriteLine("x : " + ((MyAttribute)attributes[index]).x);
            break;
         }
      }
   }


   private static Type CreateCallee(AppDomain domain)
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";
      AssemblyBuilder myAssembly = domain.DefineDynamicAssembly(myAssemblyName,
         AssemblyBuilderAccess.Run);
      Type myType = typeof(MyAttribute);
      ConstructorInfo infoConstructor = myType.GetConstructor(new Type[2]{typeof(String), typeof(int)});
      CustomAttributeBuilder attributeBuilder =
         new CustomAttributeBuilder(infoConstructor, new object[2]{"Hello", 2});
      myAssembly.SetCustomAttribute(attributeBuilder);
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule");
      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldClass = myModule.DefineType("HelloWorld", TypeAttributes.Public);

      return(helloWorldClass.CreateType());
  }
}
// </Snippet1>