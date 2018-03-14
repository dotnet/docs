
//<Snippet1>
using namespace System;
public ref class TestGetElementType{};

int main()
{
   array<Int32>^array = {1,2,3};
   Type^ t = array->GetType();
   Type^ t2 = t->GetElementType();
   Console::WriteLine( "The element type of {0} is {1}.", array, t2 );
   TestGetElementType^ newMe = gcnew TestGetElementType;
   t = newMe->GetType();
   t2 = t->GetElementType();
   Console::WriteLine( "The element type of {0} is {1}.", newMe, t2 == nullptr ? "null" : t2->ToString() );
}

/* This code produces the following output:

The element type of System.Int32[] is System.Int32.
The element type of TestGetElementType is null.
 */
//</Snippet1>
