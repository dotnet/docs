[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class MyAttribute : Attribute
{
   public String myString;
   public int myInteger;

   public MyAttribute(String myString1, int myInteger1)
   {
      this.myString = myString1;
      this.myInteger = myInteger1;
   }
}

class MyApplication
{
   static AssemblyBuilder myAssemblyBuilder;
   static EnumBuilder myEnumBuilder;

   public static void Main()
   {
      try
      {
         CreateCallee(Thread.GetDomain());
         if(myEnumBuilder.IsDefined(typeof(MyAttribute),false))
         {
            object[] myAttributesArray = myEnumBuilder.GetCustomAttributes(typeof(MyAttribute),false);
            Console.WriteLine("Custom attribute contains: ");
            // Read the attributes and display them on the console.
            for(int index=0; index < myAttributesArray.Length; index++)
            {
               if(myAttributesArray[index] is MyAttribute)
               {
                  Console.WriteLine("The value of myString  is: "
                                    + ((MyAttribute)myAttributesArray[index]).myString);
                  Console.WriteLine("The value of myInteger is: "
                                    + ((MyAttribute)myAttributesArray[index]).myInteger);
               }
            }
         }
         else
         {
            Console.WriteLine("Custom Attributes are not set for the EnumBuilder");
         }
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception is raised:" +e.Message);
      }

  }

   private static void CreateCallee(AppDomain domain)
   {
      // Create a name for the assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";

      // Create the dynamic assembly.
      myAssemblyBuilder = domain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run);

      Type myType = typeof(MyAttribute);
      ConstructorInfo myInfo = myType.GetConstructor(new Type[2]{typeof(String), typeof(int)});
      CustomAttributeBuilder myCustomAttributeBuilder =
                                    new CustomAttributeBuilder(myInfo, new object[2]{"Hello", 2});

      // Create a dynamic module.
      ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule");

      // Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder.DefineEnum("MyNamespace.MyEnum", TypeAttributes.Public, typeof(Int32));

      FieldBuilder myFieldBuilder1 = myEnumBuilder.DefineLiteral("FieldOne", 1);
      FieldBuilder myFieldBuilder2 = myEnumBuilder.DefineLiteral("FieldTwo", 2);

      myEnumBuilder.CreateType();
      myEnumBuilder.SetCustomAttribute(myCustomAttributeBuilder);
   }
}