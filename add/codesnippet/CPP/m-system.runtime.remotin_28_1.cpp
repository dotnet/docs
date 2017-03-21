   // Create a SoapMonthDay object.
   SoapMonthDay^ monthDay = gcnew SoapMonthDay;
   monthDay->Value = DateTime::Now;
   Console::WriteLine( L"The SoapMonthDay object is {0}.", monthDay );