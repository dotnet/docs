/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

static void Ctor1()
{
   //<snippet21>
   // Create a SoapMonthDay object.
   SoapMonthDay^ monthDay = gcnew SoapMonthDay;
   monthDay->Value = DateTime::Now;
   Console::WriteLine( L"The SoapMonthDay object is {0}.", monthDay );
   //</snippet21>
}

static void Ctor2()
{
   //<snippet22>
   // Create a SoapMonthDay object.
   SoapMonthDay^ monthDay = gcnew SoapMonthDay( DateTime::Now );
   Console::WriteLine( L"The SoapMonthDay object is {0}.", monthDay );
   //</snippet22>
}

int main()
{
   Ctor1();
   Ctor2();
}

