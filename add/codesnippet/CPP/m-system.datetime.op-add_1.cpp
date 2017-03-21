   System::DateTime dTime( 1980, 8, 5 );
   
   // tSpan is 17 days, 4 hours, 2 minutes and 1 second.
   System::TimeSpan tSpan( 17, 4, 2, 1 );
   
   // Result gets 8/22/1980 4:02:01 AM.
   System::DateTime result = dTime + tSpan;