// Convert.ToBoolean.cpp : main project file.

using namespace System;

void ToByte()
{
   // <Snippet12>
   array<Byte>^ bytes = gcnew array<Byte> { Byte::MinValue, 100, 200, Byte::MaxValue };
   bool result;
      
   for each (Byte byteValue in bytes)
   {
      result = Convert::ToBoolean(byteValue); 
      Console::WriteLine("{0,-5}  -->  {1}", byteValue, result);
   }           
   // The example displays the following output:
   //       0      -->  False
   //       100    -->  True
   //       200    -->  True
   //       255    -->  True
   // </Snippet12>   
}

void ToDecimal()
{
      // <Snippet2>
      array<Decimal>^ numbers = gcnew array<Decimal> { Decimal::MinValue, (Decimal) -12034.87, 
                                                       (Decimal) -100, (Decimal) 0, (Decimal) 300, 
                                                       (Decimal) 6790823.45, Decimal::MaxValue };
      bool result;
      
      for each (Decimal number in numbers)
      {
         result = Convert::ToBoolean(number); 
         Console::WriteLine("{0,-30}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -79228162514264337593543950335  -->  True
      //       -12034.87                       -->  True
      //       -100                            -->  True
      //       0                               -->  False
      //       300                             -->  True
      //       6790823.45                      -->  True
      //       79228162514264337593543950335   -->  True
      // </Snippet2>
}

void ToInt16()
{
   // <Snippet3>
   array<Int16>^ numbers = gcnew array<Int16> { Int16::MinValue, -10000, -154, 0, 216, 21453, 
                                          Int16::MaxValue };
   bool result;
      
   for each (Int16 number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-7:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -32,768  -->  True
   //       -10,000  -->  True
   //       -154     -->  True
   //       0        -->  False
   //       216      -->  True
   //       21,453   -->  True
   //       32,767   -->  True
   // </Snippet3>
}

void ToInt32()
{
   // <Snippet4>
   array<int>^ numbers = gcnew array<int> { Int32::MinValue, -201649, -68, 0, 612, 4038907, 
                                            Int32::MaxValue };
   bool result;
      
   for each (int number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-15:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -2,147,483,648   -->  True
   //       -201,649         -->  True
   //       -68              -->  True
   //       0                -->  False
   //       612              -->  True
   //       4,038,907        -->  True
   //       2,147,483,647    -->  True
   // </Snippet4>
}

void ToInt64()
{
   // <Snippet5>
   array<Int64>^ numbers = gcnew array<Int64> { Int64::MinValue, -2016493, -689, 0, 6121, 
                                              403890774, Int64::MaxValue };
   bool result;
      
   for each (Int64 number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-26:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -9,223,372,036,854,775,808  -->  True
   //       -2,016,493                  -->  True
   //       -689                        -->  True
   //       0                           -->  False
   //       6,121                       -->  True
   //       403,890,774                 -->  True
   //       9,223,372,036,854,775,807   -->  True
   // </Snippet5>
}

void ToObject()
{
      // <Snippet11>
      array<Object^>^ objects = gcnew array<Object^> { 16.33, -24, 0, "12", "12.7", String::Empty, 
                                                      "1String", "True", "false", nullptr, 
                                                      gcnew System::Collections::ArrayList };
      
      for each (Object^ obj in objects)
      {
         Console::Write("{0,-40}  -->  ", 
                       obj == nullptr ? "null" :
                       String::Format("{0} ({1})", obj, obj->GetType()->Name));
         try {
            Console::WriteLine("{0}", Convert::ToBoolean((Object^) obj));
         }   
         catch (FormatException^) {
            Console::WriteLine("Bad Format");
         }   
         catch (InvalidCastException^) {
            Console::WriteLine("No Conversion");
         }   
      }     
      // The example displays the following output:
      //       16.33 (Double)                            -->  True
      //       -24 (Int32)                               -->  True
      //       0 (Int32)                                 -->  False
      //       12 (String)                               -->  Bad Format
      //       12.7 (String)                             -->  Bad Format
      //        (String)                                 -->  Bad Format
      //       1String (String)                          -->  Bad Format
      //       True (String)                             -->  True
      //       false (String)                            -->  False
      //       null                                      -->  False
      //       System.Collections.ArrayList (ArrayList)  -->  No Conversion
      // </Snippet11>
}

void ToSByte()
{
   // <Snippet6>
   array<SByte>^ numbers = gcnew array<SByte> { SByte::MinValue, -1, 0, 10, 100, SByte::MaxValue };
   bool result;
      
   for each (SByte number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-5}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -128   -->  True
   //       -1     -->  True
   //       0      -->  False
   //       10     -->  True
   //       100    -->  True
   //       127    -->  True
   // </Snippet6>
}

void ToSingle()
{
   // <Snippet7>
   array<float>^ numbers = gcnew array<float> { Single::MinValue, (float) -193.0012, (float) 20e-15f, 0, 
                                                (float) 10551e-10, (float) 100.3398, Single::MaxValue };
   bool result;
      
   for each (float number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-15}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       -3.402823E+38    -->  True
   //       -193.0012        -->  True
   //       2E-14            -->  True
   //       0                -->  False
   //       1.0551E-06       -->  True
   //       100.3398         -->  True
   //       3.402823E+38     -->  True
   // </Snippet7>
}

void ToUInt16()
{
   // <Snippet8>
   array<unsigned short>^ numbers = gcnew array<unsigned short> { UInt16::MinValue, 216, 21453, UInt16::MaxValue };
   bool result;
      
   for each (unsigned short number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-7:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       0        -->  False
   //       216      -->  True
   //       21,453   -->  True
   //       65,535   -->  True
   // </Snippet8>
}

void ToUInt32()
{
   // <Snippet9>
   array<UInt32>^ numbers = gcnew array<UInt32> { UInt32::MinValue, 612, 4038907, Int32::MaxValue };
   bool result;
      
   for each (unsigned int number in numbers)
   {
      result = Convert::ToBoolean(number);                                 
      Console::WriteLine("{0,-15:N0}  -->  {1}", number, result);
   }
   // The example displays the following output:
   //       0                -->  False
   //       612              -->  True
   //       4,038,907        -->  True
   //       2,147,483,647    -->  True
   // </Snippet9>
}

void ToUInt64()
{
      // <Snippet10>
      array<UInt64>^ numbers = gcnew array<UInt64> { UInt64::MinValue, 6121, 403890774, UInt64::MaxValue };
      bool result;
      
      for each (UInt64 number in numbers)
      {
         result = Convert::ToBoolean(number);                                 
         Console::WriteLine("{0,-26:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       0                           -->  False
      //       6,121                       -->  True
      //       403,890,774                 -->  True
      //       18,446,744,073,709,551,615  -->  True
      // </Snippet10>
}

void main()
{
   Console::WriteLine("ToByte:");
   ToByte();
   Console::WriteLine();

   Console::WriteLine("ToDecimal:");
   ToDecimal();
   Console::WriteLine();
   
   Console::WriteLine("ToInt16:");
   ToInt16();
   Console::WriteLine();
   
   Console::WriteLine("ToInt32:");
   ToInt32();
   Console::WriteLine();

   Console::WriteLine("ToInt64:");
   ToInt64();
   Console::WriteLine();

   Console::WriteLine("ToObject:");
   ToObject();
   Console::WriteLine();

   Console::WriteLine("ToSByte:");
   ToSByte();
   Console::WriteLine();

   Console::WriteLine("ToSingle:");
   ToSingle();
   Console::WriteLine();

   Console::WriteLine("ToUInt16:");
   ToUInt16();
   Console::WriteLine();

   Console::WriteLine("ToUInt32:");
   ToUInt32();
   Console::WriteLine();

   Console::WriteLine("ToUInt64:");
   ToUInt64();
   Console::WriteLine();

   Console::ReadLine();
}

