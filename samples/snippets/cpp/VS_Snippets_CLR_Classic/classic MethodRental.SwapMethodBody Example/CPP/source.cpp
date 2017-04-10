
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::InteropServices;

// First make a method that returns 0.
// Then swap the method body with a body that returns 1.
int main()
{
   // Construct a dynamic assembly
   Guid g = Guid::NewGuid();
   AssemblyName^ asmname = gcnew AssemblyName;
   asmname->Name = String::Concat( "tempfile", g );
   AssemblyBuilder^ asmbuild = System::Threading::Thread::GetDomain()->DefineDynamicAssembly( asmname, AssemblyBuilderAccess::Run );

   // Add a dynamic module that contains one type that has one method that
   // has no arguments.
   ModuleBuilder^ modbuild = asmbuild->DefineDynamicModule( "test" );
   TypeBuilder^ tb = modbuild->DefineType( "name of the Type" );
   array<Type^>^temp2;
   MethodBuilder^ somemethod = tb->DefineMethod( "My method Name", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), int::typeid, temp2 );

   // Define the body of the method to return 0.
   ILGenerator^ ilg = somemethod->GetILGenerator();
   ilg->Emit( OpCodes::Ldc_I4_0 );
   ilg->Emit( OpCodes::Ret );

   // Complete the type and verify that it returns 0.
   Type^ tbBaked = tb->CreateType();
   array<Object^>^temp0;
   int res1 = safe_cast<Int32>(tbBaked->GetMethod( "My method Name" )->Invoke( nullptr, temp0 ));
   if ( res1 != 0 )
   {
      Console::WriteLine( "Err_001a, should have returned 0" );
   }
   else
   {
      Console::WriteLine( "Original method returned 0" );
   }

   // Define a new method body that will return a 1 instead.

   // code size
   // ldc_i4_1
   // ret
   array<Byte>^methodBytes = {0x03,0x30,0x0A,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x17,0x2a};

   // Get the token for the method whose body you are replacing.
   MethodToken somemethodToken = somemethod->GetToken();

   // Get the pointer to the method body.
   GCHandle hmem = GCHandle::Alloc( (Object^)methodBytes, GCHandleType::Pinned );
   IntPtr addr = hmem.AddrOfPinnedObject();
   int cbSize = methodBytes->Length;

   // Swap the old method body with the new body.
   MethodRental::SwapMethodBody( tbBaked, somemethodToken.Token, addr, cbSize, MethodRental::JitImmediate );

   // Verify that the modified method returns 1.
   array<Object^>^temp1;
   int res2 = safe_cast<Int32>(tbBaked->GetMethod( "My method Name" )->Invoke( nullptr, temp1 ));
   if ( res2 != 1 )
   {
      Console::WriteLine( "Err_001b, should have returned 1" );
   }
   else
   {
      Console::WriteLine( "Swapped method body returned 1" );
   }
}
// </Snippet1>
