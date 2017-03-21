   // Create a SoapDay object.
   SoapDay^ day = gcnew SoapDay;
   day->Value = DateTime::Now;
   Console::WriteLine( "The day is {0}.", day );