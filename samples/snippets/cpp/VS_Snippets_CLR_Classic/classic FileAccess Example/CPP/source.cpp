using namespace System;
using namespace System::IO;

public ref class Form1
{
protected:
   void Method( String^ name )
   {
// <Snippet1>
FileStream^ s2 = gcnew FileStream( name, FileMode::Open, FileAccess::Read, FileShare::Read );
// </Snippet1>
   }
};
