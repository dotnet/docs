   // Create a SoapYear object.
   SoapYear^ date = gcnew SoapYear;
   date->Value = DateTime::Now;
   Console::WriteLine( "The date is {0}.", date );