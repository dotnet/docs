
// This example demonstrates the StringBuilder.AppendFormat method
//<snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Globalization;
void Show( StringBuilder^ sbs )
{
   Console::WriteLine( sbs );
   sbs->Length = 0;
}

int main()
{
   StringBuilder^ sb = gcnew StringBuilder;
   int var1 = 111;
   float var2 = 2.22F;
   String^ var3 = "abcd";
   array<Object^>^var4 = {3,4.4,(Char)'X'};
   Console::WriteLine();
   Console::WriteLine( "StringBuilder.AppendFormat method:" );
   sb->AppendFormat( "1) {0}", var1 );
   Show( sb );
   sb->AppendFormat( "2) {0}, {1}", var1, var2 );
   Show( sb );
   sb->AppendFormat( "3) {0}, {1}, {2}", var1, var2, var3 );
   Show( sb );
   sb->AppendFormat( "4) {0}, {1}, {2}", var4 );
   Show( sb );
   CultureInfo^ ci = gcnew CultureInfo( "es-ES",true );
   array<Object^>^temp1 = {var2};
   sb->AppendFormat( ci, "5) {0}", temp1 );
   Show( sb );
}

/*
This example produces the following results:

StringBuilder.AppendFormat method:
1) 111
2) 111, 2.22
3) 111, 2.22, abcd
4) 3, 4.4, X
5) 2,22
*/
//</snippet1>
