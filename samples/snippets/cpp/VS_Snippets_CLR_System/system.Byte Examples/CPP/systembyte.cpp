using namespace System;

/// <summary>
/// Summary description for Class1.
/// </summary>
public ref class SystemByteExamples
{
private:
   Byte MemberByte;

public:
   // c'tor()
   SystemByteExamples()
   {
      MemberByte = 0;
   }

   // The following example demonstrates using the MinValue and MaxValue fields to
   //  determine whether an integer value falls within range of a byte.  If it does,
   //  the value is set.  If not, an error message is displayed.

   // MemberByte is assumed to exist as a class member

   //<Snippet1>
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
   //</Snippet1>

   // The following example converts the string representation of a byte
   //  into its actual numeric value.

   // MemberByte is assumed to exist as a class member

public:
   void ParseByte( String^ stringToConvert )
   {
      try
      {
         MemberByte = Byte::Parse( stringToConvert );
         Console::WriteLine(  "The MemberByte value is {0}", MemberByte.ToString() );
      }
      catch ( System::OverflowException^ e ) 
      {
         Console::WriteLine(  "Exception: {0}", e->Message );
      }
   }

   // The following example checks to see whether a byte passed in is
   //  greater than, less than, or equal to the member byte.

   // MemberByte is assumed to exist as a class member

   //<Snippet3>
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
   //</Snippet3>
};

void main()
{
   SystemByteExamples^ sbe = gcnew SystemByteExamples;
   Int32 numberToSet;
   Byte compareByte;
   String^ stringToConvert;

   numberToSet = 120;
   stringToConvert =  "200";
   compareByte = 201;

   sbe->MinMaxFields( numberToSet );
   sbe->ParseByte( stringToConvert );

   sbe->Compare( compareByte );
}
