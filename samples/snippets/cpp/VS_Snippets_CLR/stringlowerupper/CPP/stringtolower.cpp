
//<snippet1>
using namespace System;
using namespace System::Collections;
int main()
{
   array<String^>^info = {"Name","Title","Age","Location","Gender"};
   Console::WriteLine( "The initial values in the array are:" );
   IEnumerator^ myEnum = info->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( s );
   }

   Console::WriteLine( " {0}The lowercase of these values is:", Environment::NewLine );
   IEnumerator^ myEnum1 = info->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum1->Current);
      Console::WriteLine( s->ToLower() );
   }

   Console::WriteLine( " {0}The uppercase of these values is:", Environment::NewLine );
   IEnumerator^ myEnum2 = info->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum2->Current);
      Console::WriteLine( s->ToUpper() );
   }
}
// The example displays the following output:
//       The initial values in the array are:
//       Name
//       Title
//       Age
//       Location
//       Gender
//       
//       The lowercase of these values is:
//       name
//       title
//       age
//       location
//       gender
//       
//       The uppercase of these values is:
//       NAME
//       TITLE
//       AGE
//       LOCATION
//       GENDER
//</snippet1>
