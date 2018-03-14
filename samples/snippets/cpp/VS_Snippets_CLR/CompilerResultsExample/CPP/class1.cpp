#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Collections;
using namespace System::Security::Permissions;

public ref class Class1
{
public:
   Class1(){}

   //<Snippet1>
   // Displays information from a CompilerResults.
   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   static void DisplayCompilerResults( System::CodeDom::Compiler::CompilerResults^ cr )
   {
      
      // If errors occurred during compilation, output the compiler output and errors.
      if ( cr->Errors->Count > 0 )
      {
         for ( int i = 0; i < cr->Output->Count; i++ )
            Console::WriteLine( cr->Output[ i ] );
         for ( int i = 0; i < cr->Errors->Count; i++ )
            Console::WriteLine( String::Concat( i, ": ", cr->Errors[ i ] ) );
      }
      else
      {
         
         // Display information ab->Item[Out] the* compiler's exit code and the generated assembly.
         Console::WriteLine( "Compiler returned with result code: {0}", cr->NativeCompilerReturnValue );
         Console::WriteLine( "Generated assembly name: {0}", cr->CompiledAssembly->FullName );
         if ( cr->PathToAssembly == nullptr )
                  Console::WriteLine( "The assembly has been generated in memory." );
         else
                  Console::WriteLine( "Path to assembly: {0}", cr->PathToAssembly );
         
         // Display temporary files information.
         if (  !cr->TempFiles->KeepFiles )
                  Console::WriteLine( "Temporary build files were deleted." );
         else
         {
            Console::WriteLine( "Temporary build files were not deleted." );
            
            // Display a list of the temporary build files
            IEnumerator^ enu = cr->TempFiles->GetEnumerator();
            for ( int i = 0; enu->MoveNext(); i++ )
               Console::WriteLine("TempFile " + i.ToString() + ": " + (String^)(enu->Current) );
         }
      }
   }
   //</Snippet1>
};
