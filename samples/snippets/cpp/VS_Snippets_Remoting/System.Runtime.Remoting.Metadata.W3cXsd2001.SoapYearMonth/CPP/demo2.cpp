/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
///    23    #ctor(DateTime,int)

using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;
void Ctor1()
{
   //<snippet21>
   // Create a SoapYearMonth object.
   SoapYearMonth^ year = gcnew SoapYearMonth;
   year->Value = DateTime::Now;
   Console::WriteLine( "The year is {0}.", year );
   //</snippet21>
}

void Ctor2()
{
   //<snippet22>
   // Create a SoapYearMonth object.
   SoapYearMonth^ year = gcnew SoapYearMonth( DateTime::Now );
   Console::WriteLine( "The year is {0}.", year );
   //</snippet22>
}

void Ctor3()
{
   //<snippet23>
   // Create a SoapYearMonth object with a positive sign.
   SoapYearMonth^ year = gcnew SoapYearMonth( DateTime::Now,1 );
   Console::WriteLine( "The year is {0}.", year );
   //</snippet23>
}

int main()
{
   Ctor1();
   Ctor2();
   Ctor3();
}
