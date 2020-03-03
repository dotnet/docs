//<Snippet1>
using namespace System;
using namespace System::Reflection;

// Specify a combination of AssemblyNameFlags for this
// assembly.
[assembly:AssemblyFlagsAttribute(
     AssemblyNameFlags::EnableJITcompileOptimizer
   | AssemblyNameFlags::Retargetable)];

public ref class Example
{
public:
   static void Main()
   {
      // Get this assembly.
      Assembly^ thisAsm = Example::typeid->Assembly;
      
      // Get the AssemblyName for this assembly.
      AssemblyName^ thisAsmName = thisAsm->GetName( false );
      
      // Display the flags that were set for this assembly.
      ListFlags( thisAsmName->Flags );
      
      // Create an instance of AssemblyFlagsAttribute with the
      // same combination of flags that was specified for this
      // assembly. Note that PublicKey is included automatically
      // for the assembly, but not for this instance of
      // AssemblyFlagsAttribute.
      AssemblyFlagsAttribute^ afa = gcnew AssemblyFlagsAttribute( 
         static_cast<AssemblyNameFlags> (AssemblyNameFlags::EnableJITcompileOptimizer
                                       | AssemblyNameFlags::Retargetable) );
      
      // Get the flags. The property returns an integer, so
      // the return value must be cast to AssemblyNameFlags.
      AssemblyNameFlags anf = static_cast<AssemblyNameFlags>(afa->AssemblyFlags);
      
      // Display the flags.
      Console::WriteLine();
      ListFlags( anf );
   }

private:
   static void ListFlags( AssemblyNameFlags anf )
   {
      if ( anf == AssemblyNameFlags::None )
      {
         Console::WriteLine( L"AssemblyNameFlags.None" );
      }
      else
      {
         if ( 0 != static_cast<Int32>(anf & AssemblyNameFlags::Retargetable) )
                  Console::WriteLine( L"AssemblyNameFlags.Retargetable" );
         if ( 0 != static_cast<Int32>(anf & AssemblyNameFlags::PublicKey) )
                  Console::WriteLine( L"AssemblyNameFlags.PublicKey" );
         if ( 0 != static_cast<Int32>(anf & AssemblyNameFlags::EnableJITcompileOptimizer) )
                  Console::WriteLine( L"AssemblyNameFlags.EnableJITcompileOptimizer" );
         if ( 0 != static_cast<Int32>(anf & AssemblyNameFlags::EnableJITcompileTracking) )
                  Console::WriteLine( L"AssemblyNameFlags.EnableJITcompileTracking" );
      }
   }

};

int main()
{
   Example::Main();
}

/* This code example produces the following output:

AssemblyNameFlags.Retargetable
AssemblyNameFlags.PublicKey
AssemblyNameFlags.EnableJITcompileOptimizer

AssemblyNameFlags.Retargetable
AssemblyNameFlags.EnableJITcompileOptimizer
*/
//</Snippet1>
