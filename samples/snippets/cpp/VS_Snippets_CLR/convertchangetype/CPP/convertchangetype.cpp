
//<snippet1>
using namespace System;

int main()
{
   Double d = -2.345;
   int i =  *safe_cast<Int32^>(Convert::ChangeType( d, int::typeid ));
   Console::WriteLine( "The double value {0} when converted to an int becomes {1}", d, i );
   String^ s = "12/12/98";
   DateTime dt =  *safe_cast<DateTime^>(Convert::ChangeType( s, DateTime::typeid ));
   Console::WriteLine( "The string value {0} when converted to a Date becomes {1}", s, dt );
}
//</snippet1>
