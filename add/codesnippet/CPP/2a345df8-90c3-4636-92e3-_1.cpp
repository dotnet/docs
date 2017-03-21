   // Create a SoapYearMonth object with a positive sign.
   SoapYearMonth^ year = gcnew SoapYearMonth( DateTime::Now,1 );
   Console::WriteLine( "The year is {0}.", year );