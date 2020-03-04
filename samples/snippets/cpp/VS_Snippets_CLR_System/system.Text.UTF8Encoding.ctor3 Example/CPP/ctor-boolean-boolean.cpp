
// <Snippet1>
using namespace System;
using namespace System::Text;

void ShowArray(Array^ theArray)
{
   for each (Byte b in theArray) {
      Console::Write( "{0:X2} ", b);
   }
   Console::WriteLine();
}

int main()
{
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   UTF8Encoding^ utf8ThrowException = gcnew UTF8Encoding(false,true);
   
   // This array contains two high surrogates in a row (\uD801, \uD802).
   array<Char>^chars = {'a','b','c',L'\xD801',L'\xD802','d'};
   
   // The following method call will not throw an exception.
   array<Byte>^bytes = utf8->GetBytes( chars );
   ShowArray( bytes );
   Console::WriteLine();
   
   try {
      
      // The following method call will throw an exception.
      bytes = utf8ThrowException->GetBytes( chars );
   }
   catch (EncoderFallbackException^ e ) {
            Console::WriteLine("{0} exception\nMessage:\n{1}",
                               e->GetType()->Name, e->Message);
   }

}

// </Snippet1>
