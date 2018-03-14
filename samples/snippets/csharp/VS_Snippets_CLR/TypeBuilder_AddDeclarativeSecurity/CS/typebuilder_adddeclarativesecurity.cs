// System.Reflection.Emit.TypeBuilder.AddDeclarativeSecurity

/* The following example demonstrates method AddDeclarativeSecurity
   of 'TypeBuilder' class.
   The program creates a dynamic assembly and a type in it that has
   a declarative security demand for ControlEvidence.
   Caller (main) is able to create an instance successfully with 
   default permission, because the local machine executes with a 
   full trust permission set. 
*/
// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using System.Security.Permissions;

namespace CustomAttribute_Sample
{
   public class MyApplication 
   {
      static void Main()
      {
         // Create a simple name for the assembly, and create the assembly and module.
         AssemblyName myAssemblyName = new AssemblyName("EmittedAssembly");
         AssemblyBuilder myAssemblyBuilder =
            AppDomain.CurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);
         ModuleBuilder myModuleBuilder = 
            myAssemblyBuilder.DefineDynamicModule("EmittedAssembly", "EmittedAssembly.dll");

         // Define a public class named "MyDynamicClass" in the assembly.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("MyDynamicClass",
            TypeAttributes.Public);


         // Create a permission set and add a security permission
         // with the ControlEvidence flag.
         //
         PermissionSet myPermissionSet = new PermissionSet(PermissionState.None);
         myPermissionSet.AddPermission(
             new SecurityPermission(SecurityPermissionFlag.ControlEvidence));

         // Add the permission set to the MyDynamicClass type,
         // as a declarative security demand.
         //
         myTypeBuilder.AddDeclarativeSecurity(SecurityAction.Demand, myPermissionSet);


         Type myType = myTypeBuilder.CreateType();
         myAssemblyBuilder.Save("EmittedAssembly.dll");
      }
   }
}
// </Snippet1>


