   // Create a SoapTime object.
   SoapTime^ time = gcnew SoapTime;
   time->Value = DateTime::Now;
   Console::WriteLine( "The time is {0}.", time );