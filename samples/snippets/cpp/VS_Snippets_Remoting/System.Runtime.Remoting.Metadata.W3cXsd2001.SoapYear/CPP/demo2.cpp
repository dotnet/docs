/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
///    23    #ctor(DateTime,int)

using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;
void Ctor1()
{
   //<snippet21>
   // Create a SoapYear object.
   SoapYear^ date = gcnew SoapYear;
   date->Value = DateTime::Now;
   Console::WriteLine( "The date is {0}.", date );
   //</snippet21>
}

void Ctor2()
{
   //<snippet22>
   // Create a SoapYear object.
   SoapYear^ date = gcnew SoapYear( DateTime::Now );
   Console::WriteLine( "The date is {0}.", date );
   //</snippet22>
}

void Ctor3()
{
   //<snippet23>
   // Create a SoapYear object with a positive sign.
   SoapYear^ date = gcnew SoapYear( DateTime::Now,1 );
   Console::WriteLine( "The date is {0}.", date );
   //</snippet23>
}

int main()
{
   Ctor1();
   Ctor2();
   Ctor3();
}
