   // Create a SoapYearMonth object.
   SoapYearMonth^ year = gcnew SoapYearMonth;
   year->Value = DateTime::Now;
   Console::WriteLine( "The year is {0}.", year );