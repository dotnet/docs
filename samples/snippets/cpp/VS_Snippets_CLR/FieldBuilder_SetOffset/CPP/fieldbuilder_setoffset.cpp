
// System::Reflection::Emit::FieldBuilder.SetOffset
// System::Reflection::Emit::FieldBuilder.SetMarshal
/*
   The following program demonstrates 'SetOffset' and 'SetMarshal' 
   methods of 'FieldBuilder' class.A new Class is defined and a 
   'PInvoke' method 'OpenFile' method of 'Kernel32.dll' is defined 
   in the class.Instance of the class is created and the method is invoked.
   To execute this program, make sure a file named 'MyFile.txt' should be there 
   in the current directory.
*/
// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::CompilerServices;
Type^ CreateType( AppDomain^ currentDomain )
{
   // Create an assembly.
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "DynamicAssembly";
   AssemblyBuilder^ myAssembly = currentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::RunAndSave );

   // Create a dynamic module in Dynamic Assembly.
   ModuleBuilder^ myModuleBuilder = myAssembly->DefineDynamicModule( "MyModule", "MyModule.mod" );

   // Define a public class named S"MyClass" in the assembly.
   TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "MyClass", TypeAttributes::Public );
   TypeBuilder^ myTypeBuilder2 = myModuleBuilder->DefineType( "MyClass2", static_cast<TypeAttributes>(TypeAttributes::Public | TypeAttributes::BeforeFieldInit | TypeAttributes::SequentialLayout | TypeAttributes::AnsiClass | TypeAttributes::Sealed) );
   FieldBuilder^ myFieldBuilder1 = myTypeBuilder2->DefineField( "myBytes1", Byte::typeid, FieldAttributes::Public );
   FieldBuilder^ myFieldBuilder2 = myTypeBuilder2->DefineField( "myBytes2", Byte::typeid, FieldAttributes::Public );
   FieldBuilder^ myFieldBuilder3 = myTypeBuilder2->DefineField( "myErrorCode", short::typeid, FieldAttributes::Public );
   FieldBuilder^ myFieldBuilder4 = myTypeBuilder2->DefineField( "myReserved1", short::typeid, FieldAttributes::Public );
   FieldBuilder^ myFieldBuilder5 = myTypeBuilder2->DefineField( "myReserved2", short::typeid, FieldAttributes::Public );
   FieldBuilder^ myFieldBuilder6 = myTypeBuilder2->DefineField( "myPathName", array<char>::typeid,FieldAttributes::Public );
   myFieldBuilder6->SetMarshal( UnmanagedMarshal::DefineByValArray( 128 ) );
   myFieldBuilder6->SetOffset( 4 );
   Type^ myType1 = myTypeBuilder2->CreateType();

   // Create the PInvoke method for 'OpenFile' method of 'Kernel32.dll'.
   array<Type^>^myParameters = {String::typeid,myType1,UInt32::typeid};
   MethodBuilder^ myMethodBuilder = myTypeBuilder->DefinePInvokeMethod( "OpenFile", "kernel32.dll", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static | MethodAttributes::HideBySig), CallingConventions::Standard, IntPtr::typeid, myParameters, CallingConvention::Winapi, CharSet::None );
   Type^ myAttributeType = MethodImplAttribute::typeid;
   array<Type^>^type1 = {MethodImplOptions::typeid};
   ConstructorInfo^ myConstructorInfo = myAttributeType->GetConstructor( type1 );
   array<Object^>^obj1 = {MethodImplOptions::PreserveSig};
   CustomAttributeBuilder^ myAttributeBuilder = gcnew CustomAttributeBuilder( myConstructorInfo,obj1 );
   myMethodBuilder->SetCustomAttribute( myAttributeBuilder );
   ParameterBuilder^ myParameterBuilder2 = myMethodBuilder->DefineParameter( 2, ParameterAttributes::Out, "myClass2" );
   Type^ myType = myTypeBuilder->CreateType();
   myAssembly->Save( "EmittedAssembly.dll" );
   return myType;
}

int main()
{
   try
   {
      Type^ myType = CreateType( Thread::GetDomain() );
      Type^ myClass2 = myType->Module->GetType( "MyClass2" );
      Object^ myParam2 = Activator::CreateInstance( myClass2 );
      UInt32 myUint = 0x00000800;
      array<Object^>^myArgs = {"MyFile.Txt",myParam2,myUint};
      Object^ myObject = myType->InvokeMember( "OpenFile", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::InvokeMethod | BindingFlags::Static), nullptr, nullptr, myArgs );
      Console::WriteLine( "MyClass::OpenFile method returned: \"{0}\"", myObject );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught {0}", e->Message );
   }
}
// </Snippet1>
