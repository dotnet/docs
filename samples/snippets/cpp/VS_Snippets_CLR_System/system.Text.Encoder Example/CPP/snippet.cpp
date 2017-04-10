
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

   Console::WriteLine( "\n" );
}

int main()
{
   
   // The characters to encode.
   
   // Pi
   // Sigma
   array<Char>^chars = {L'\u03a0',L'\u03a3',L'\u03a6',L'\u03a9'};
   
   // Encode characters using an Encoding Object*.
   Encoding^ encoding = Encoding::UTF7;
   Console::WriteLine( "Using Encoding\n--------------" );
   
   // Encode complete array for comparison.
   array<Byte>^allCharactersFromEncoding = encoding->GetBytes( chars );
   Console::WriteLine( "All characters encoded:" );
   ShowArray( allCharactersFromEncoding );
   
   // Encode characters, one-by-one.
   // The Encoding Object* will NOT maintain state between calls.
   array<Byte>^firstchar = encoding->GetBytes( chars, 0, 1 );
   Console::WriteLine( "First character:" );
   ShowArray( firstchar );
   array<Byte>^secondchar = encoding->GetBytes( chars, 1, 1 );
   Console::WriteLine( "Second character:" );
   ShowArray( secondchar );
   array<Byte>^thirdchar = encoding->GetBytes( chars, 2, 1 );
   Console::WriteLine( "Third character:" );
   ShowArray( thirdchar );
   array<Byte>^fourthchar = encoding->GetBytes( chars, 3, 1 );
   Console::WriteLine( "Fourth character:" );
   ShowArray( fourthchar );
   
   // Now, encode characters using an Encoder Object*.
   Encoder^ encoder = encoding->GetEncoder();
   Console::WriteLine( "Using Encoder\n-------------" );
   
   // Encode complete array for comparison.
   array<Byte>^allCharactersFromEncoder = gcnew array<Byte>(encoder->GetByteCount( chars, 0, chars->Length, true ));
   encoder->GetBytes( chars, 0, chars->Length, allCharactersFromEncoder, 0, true );
   Console::WriteLine( "All characters encoded:" );
   ShowArray( allCharactersFromEncoder );
   
   // Do not flush state; i.e. maintain state between calls.
   bool bFlushState = false;
   
   // Encode characters one-by-one.
   // By maintaining state, the Encoder will not store extra bytes in the output.
   array<Byte>^firstcharNoFlush = gcnew array<Byte>(encoder->GetByteCount( chars, 0, 1, bFlushState ));
   encoder->GetBytes( chars, 0, 1, firstcharNoFlush, 0, bFlushState );
   Console::WriteLine( "First character:" );
   ShowArray( firstcharNoFlush );
   array<Byte>^secondcharNoFlush = gcnew array<Byte>(encoder->GetByteCount( chars, 1, 1, bFlushState ));
   encoder->GetBytes( chars, 1, 1, secondcharNoFlush, 0, bFlushState );
   Console::WriteLine( "Second character:" );
   ShowArray( secondcharNoFlush );
   array<Byte>^thirdcharNoFlush = gcnew array<Byte>(encoder->GetByteCount( chars, 2, 1, bFlushState ));
   encoder->GetBytes( chars, 2, 1, thirdcharNoFlush, 0, bFlushState );
   Console::WriteLine( "Third character:" );
   ShowArray( thirdcharNoFlush );
   
   // Must flush state on last call to GetBytes().
   bFlushState = true;
   array<Byte>^fourthcharNoFlush = gcnew array<Byte>(encoder->GetByteCount( chars, 3, 1, bFlushState ));
   encoder->GetBytes( chars, 3, 1, fourthcharNoFlush, 0, bFlushState );
   Console::WriteLine( "Fourth character:" );
   ShowArray( fourthcharNoFlush );
}

/* This code example produces the following output.

Using Encoding
--------------
All characters encoded:
[43][65][54][65][68][111][119][79][109][65][54][107][45]

First character:
[43][65][54][65][45]

Second character:
[43][65][54][77][45]

Third character:
[43][65][54][89][45]

Fourth character:
[43][65][54][107][45]

Using Encoder
-------------
All characters encoded:
[43][65][54][65][68][111][119][79][109][65][54][107][45]

First character:
[43][65][54]

Second character:
[65][68][111]

Third character:
[119][79][109]

Fourth character:
[65][54][107][45]


*/
// </Snippet1>
