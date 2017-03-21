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