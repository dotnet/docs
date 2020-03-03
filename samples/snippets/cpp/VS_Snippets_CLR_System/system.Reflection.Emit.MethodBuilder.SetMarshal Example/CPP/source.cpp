using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

class VariousMethodBuilderSnippets
{
public:
   static void ContainerMethod( TypeBuilder^ myDynamicType )
   {
      // <Snippet1>
      array<Type^>^ temp0 = { String::typeid };
      MethodBuilder^ myMethod = myDynamicType->DefineMethod( "MyMethodReturnsMarshal",
                                MethodAttributes::Public,
                                UInt32::typeid,
                                temp0 );
      
      // We want the return value of our dynamic method to be marshalled as
      // an 64-bit (8-Byte) signed integer, instead of the default 32-bit
      // unsigned int as specified above. The UnmanagedMarshal class can perform
      // the type conversion.

      UnmanagedMarshal^ marshalMeAsI8 = UnmanagedMarshal::DefineUnmanagedMarshal(
                                        System::Runtime::InteropServices::UnmanagedType::I8 );

      myMethod->SetMarshal( marshalMeAsI8 );
      // </Snippet1>
   }
};
