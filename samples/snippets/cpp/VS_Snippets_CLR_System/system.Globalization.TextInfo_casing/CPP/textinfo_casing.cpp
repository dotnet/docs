
// The following code example changes the casing of a String*.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Defines the String* with mixed casing.
   String^ myString = "wAr aNd pEaCe";
   
   // Creates a TextInfo based on the S"en-US" culture.
   CultureInfo^ MyCI = gcnew CultureInfo( "en-US",false );
   TextInfo^ myTI = MyCI->TextInfo;
   
   // Changes a String* to lowercase.
   Console::WriteLine( "\"{0}\" to lowercase: {1}", myString, myTI->ToLower( myString ) );
   
   // Changes a String* to uppercase.
   Console::WriteLine( "\"{0}\" to uppercase: {1}", myString, myTI->ToUpper( myString ) );
   
   // Changes a String* to titlecase.
   Console::WriteLine( "\"{0}\" to titlecase: {1}", myString, myTI->ToTitleCase( myString ) );
}

/*
This code produces the following output.

S"wAr aNd pEaCe" to lowercase: war and peace
S"wAr aNd pEaCe" to uppercase: WAR AND PEACE
S"wAr aNd pEaCe" to titlecase: War And Peace

*/
// </snippet1>
