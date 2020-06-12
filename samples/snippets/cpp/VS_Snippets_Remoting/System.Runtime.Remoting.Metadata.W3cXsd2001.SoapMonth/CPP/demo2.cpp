/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)

using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

void Ctor1()
{
   //<snippet21>
   // Create a SoapMonth object.
   SoapMonth^ month = gcnew SoapMonth;
   month->Value = DateTime::Now;
   Console::WriteLine( "The month is {0}.", month );
   //</snippet21>
}

void Ctor2()
{
   //<snippet22>
   // Create a SoapMonth object.
   SoapMonth^ month = gcnew SoapMonth( DateTime::Now );
   Console::WriteLine( "The month is {0}.", month );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}
