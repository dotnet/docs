
//  System.Reflection.ParameterInfo.IsIn
//  System.Reflection.ParameterInfo.IsOptional
//  System.Reflection.ParameterInfo.IsOut

/*
   The following program creates a dynamic assembly named 'MyAssembly', defines a
   module named 'MyModule' within the assembly. It defines a type called 'MyType'
   within the module and also defines a static method named 'MyMethod' for the 
   type. This dynamic assembly is then queried for the type defined within it and
   then the attributes of all the parameters of the method named 'MyMethod' is 
   displayed.
 */

// <Snippet1>
// <Snippet2>
// <Snippet3>

using System;
using System.Reflection;
using System.Threading;
using System.Reflection.Emit;

public class ParameterInfo_IsIn_IsOut_IsOptional
{
   public static void DefineMethod()
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "MyAssembly";
      // Get the assembly builder from the application domain associated with the current thread.
      AssemblyBuilder myAssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);
      // Create a dynamic module in the assembly.
      ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("MyModule", "MyAssembly.dll");
      // Create a type in the module.
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("MyType");
      // Create a method called MyMethod.
      MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod("MyMethod",MethodAttributes.Public | MethodAttributes.HideBySig |
                                                                           MethodAttributes.Static, typeof(string), new Type[] {typeof(int), typeof(short), typeof(long)});
      // Set the attributes for the parameters of the method.
      // Set the attribute for the first parameter to IN.
      ParameterBuilder myParameterBuilder = myMethodBuilder.DefineParameter(1, ParameterAttributes.In, "MyIntParameter");
      // Set the attribute for the second parameter to OUT.
      myParameterBuilder = myMethodBuilder.DefineParameter(2, ParameterAttributes.Out, "MyShortParameter");
      // Set the attribute for the third parameter to OPTIONAL.
      myParameterBuilder = myMethodBuilder.DefineParameter(3, ParameterAttributes.Optional | ParameterAttributes.HasDefault, "MyLongParameter");
      // Get the Microsoft Intermediate Language generator for the method.
      ILGenerator myILGenerator = myMethodBuilder.GetILGenerator();
      // Use the utility method to generate the MSIL instructions that print a string to the console.
      myILGenerator.EmitWriteLine("Hello World!");
      // Generate the "ret" MSIL instruction.
      myILGenerator.Emit(OpCodes.Ret);
      // End the creation of the type.
      myTypeBuilder.CreateType();
   }

   public static void Main()
   {
      // Create a dynamic assembly with a type named MyType.
      DefineMethod();

      // Get the assemblies currently loaded in the application domain.
      Assembly[] myAssemblies = Thread.GetDomain().GetAssemblies();
      Assembly myAssembly = null;
      // Get the assembly named MyAssembly.
      for(int i = 0; i < myAssemblies.Length; i++)
         if(String.Compare(myAssemblies[i].GetName(false).Name, "MyAssembly") == 0)
            myAssembly = myAssemblies[i];

      if(myAssembly != null)
      {
         // Get a type named MyType.
         Type myType = myAssembly.GetType("MyType");
         // Get a method named MyMethod from the type.
         MethodBase myMethodBase = myType.GetMethod("MyMethod");
         // Get the parameters associated with the method.
         ParameterInfo[] myParameters = myMethodBase.GetParameters();
         Console.WriteLine("\nThe method {0} has the {1} parameters :", 
            myMethodBase, myParameters.Length);
         // Print the IN, OUT and OPTIONAL attributes associated with each of the parameters.
         for(int i = 0; i < myParameters.Length; i++)
         {
            if(myParameters[i].IsIn)
               Console.WriteLine("\tThe {0} parameter has the In attribute", 
                                       i + 1);
            if(myParameters[i].IsOptional)
               Console.WriteLine("\tThe {0} parameter has the Optional attribute",
                                       i + 1);
            if(myParameters[i].IsOut)
               Console.WriteLine("\tThe {0} parameter has the Out attribute",
                                       i + 1);
         }
      }
      else
         Console.WriteLine("Could not find a assembly named 'MyAssembly' for the current application domain");
   }
}
// </Snippet3>
// </Snippet2>
// </Snippet1>