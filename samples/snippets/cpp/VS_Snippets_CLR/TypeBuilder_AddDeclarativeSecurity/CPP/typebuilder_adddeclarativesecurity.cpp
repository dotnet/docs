
// System::Reflection::Emit::TypeBuilder.AddDeclarativeSecurity
/* The following example demonstrates method AddDeclarativeSecurity
of 'TypeBuilder' class.
The program creates a dynamic assembly and a type in it having support for declarative security.
It demands an Environmentpermission read access on 'TEMP'.
Caller (main) is able to create an instance successfully with
default permission(as local machine executes with full trust permission set).
*/

// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Security;
using namespace System::Security::Permissions;

int main()
{
   // Create a simple name for the assembly; create the assembly and module.
   AssemblyName^ myAssemblyName = gcnew AssemblyName("EmittedAssembly");
   AssemblyBuilder^ myAssemblyBuilder = 
       AppDomain::CurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::RunAndSave );
   ModuleBuilder^ myModuleBuilder = 
       myAssemblyBuilder->DefineDynamicModule( "EmittedAssembly", "EmittedAssembly.dll");
   
   // Define a public class named "MyDynamicClass" in the assembly.
   TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "MyDynamicClass", TypeAttributes::Public );
   

   // Create a permission set and add a security permission
   // with the ControlEvidence flag.
   //
   PermissionSet^ myPermissionSet = gcnew PermissionSet(PermissionState::None);
   myPermissionSet->AddPermission(
      gcnew SecurityPermission(SecurityPermissionFlag::ControlEvidence));

   // Add the permission set to the MyDynamicClass type,
   // as a declarative security demand.
   //
   myTypeBuilder->AddDeclarativeSecurity(SecurityAction::Demand, myPermissionSet);

   
   Type^ myType = myTypeBuilder->CreateType();
   myAssemblyBuilder->Save("EmittedAssembly.dll");
}
// </Snippet1>
