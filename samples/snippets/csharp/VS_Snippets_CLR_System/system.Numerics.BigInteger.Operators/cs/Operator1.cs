using System;
using System.Numerics;

public class Class1
{
   public static void Main()
   {
      BitwiseAnd();
      BitwiseOr();
      Decrement();
      EqualsInt641();
      EqualsInt642();
      EqualsUInt641();
      EqualsUInt642();
      BitwiseXOr();
      GreaterThan64B();
      GreaterThanB64();
      GreaterThanBU64();
      GreaterThanU64B();
      GreaterThanOrEqual64B();
      GreaterThanOrEqualB64();
      GreaterThanOrEqualBU64();
      GreaterThanOrEqualU64B();
      Inequality64B();
      InequalityB64();
      InequalityBU64();
      InequalityU64B();
      LeftShift();
      LeftShiftManually();
      LessThan64B();
      LessThanB64();
      LessThanBU64();
      LessThanU64B();
      LessThanOrEqual64B();
      LessThanOrEqualB64();
      LessThanOrEqualBU64();
      LessThanOrEqualU64B();
   }

   private static void BitwiseAnd()
   {
      // <Snippet1>
      BigInteger number1 = BigInteger.Add(Int64.MaxValue, Int32.MaxValue);
      BigInteger number2 = BigInteger.Pow(Byte.MaxValue, 10);
      BigInteger result = number1 & number2;
      // </Snippet1>
   }

   private static void BitwiseOr()
   {
      // <Snippet2>
      BigInteger number1  = BigInteger.Parse("10343901200000000000");
      BigInteger number2  = Byte.MaxValue;
      BigInteger result  = number1 | number2;
      // </Snippet2>
   }

   private static void Decrement()
   {
      // <Snippet3>
      BigInteger number1 = BigInteger.Pow(Int32.MaxValue, 2);
      number1 = BigInteger.Subtract(number1, BigInteger.One);
      // </Snippet3>
   }
   private static void EqualsInt641()
   {
      // <Snippet4>
      BigInteger bigNumber = BigInteger.Pow(2, 63);
      long number = Int64.MaxValue;
      if (number == bigNumber)
      {
         // Do something...
      }
      // </Snippet4>
   }
   
   private static void EqualsInt642()
   {
      // <Snippet5>
      BigInteger bigNumber = BigInteger.Pow(2, 63);
      long number = Int64.MaxValue;
      if (bigNumber == number)
      {
         // Do something...
      }   
      // </Snippet5>
   }

   private static void EqualsUInt641()
   {
      // <Snippet6>
      BigInteger bigNumber = BigInteger.Pow(2, 63) - BigInteger.One;
      ulong uNumber = Int64.MaxValue & 0x7FFFFFFFFFFFFFFF;
      if (bigNumber == uNumber)
      {
         // Do something...
      }
      // </Snippet6>
   }

   private static void EqualsUInt642()
   {
      // <Snippet7>
      BigInteger bigNumber = BigInteger.Pow(2, 63) - BigInteger.One;
      ulong uNumber = Int64.MaxValue & 0x7FFFFFFFFFFFFFFF;
      if (uNumber == bigNumber)
      {
         // Do something...
      }
      // </Snippet7>
   }

   private static void BitwiseXOr()
   {
      // <Snippet8>
      BigInteger number1 = BigInteger.Pow(2, 127);
      BigInteger number2 = BigInteger.Multiply(163, 124);
      BigInteger result = number1 ^ number2;
      // </Snippet8>  
      Console.WriteLine("XOR: " + result.ToString());    
   }

   private static void GreaterThan64B()
   {
      // <Snippet9>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 4);
      long number = Int64.MaxValue;
      if (number > bigNumber) {
         // Do something;
      }
      // </Snippet9>
   }

   // Snipppet10: calling op_GreaterThan(Int64, BigInteger) directly is
   // not supported.
   
   private static void GreaterThanB64()
   {
      // <Snippet11>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 4);
      long number = Int64.MaxValue;
      if (bigNumber > number) {
         // Do something;
      }
      // </Snippet11>
   }

   // Snipppet12: calling op_GreaterThan(BigInteger, Int64) directly is
   // not supported.
   
   private static void GreaterThanBU64()
   {
      // <Snippet13>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 2);
      ulong number = UInt64.MaxValue;
      if (bigNumber > number) {
         // Do something
      }
      // </Snippet13>
   }

