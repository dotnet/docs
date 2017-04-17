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
      MethodBuilder^ myMethod = myDynamicType->DefineMethod( "MyMethod",
                                MethodAttributes::Public,
                                int::typeid,
                                temp0 );
      
      // A 128-bit key in hex form, represented as a Byte array.
      array<Byte>^ keyVal = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                              0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0xFF, 0xFF};

      System::Text::ASCIIEncoding^ encoder = gcnew System::Text::ASCIIEncoding;
      array<Byte>^ symFullName = encoder->GetBytes( "My Dynamic Method" );

      myMethod->SetSymCustomAttribute( "SymID", keyVal );
      myMethod->SetSymCustomAttribute( "SymFullName", symFullName );
      // </Snippet1>
   }
};
