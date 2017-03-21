public:
   void CovertDoubleFloat( double doubleVal )
   {
      float floatVal = 0;
      
      // A conversion from Double to Single cannot overflow.
      floatVal = System::Convert::ToSingle( doubleVal );
      System::Console::WriteLine( " {0} as a float is {1}",
                                  doubleVal, floatVal );

      // A conversion from Single to Double cannot overflow.
      doubleVal = System::Convert::ToDouble( floatVal );
      System::Console::WriteLine( " {0} as a double is: {1}",
                                  floatVal, doubleVal );
   }