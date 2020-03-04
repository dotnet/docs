using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

class MyMethodBuilderDemo
{
public:
   static void BuildDynMethod( ModuleBuilder^ myModBuilder )
   {
      //<Snippet1>
      // myModBuilder is an instance of ModuleBuilder.
      // Note that for the use of PermissionSet and SecurityAction,
      // the namespaces System::Security and System::Security::Permissions
      // should be included.

      TypeBuilder^ myTypeBuilder = myModBuilder->DefineType( "MyType",
                                   TypeAttributes::Public );

      array<Type^>^ temp0 = {int::typeid, int::typeid};
      MethodBuilder^ myMethod1 = myTypeBuilder->DefineMethod( "MyMethod",
                                 MethodAttributes::Public,
                                 int::typeid, temp0 );

      PermissionSet^ myMethodPermissions = gcnew PermissionSet(
                                           PermissionState::Unrestricted );

      myMethod1->AddDeclarativeSecurity( SecurityAction::Demand,
                                         myMethodPermissions );
      //</Snippet1>
   }
};
