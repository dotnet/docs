   // Parse an XSD duration to create a TimeSpan object.
   // This is a duration of 2 years, 3 months, 9 days, 12 hours,
   // 35 minutes, 20 seconds, and 10 milliseconds.
   String^ xsdDuration = L"P2Y3M9DT12H35M20.0100000S";
   TimeSpan timeSpan = SoapDuration::Parse( xsdDuration );
   Console::WriteLine( L"The time span contains {0} days.",
      timeSpan.Days );
   Console::WriteLine( L"The time span contains {0} hours.",
      timeSpan.Hours );
   Console::WriteLine( L"The time span contains {0} minutes.",
      timeSpan.Minutes );
   Console::WriteLine( L"The time span contains {0} seconds.",
      timeSpan.Seconds );