   private static void GreaterThanU64B()
   {
      // <Snippet15>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 2);
      ulong number = UInt64.MaxValue;
      if (number > bigNumber) {
         // Do something
      }
      // </Snippet15>
   }

   private static void GreaterThanOrEqual64B()
   {
      // <Snippet17>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 4);
      long number = Int64.MaxValue;
      if (number >= bigNumber) {
         // Do something;
      }
      // </Snippet17>
   }
   
   private static void GreaterThanOrEqualB64()
   {
      // <Snippet19>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 4);
      long number = Int64.MaxValue;
      if (bigNumber >= number) {
         // Do something;
      }
      // </Snippet19>
   }
   
   private static void GreaterThanOrEqualBU64()
   {
      // <Snippet21>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 2);
      ulong number = UInt64.MaxValue;
      if (bigNumber >= number) {
         // Do something
      }
      // </Snippet21>
   }
   
   private static void GreaterThanOrEqualU64B()
   {
      // <Snippet23>
      BigInteger bigNumber = BigInteger.Pow(Int32.MaxValue, 2);
      ulong number = UInt64.MaxValue;
      if (number >= bigNumber) {
         // Do something
      }
      // </Snippet23>
   }

   private static void Inequality64B()
   {
      // <Snippet25>
      BigInteger bigNumber = BigInteger.Pow(2, 63);
      long number = Int64.MaxValue;
      if (number != bigNumber)
      {
         // Do something...
      }
      // </Snippet25>
   }

   private static void InequalityB64()
   {
      // <Snippet26>
      BigInteger bigNumber = BigInteger.Pow(2, 63);
      long number = Int64.MaxValue;
      if (bigNumber != number)
      {
         // Do something...
      }   
      // </Snippet26>
   }
   
   private static void InequalityBU64()
   {
      // <Snippet27>
      BigInteger bigNumber = BigInteger.Pow(2, 63) - BigInteger.One;
      ulong uNumber = Int64.MaxValue & 0x7FFFFFFFFFFFFFFF;
      if (bigNumber != uNumber)
      {
         // Do something...
      }
      // </Snippet27>
   }
   
   private static void InequalityU64B()
   {
      // <Snippet28>
      BigInteger bigNumber = BigInteger.Pow(2, 63) - BigInteger.One;
      ulong uNumber = Int64.MaxValue & 0x7FFFFFFFFFFFFFFF;
      if (uNumber != bigNumber)
      {
         // Do something...
      }
      // </Snippet28>      
   }

   private static void LeftShift()
   {
      // <Snippet29>
      BigInteger number = BigInteger.Parse("-9047321678449816249999312055");
      Console.WriteLine("Shifting {0} left by:", number);
      for (int ctr = 0; ctr <= 16; ctr++)
      {
         BigInteger newNumber = number << ctr;
         Console.WriteLine(" {0,2} bits: {1,35} {2,30}", 
                           ctr, newNumber, newNumber.ToString("X"));
      }
      // The example displays the following output:
      //    Shifting -9047321678449816249999312055 left by:
      //      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
      //      1 bits:      -18094643356899632499998624110       C588763A1ADE0FA5983F7692
      //      2 bits:      -36189286713799264999997248220       8B10EC7435BC1F4B307EED24
      //      3 bits:      -72378573427598529999994496440      F1621D8E86B783E9660FDDA48
      //      4 bits: -1.4475714685519705999998899288E+29      E2C43B1D0D6F07D2CC1FBB490
      //      5 bits: -2.8951429371039411999997798576E+29      C588763A1ADE0FA5983F76920
      //      6 bits: -5.7902858742078823999995597152E+29      8B10EC7435BC1F4B307EED240
      //      7 bits:  -1.158057174841576479999911943E+30     F1621D8E86B783E9660FDDA480
      //      8 bits: -2.3161143496831529599998238861E+30     E2C43B1D0D6F07D2CC1FBB4900
      //      9 bits: -4.6322286993663059199996477722E+30     C588763A1ADE0FA5983F769200
      //     10 bits: -9.2644573987326118399992955443E+30     8B10EC7435BC1F4B307EED2400
      //     11 bits: -1.8528914797465223679998591089E+31    F1621D8E86B783E9660FDDA4800
      //     12 bits: -3.7057829594930447359997182177E+31    E2C43B1D0D6F07D2CC1FBB49000
      //     13 bits: -7.4115659189860894719994364355E+31    C588763A1ADE0FA5983F7692000
      //     14 bits: -1.4823131837972178943998872871E+32    8B10EC7435BC1F4B307EED24000
      //     15 bits: -2.9646263675944357887997745742E+32   F1621D8E86B783E9660FDDA48000
      //     16 bits: -5.9292527351888715775995491484E+32   E2C43B1D0D6F07D2CC1FBB490000      
      // </Snippet29>
   }
   
