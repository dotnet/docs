   // Create a SoapMonth object.
   SoapMonth^ month = gcnew SoapMonth;
   month->Value = DateTime::Now;
   Console::WriteLine( "The month is {0}.", month );