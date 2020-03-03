/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)

using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

void Ctor1()
{
   //<snippet21>
   // Create a SoapTime object.
   SoapTime^ time = gcnew SoapTime;
   time->Value = DateTime::Now;
   Console::WriteLine( "The time is {0}.", time );
   //</snippet21>
}

void Ctor2()
{
   //<snippet22>
   // Create a SoapTime object.
   SoapTime^ time = gcnew SoapTime( DateTime::Now );
   Console::WriteLine( "The time is {0}.", time );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}
