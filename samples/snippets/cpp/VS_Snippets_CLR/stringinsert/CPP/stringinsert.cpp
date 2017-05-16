
// <Snippet1>
using namespace System;

int main()
{
   String^ animal1 = "fox";
   String^ animal2 = "dog";
   String^ strTarget = String::Format( "The {0} jumped over the {1}.", animal1, animal2 );
   Console::WriteLine( "The original string is:{0}{1}{0}", Environment::NewLine, strTarget );
   Console::Write( "Enter an adjective (or group of adjectives) to describe the {0}: ==> ", animal1 );
   String^ adj1 = Console::ReadLine();
   Console::Write( "Enter an adjective (or group of adjectives) to describe the {0}: ==> ", animal2 );
   String^ adj2 = Console::ReadLine();
   adj1 = String::Concat( adj1->Trim(), " " );
   adj2 = String::Concat( adj2->Trim(), " " );
   strTarget = strTarget->Insert( strTarget->IndexOf( animal1 ), adj1 );
   strTarget = strTarget->Insert( strTarget->IndexOf( animal2 ), adj2 );
   Console::WriteLine( " {0}The final string is: {0} {1}", Environment::NewLine, strTarget );
}
// Output from the example might appear as follows:
//       The original string is:
//       The fox jumped over the dog.
//       
//       Enter an adjective (or group of adjectives) to describe the fox: ==> bold
//       Enter an adjective (or group of adjectives) to describe the dog: ==> lazy
//       
//       The final string is:
//       The bold fox jumped over the lazy dog.
// </Snippet1>
