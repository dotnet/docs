   // Parse an XSD gMonthDay to create a SoapMonthDay object.
   // Parse the representation for February 21, in the UTC+8 time zone.
   String^ xsdMonthDay = L"--02-21+08:00";
   SoapMonthDay^ monthDay = SoapMonthDay::Parse( xsdMonthDay );