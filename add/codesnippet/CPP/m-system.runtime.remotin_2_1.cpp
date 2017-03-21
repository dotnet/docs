   // Create a SoapDate object.
   SoapDate^ date = gcnew SoapDate;
   date->Value = DateTime::Now;
   Console::WriteLine( "The date is {0}.", date );