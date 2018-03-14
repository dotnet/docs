using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

class MyDynamicAssembly
{
public:
   static void BuildDynamicMethod( TypeBuilder^ myTypeBuilder,
                                   array<Type^>^ mthdParamTypes,
                                   Type^ returnType,
                                   int addrOfLegacyNumberObject )
   {
      // <Snippet1>
      MethodBuilder^ myMthdBuilder = myTypeBuilder->DefineMethod( "MyMethod",
                                     MethodAttributes::Public,
                                     returnType, mthdParamTypes );
      
      // We will assume that an external unmanaged type "LegacyNumber" has been loaded, and
      // that it has a method "ToString" which returns a String.

      MethodInfo^ unmanagedMthdMI = Type::GetType( "LegacyNumber" )->GetMethod( "ToString" );
      ILGenerator^ myMthdIL = myMthdBuilder->GetILGenerator();
      
      // Code to emit various IL opcodes here ...

      // Load a reference to the specific Object instance onto the stack.

      myMthdIL->Emit( OpCodes::Ldc_I4, addrOfLegacyNumberObject );
      myMthdIL->Emit( OpCodes::Ldobj, Type::GetType( "LegacyNumber" ) );
      
      // Make the call to the unmanaged type method, telling it that the method is
      // the member of a specific instance, to expect a String
      // as a return value, and that there are no explicit parameters.
      myMthdIL->EmitCalli( OpCodes::Calli,
                           System::Runtime::InteropServices::CallingConvention::ThisCall,
                           String::typeid,
                           gcnew array<Type^>( 0 ) );
      
      // More IL code emission here ...
      // </Snippet1>
   }
};
