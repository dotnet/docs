// System.Reflection.Emit.FieldBuilder.SetCustomAttribute(ConstructorInfo,byte[])
// System.Reflection.Emit.FieldBuilder.SetCustomAttribute(CustomAttributeBuilder)

/*
   The following program demonstrates 'SetCustomAttribute(ConstructorInfo,byte[])'
   and 'SetCustomAttribute(CustomAttributeBuilder)' methods of 'FieldBuilder' class.
   A dynamic assembly is created. A new class of type 'MyClass' is created.
   A 'Method' and a 'Field are defined in the class.Two 'CustomAttributes' are
   set to the field.The method initializes a value to 'Field'.Value of the field
   is displayed to console.Values of Attributes applied to field are retreived and
   displayed to console.
*/

// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace MySample
{
   [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
   public class MyAttribute1 :Attribute
   {
      public string myCustomAttributeValue;
      public MyAttribute1(string myString)
      {
         myCustomAttributeValue = myString;

      }
   }
   [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
   public class MyAttribute2 :Attribute
   {
      public bool myCustomAttributeValue;
      public MyAttribute2(bool myBool)
      {
         myCustomAttributeValue = myBool;

      }
   }

   class FieldBuilder_Sample
   {
      private static Type CreateCallee(AppDomain currentDomain)
      {

         // Create a simple name for the assembly.
         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "EmittedAssembly";
         // Create the called dynamic assembly.
         AssemblyBuilder myAssemblyBuilder =
            currentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);
         ModuleBuilder myModuleBuilder =
                  myAssemblyBuilder.DefineDynamicModule("EmittedModule","EmittedModule.mod");
         // Define a public class named 'CustomClass' in the assembly.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("CustomClass",
            TypeAttributes.Public);
         // Define a private String field named 'MyField' in the type.
         FieldBuilder myFieldBuilder =
            myTypeBuilder.DefineField("MyField", typeof(String), FieldAttributes.Public);
         Type myAttributeType1 = typeof(MyAttribute1);
         // Create a Constructorinfo object for attribute 'MyAttribute1'.
         ConstructorInfo myConstructorInfo = myAttributeType1.GetConstructor(
            new Type[1]{typeof(string)});
         // Create the CustomAttribute instance of attribute of type 'MyAttribute1'.
         CustomAttributeBuilder attributeBuilder =
                     new CustomAttributeBuilder( myConstructorInfo,new object[1]{"Test"});
         // Set the CustomAttribute 'MyAttribute1' to the Field.
         myFieldBuilder.SetCustomAttribute(attributeBuilder);

          Type myAttributeType2 = typeof(MyAttribute2);
         // Create a Constructorinfo object for attribute 'MyAttribute2'.
        ConstructorInfo myConstructorInfo2 = myAttributeType2.GetConstructor(
            new Type[1]{typeof(bool)});
         // Set the CustomAttribute 'MyAttribute2' to the Field.
         myFieldBuilder.SetCustomAttribute(myConstructorInfo2,new byte[]{01,00,01,00,00});

         // Create a method.
         MethodBuilder myMethodBuilder= myTypeBuilder.DefineMethod("MyMethod",
            MethodAttributes.Public,null,new Type[2]{typeof(string),typeof(int)});

         ILGenerator myILGenerator = myMethodBuilder.GetILGenerator();
         myILGenerator.Emit(OpCodes.Ldarg_0);
         myILGenerator.Emit(OpCodes.Ldarg_1);
         myILGenerator.Emit(OpCodes.Stfld, myFieldBuilder);
         myILGenerator.EmitWriteLine("Value of the Field is :");
         myILGenerator.EmitWriteLine(myFieldBuilder);
         myILGenerator.Emit(OpCodes.Ret);

         return myTypeBuilder.CreateType();
      }
      public static void Main()
      {
         try
         {
            Type myCustomClass = CreateCallee(Thread.GetDomain());
            // Construct an instance of a type.
            Object myObject = Activator.CreateInstance(myCustomClass);
            Console.WriteLine( "FieldBuilder Sample");
            // Find a method in this type and call it on this object.
            MethodInfo myMethodInfo = myCustomClass.GetMethod("MyMethod");
            myMethodInfo.Invoke(myObject, new object[2]{"Sample string",3});
            // Retrieve the values of Attributes applied to field and display to console.
            FieldInfo[] myFieldInfo = myCustomClass.GetFields();
            for(int i =0;i<myFieldInfo.Length;i++)
            {
               object[] attributes = myFieldInfo[i].GetCustomAttributes(true);
               for(int index=0; index < attributes.Length; index++)
               {
                  if(attributes[index] is MyAttribute1)
                  {
                     MyAttribute1 myCustomAttribute = (MyAttribute1)attributes[index];
                     Console.WriteLine("Attribute Value of (MyAttribute1): "
                                       + myCustomAttribute.myCustomAttributeValue);
                  }
                  if(attributes[index] is MyAttribute2)
                  {
                     MyAttribute2 myCustomAttribute = (MyAttribute2)attributes[index];
                     Console.WriteLine("Attribute Value of (MyAttribute2): "
                                       + myCustomAttribute.myCustomAttributeValue);
                  }
               }
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Exception Caught "+e.Message);
         }
      }
   }
}
// </Snippet1>