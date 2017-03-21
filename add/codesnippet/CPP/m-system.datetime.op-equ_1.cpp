   System::DateTime april19( 2001, 4, 19 );
   System::DateTime otherDate( 1991, 6, 5 );
   
   // areEqual gets false.
   bool areEqual = april19 == otherDate;

   otherDate = DateTime( 2001, 4, 19 );
   // areEqual gets true.
   areEqual = april19 == otherDate;