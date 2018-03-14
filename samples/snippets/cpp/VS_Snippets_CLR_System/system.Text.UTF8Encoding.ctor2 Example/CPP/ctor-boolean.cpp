
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
void ShowArray( Array^ theArray )
{
   IEnumerator^ myEnum = theArray->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::Write( "[{0}]", o );
   }

   Console::WriteLine();
}

int main()
{
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   UTF8Encoding^ utf8EmitBOM = gcnew UTF8Encoding( true );
   Console::WriteLine( "utf8 preamble:" );
   ShowArray( utf8->GetPreamble() );
   Console::WriteLine( "utf8EmitBOM:" );
   ShowArray( utf8EmitBOM->GetPreamble() );
}

// </Snippet1>
