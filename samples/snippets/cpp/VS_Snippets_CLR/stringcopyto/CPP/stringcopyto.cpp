
//<snippet1>
using namespace System;
int main()
{
   
   // Embed an array of characters in a string
   String^ strSource = "changed";
   array<Char>^destination = {'T','h','e',' ','i','n','i','t','i','a','l',' ','a','r','r','a','y'};
   
   // Print the char array
   Console::WriteLine( destination );
   
   // Embed the source string in the destination string
   strSource->CopyTo( 0, destination, 4, strSource->Length );
   
   // Print the resulting array
   Console::WriteLine( destination );
   strSource = "A different string";
   
   // Embed only a section of the source string in the destination
   strSource->CopyTo( 2, destination, 3, 9 );
   
   // Print the resulting array
   Console::WriteLine( destination );
}
// The example displays the following output:
//       The initial array
//       The changed array
//       Thedifferentarray
//</snippet1>
