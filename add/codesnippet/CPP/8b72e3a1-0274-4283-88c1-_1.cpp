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