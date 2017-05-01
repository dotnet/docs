using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

class MethodBuilderAssortedMembersDemo
{
public:
   static void MemberSnippets( TypeBuilder^ myTypeBuilder )
   {
      // <Snippet1>
      array<Type^>^ temp0 = { int::typeid, int::typeid };
      MethodBuilder^ myMthdBuilder = myTypeBuilder->DefineMethod( "MyMethod",
                                     MethodAttributes::Public,
                                     CallingConventions::HasThis,
                                     int::typeid,
                                     temp0 );
      
      // Specifies that the dynamic method declared above has a an MSIL implementation,
      // is managed, synchronized (single-threaded) through the body, and that it
      // cannot be inlined.

      myMthdBuilder->SetImplementationFlags( (MethodImplAttributes)(
                                              MethodImplAttributes::IL |
                                              MethodImplAttributes::Managed |
                                              MethodImplAttributes::Synchronized |
                                              MethodImplAttributes::NoInlining) );
      
      // Create an ILGenerator for the MethodBuilder and emit MSIL here ...
      // </Snippet1>
   }
};
