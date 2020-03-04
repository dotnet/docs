
// <snippet10>
using namespace System;
int main()
{
   String^ str =  "twain1 twain2";
   Console::WriteLine( Char::IsSeparator( 'a' ) ); // Output: "False"
   Console::WriteLine( Char::IsSeparator( str, 6 ) ); // Output: "True"
}

// </snippet10>
