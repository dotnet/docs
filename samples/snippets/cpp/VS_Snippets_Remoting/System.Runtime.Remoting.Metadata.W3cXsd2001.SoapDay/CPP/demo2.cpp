/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)

using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

void Ctor1()
{
   //<snippet21>
   // Create a SoapDay object.
   SoapDay^ day = gcnew SoapDay;
   day->Value = DateTime::Now;
   Console::WriteLine( "The day is {0}.", day );
   //</snippet21>
}

void Ctor2()
{
   //<snippet22>
   // Create a SoapDay object.
   SoapDay^ day = gcnew SoapDay( DateTime::Now );
   Console::WriteLine( "The day is {0}.", day );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}
