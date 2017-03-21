using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class MyAttribute : Attribute
{
   public bool s;

   public MyAttribute(bool s)
   {
      this.s = s;
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
      ConstructorInfo infoConstructor = myType.GetConstructor(new Type[]{typeof(bool)});
      myAssembly.SetCustomAttribute(infoConstructor, new byte[]{01,00,01});
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule");
      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldClass = myModule.DefineType("HelloWorld", TypeAttributes.Public);

      return(helloWorldClass.CreateType());
  }
}