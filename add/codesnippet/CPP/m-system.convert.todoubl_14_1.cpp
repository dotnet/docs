public:
   void ConvertDoubleInt( double doubleVal )
   {
      int intVal = 0;
      
      // Double to int conversion can overflow.
      try
      {
         intVal = System::Convert::ToInt32( doubleVal );
         System::Console::WriteLine( " {0} as an int is: {1}",
         doubleVal, intVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in double-to-int conversion." );
      }
      
      // Int to double conversion cannot overflow.
      doubleVal = System::Convert::ToDouble( intVal );
      System::Console::WriteLine( " {0} as a double is: {1}",
         intVal, doubleVal );
   }