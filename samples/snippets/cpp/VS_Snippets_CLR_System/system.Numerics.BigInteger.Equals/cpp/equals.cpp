// Equals.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet1>
#using <System.Numerics.dll>

using namespace System;
using namespace System::Numerics;

void main()
{
   BigInteger bigIntValue;

   Byte byteValue = 16;
   bigIntValue = BigInteger(byteValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      byteValue.GetType()->Name, byteValue,
      bigIntValue.Equals((Int64)byteValue));

   SByte sbyteValue = -16;
   bigIntValue = BigInteger(sbyteValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      sbyteValue.GetType()->Name, sbyteValue,
      bigIntValue.Equals((Int64)sbyteValue));

   Int16 shortValue = 1233;
   bigIntValue = BigInteger(shortValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      shortValue.GetType()->Name, shortValue,
      bigIntValue.Equals((Int64)shortValue));

   UInt16 ushortValue = 64000;
   bigIntValue = BigInteger(ushortValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      ushortValue.GetType()->Name, ushortValue,
      bigIntValue.Equals((Int64)ushortValue));

   int intValue = -1603854;
   bigIntValue = BigInteger(intValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      intValue.GetType()->Name, intValue,
      bigIntValue.Equals((Int64)intValue));

   UInt32 uintValue = 1223300;
   bigIntValue = BigInteger(uintValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      uintValue.GetType()->Name, uintValue,
      bigIntValue.Equals((Int64)uintValue));

   Int64 longValue = -123822229012;
   bigIntValue = BigInteger(longValue);
   Console::WriteLine("{0} {1} = {2} {3} : {4}",
      bigIntValue.GetType()->Name, bigIntValue,
      longValue.GetType()->Name, longValue,
      bigIntValue.Equals((Int64)longValue));
}
/* 
The example displays output like the following:
      BigInteger 16 = Byte 16 : True
      BigInteger -16 = SByte -16 : True
      BigInteger 1233 = Int16 1233 : True
      BigInteger 64000 = UInt16 64000 : True
      BigInteger -1603854 = Int32 -1603854 : True
      BigInteger 1223300 = UInt32 1223300 : True
      BigInteger -123822229012 = Int64 -123822229012 : True
*/
// </Snippet1>

