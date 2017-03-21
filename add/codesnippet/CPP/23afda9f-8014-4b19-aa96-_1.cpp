   // Create a SoapYear object with a positive sign.
   SoapYear^ date = gcnew SoapYear( DateTime::Now,1 );
   Console::WriteLine( "The date is {0}.", date );