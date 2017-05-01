// ChangeType01.cpp : main project file.

// <Snippet2>
using namespace System;

void main()
{
   Double d = -2.345;
   int i = (int) Convert::ChangeType(d, TypeCode::Int32);

   Console::WriteLine("The Double {0} when converted to an Int32 is {1}", d, i);

   String^ s = "12/12/2009";
   DateTime dt = (DateTime)Convert::ChangeType(s, DateTime::typeid);

   Console::WriteLine("The String {0} when converted to a Date is {1}", s, dt);        
}
// The example displays the following output:
//    The Double -2.345 when converted to an Int32 is -2
//    The String 12/12/2009 when converted to a Date is 12/12/2009 12:00:00 AM
// </Snippet2>