   private static void LeftShiftManually()
   {
      // <Snippet30>
      BigInteger number = BigInteger.Parse("-9047321678449816249999312055");
      Console.WriteLine("Shifting {0} left by:", number);
      for (int ctr = 0; ctr <= 16; ctr++)
      {
         BigInteger newNumber = BigInteger.Multiply(number, BigInteger.Pow(2, ctr));
         Console.WriteLine(" {0,2} bits: {1,35} {2,30}", 
                           ctr, newNumber, newNumber.ToString("X"));
      }
      // The example displays the following output:
      //    Shifting -9047321678449816249999312055 left by:
      //      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
      //      1 bits:      -18094643356899632499998624110       C588763A1ADE0FA5983F7692
      //      2 bits:      -36189286713799264999997248220       8B10EC7435BC1F4B307EED24
      //      3 bits:      -72378573427598529999994496440      F1621D8E86B783E9660FDDA48
      //      4 bits: -1.4475714685519705999998899288E+29      E2C43B1D0D6F07D2CC1FBB490
      //      5 bits: -2.8951429371039411999997798576E+29      C588763A1ADE0FA5983F76920
      //      6 bits: -5.7902858742078823999995597152E+29      8B10EC7435BC1F4B307EED240
      //      7 bits:  -1.158057174841576479999911943E+30     F1621D8E86B783E9660FDDA480
      //      8 bits: -2.3161143496831529599998238861E+30     E2C43B1D0D6F07D2CC1FBB4900
      //      9 bits: -4.6322286993663059199996477722E+30     C588763A1ADE0FA5983F769200
      //     10 bits: -9.2644573987326118399992955443E+30     8B10EC7435BC1F4B307EED2400
      //     11 bits: -1.8528914797465223679998591089E+31    F1621D8E86B783E9660FDDA4800
      //     12 bits: -3.7057829594930447359997182177E+31    E2C43B1D0D6F07D2CC1FBB49000
      //     13 bits: -7.4115659189860894719994364355E+31    C588763A1ADE0FA5983F7692000
      //     14 bits: -1.4823131837972178943998872871E+32    8B10EC7435BC1F4B307EED24000
      //     15 bits: -2.9646263675944357887997745742E+32   F1621D8E86B783E9660FDDA48000
      //     16 bits: -5.9292527351888715775995491484E+32   E2C43B1D0D6F07D2CC1FBB490000      
      // </Snippet30>
   }

   private static void LessThan64B()
   {
      // <Snippet31>
      BigInteger number = BigInteger.Parse("9801324316220166912");
      if (Int64.MaxValue < number)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet31>
   } 

   private static void LessThanB64()
   {
      // <Snippet33>
      BigInteger number = BigInteger.Parse("9801324316220166912");
      if (number < Int64.MaxValue)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet33>
   } 
   
   private static void LessThanBU64()
   {
      // <Snippet35>
      BigInteger number = BigInteger.Parse("19801324316220166912");
      if (number < UInt64.MaxValue)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet35>
   } 

   private static void LessThanU64B()
   {
      // <Snippet37>
      BigInteger number = BigInteger.Parse("9801324316220166912");
      if (UInt64.MaxValue < number)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet37>
   } 

   private static void LessThanOrEqual64B()
   {
      // <Snippet39>
      BigInteger number = BigInteger.Parse("9801324316220166912");
      if (Int64.MaxValue <= number)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet39>
   } 

   private static void LessThanOrEqualB64()
   {
      // <Snippet41>
      BigInteger number = BigInteger.Parse("9801324316220166912");
      if (number <= Int64.MaxValue)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet41>
   } 
   
   private static void LessThanOrEqualBU64()
   {
      // <Snippet43>
      BigInteger number = BigInteger.Parse("19801324316220166912");
      if (number <= UInt64.MaxValue)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet43>
   } 

   private static void LessThanOrEqualU64B()
   {
      // <Snippet45>
      BigInteger number = BigInteger.Parse("9801324316220166912");
      if (UInt64.MaxValue <= number)
      {
         // Do something.
      }
      else
      {
         // Do something else.
      }      
      // </Snippet45>
   }

}
