
// <Snippet1>
/*
   The following program demonstrates the 'DefineResource' and 'DefineUnmanagedResource'
   methods of 'AssemblyBuilder' class. It builds an assembly and a resource file at runtime.
   An unmanaged resource file is also defined for the same resource file. The EmittedTest2.cpp file
   calls the methods of "MyEmitAssembly.dll" assembly and the message is displayed to console.
*/
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Resources;

   static AssemblyBuilder^ CreateAssembly( String^ name )
   {
      AssemblyName^ aName = gcnew AssemblyName(name);
      AssemblyBuilder^ myAssembly = 
         AppDomain::CurrentDomain->DefineDynamicAssembly( aName, 
            AssemblyBuilderAccess::Save );
      
      // Define a dynamic module.
      ModuleBuilder^ myModule = 
         myAssembly->DefineDynamicModule( aName->Name, aName->Name + ".dll" );
      
      // Define a public class named "EmitClass" in the assembly.
      TypeBuilder^ myEmitClass = 
         myModule->DefineType( "EmitClass", TypeAttributes::Public );
      
      // Define the Display method.
      MethodBuilder^ myMethod = 
         myEmitClass->DefineMethod( "Display", MethodAttributes::Public, 
            String::typeid, nullptr );
      
      // Generate IL for Display method.
      ILGenerator^ methodIL = myMethod->GetILGenerator();
      methodIL->Emit( OpCodes::Ldstr, "Display method gets called." );
      methodIL->Emit( OpCodes::Ret );
      
      myEmitClass->CreateType();

      return (myAssembly);
   };

   // <Snippet2>
   // <Snippet3>
   void main()
   {
      AssemblyBuilder^ myAssembly = CreateAssembly("MyEmitTestAssembly");
      
      // Defines a standalone managed resource for this assembly.
      IResourceWriter^ myResourceWriter = 
         myAssembly->DefineResource( "myResourceFile", "A sample Resource File", 
            "MyAssemblyResource.resources", ResourceAttributes::Private );

      myResourceWriter->AddResource( "AddResource Test", "Testing for the added resource" );

      myAssembly->Save(myAssembly->GetName()->Name + ".dll" );
      
      // Defines an unmanaged resource file for this assembly.
      myAssembly->DefineUnmanagedResource( gcnew array<Byte>{01, 00, 01} );
   };

// </Snippet3>
// </Snippet2>
// </Snippet1>
