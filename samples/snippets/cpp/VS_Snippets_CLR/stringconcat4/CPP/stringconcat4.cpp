
//<snippet1>
using namespace System;
int main()
{
   
   // we want to simply quickly add this person's name together
   String^ fName = "Simon";
   String^ mName = "Jake";
   String^ lName = "Harrows";
   
   // because we want a name to appear with a space in between each name, 
   // put a space on the front of the middle, and last name, allowing for
   // the fact that a space may already be there
   mName = String::Concat(  " ", mName->Trim() );
   lName = String::Concat(  " ", lName->Trim() );
   
   // this line simply concatenates the two strings
   Console::WriteLine( "Welcome to this page, '{0}'!", String::Concat( String::Concat( fName, mName ), lName ) );
}
// The example displays the following output:
//        Welcome to this page, 'Simon Jake Harrows'!
//</snippet1>
