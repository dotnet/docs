/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
///    23    #ctor(DateTime,int)

using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

void Ctor1()
{
   //<snippet21>
   // Create a SoapDate object.
   SoapDate^ date = gcnew SoapDate;
   date->Value = DateTime::Now;
   Console::WriteLine( "The date is {0}.", date );
   //</snippet21>
}

void Ctor2()
{
   //<snippet22>
   // Create a SoapDate object.
   SoapDate^ date = gcnew SoapDate( DateTime::Now );
   Console::WriteLine( "The date is {0}.", date );
   //</snippet22>
}

void Ctor3()
{
   //<snippet23>
   // Create a SoapDate object with a positive sign.
   SoapDate^ date = gcnew SoapDate( DateTime::Now,1 );
   Console::WriteLine( "The date is {0}.", date );
   //</snippet23>
}

int main()
{
   Ctor1();
   Ctor2();
   Ctor3();
}
