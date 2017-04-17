
// <Snippet1>
using namespace System;

int main()
{
   try {
      // Get the type of a specified class.
      Type^ myType1 = Type::GetType( "System.Int32" );
      Console::WriteLine( "The full name is {0}.\n", myType1->FullName );
   }
   catch ( TypeLoadException^ e ) {
       Console::WriteLine("{0}: Unable to load type System.Int32",
                          e->GetType()->Name);
   }

   try {
      // Since NoneSuch does not exist in this assembly, GetType throws a TypeLoadException.
      Type^ myType2 = Type::GetType( "NoneSuch", true );
      Console::WriteLine( "The full name is {0}.", myType2->FullName );
   }
   catch ( TypeLoadException^ e ) {
       Console::WriteLine("{0}: Unable to load type NoneSuch",
                          e->GetType()->Name);
   }

}
// The example displays the following output:
//       The full name is System.Int32.
//
//       TypeLoadException: Unable to load type NoneSuch
// </Snippet1>
