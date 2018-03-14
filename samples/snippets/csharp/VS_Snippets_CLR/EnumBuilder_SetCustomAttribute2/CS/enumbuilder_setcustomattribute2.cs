// System.Reflection.Emit.EnumBuilder.GetCustomAttributes(bool)
// System.Reflection.Emit.EnumBuilder.SetCustomAttribute(ConstructorInfo, byte[])

/*
   The following program demonstrates 'GetCustomAttributes(bool)'
   and 'SetCustomAttribute(ConstructorInfo, byte[])' methods of 
   'System.Reflection.Emit.EnumBuilder' class. It defines 'MyAttribute' 
   class which is derived from 'System.Attribute' class. It builds an 
   Enum and sets 'MyAttribute' as  custom attribute to the Enum. 
   It gets the custom attributes of the Enum type and displays its contents 
   on the console.
*/

// <Snippet1>
// <Snippet2>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class MyAttribute : Attribute
{
   public bool myBoolValue;

   public MyAttribute(bool myBool)
   {
      this.myBoolValue = myBool;
   }
}

class MyApplication
{
   static EnumBuilder myEnumBuilder;
   
   public static void Main()
   {
      try
      {
         CreateCallee(Thread.GetDomain());
         object[] myAttributesArray = myEnumBuilder.GetCustomAttributes(true);

         // Read the attributes and display them on the console.
         Console.WriteLine("Custom attribute contains: ");
         for(int index=0; index < myAttributesArray.Length; index++)
         {
            if(myAttributesArray[index] is MyAttribute)
            {
               Console.WriteLine("myBoolValue: " + 
                                       ((MyAttribute)myAttributesArray[index]).myBoolValue);
            }
         }
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception is raised:" +e.Message);
      }
   }

   private static void CreateCallee(AppDomain domain)
   {
      AssemblyName myAssemblyName = new AssemblyName();
      // Create a name for the assembly.
      myAssemblyName.Name = "EmittedAssembly";
     
      // Create the dynamic assembly.
      AssemblyBuilder myAssemblyBuilder 
                  = domain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run); 
      
      Type myType = typeof(MyAttribute);
      ConstructorInfo myInfo = myType.GetConstructor(new Type[]{typeof(bool)});
                  
      // Create a dynamic module.
      ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule");
      
      // Create a dynamic Enum.
      myEnumBuilder = 
         myModuleBuilder.DefineEnum("MyNamespace.MyEnum", TypeAttributes.Public, typeof(Int32));

      FieldBuilder myFieldBuilder1 = myEnumBuilder.DefineLiteral("FieldOne", 1);
      FieldBuilder myFieldBuilder2 = myEnumBuilder.DefineLiteral("FieldTwo", 2);  

      myEnumBuilder.CreateType();
      myEnumBuilder.SetCustomAttribute(myInfo, new byte[]{01,00,01});
      
   }
}
// </Snippet2>
// </Snippet1>