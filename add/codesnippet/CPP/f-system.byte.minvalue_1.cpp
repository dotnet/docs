public:
   void MinMaxFields( Int32 numberToSet )
   {
      if ( numberToSet <= (Int32)Byte::MaxValue && numberToSet >= (Int32)Byte::MinValue )
      {
         
         // You must explicitly convert an integer to a byte.
         MemberByte = (Byte)numberToSet;
         
         // Displays MemberByte using the ToString() method.
         Console::WriteLine(  "The MemberByte value is {0}", MemberByte.ToString() );
      }
      else
      {
         Console::WriteLine(  "The value {0} is outside of the range of possible Byte values", numberToSet.ToString() );
      }
   }