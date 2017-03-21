public:
   void Compare( Byte myByte )
   {
      Int32 myCompareResult;

      myCompareResult = MemberByte.CompareTo( myByte );

      if ( myCompareResult > 0 )
      {
         Console::WriteLine(  "{0} is less than the MemberByte value {1}", myByte.ToString(), MemberByte.ToString() );
      }
      else
      {
         if ( myCompareResult < 0 )
            Console::WriteLine(  "{0} is greater than the MemberByte value {1}", myByte.ToString(), MemberByte.ToString() );
         else
            Console::WriteLine(  "{0} is equal to the MemberByte value {1}", myByte.ToString(), MemberByte.ToString() );
      }
   }