using System;
using System.Numerics;
using System.Windows.Forms;

public class BigIntExamples
{
   public static void Main()
   {
      BigIntExamples ex = new BigIntExamples();
         
      if (MessageBox.Show("Show constructors?", "BigInteger constructors", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
         ex.CreateBigIntegers();
      }
      if (MessageBox.Show("Show overloads of Byte constructor?", "Byte .ctor", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
         ex.CreatePositiveValueFromByteArray();
         ex.CreateNegativeValueFromByteArray();
      }
   
      if (MessageBox.Show("Create Through Operation", "Instantiate a BigInteger", MessageBoxButtons.YesNo) == DialogResult.Yes)
         ex.CreateThroughOperation();
   
      if (MessageBox.Show("Call CompareTo to compare values?", "CompareTo", MessageBoxButtons.YesNo) == DialogResult.Yes)
         ex.CallCompareTo();     
         
      if (MessageBox.Show("Multiply if overflow?", "Multiply", MessageBoxButtons.YesNo) == DialogResult.Yes)
         ex.MultiplyIfOverflow();
      
      if (MessageBox.Show("Compare distances between stars for equality?", "Star Distances", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
         StarDistances stars = new StarDistances();
         stars.CompareStarDistances();
      }   
         
      if (MessageBox.Show("Compute greatest common denominators?", "GCD", MessageBoxButtons.YesNo) == DialogResult.Yes)
         ex.GCD();
         
      if (MessageBox.Show("Perform basic mathematical operations?", "Star Distances", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
         ex.Multiply();
         ex.Add();
         ex.Divide();
         ex.Subtract();
         ex.Decrement();
         ex.Equality();
         ex.GreaterThan();
         ex.GreaterThanOrEqualTo();
         ex.Increment();
         ex.Inequality();
         ex.LessThan();
         ex.LessThanOrEqualTo();
         ex.Modulus();
      }   
      
      if (MessageBox.Show("Illustrate ModPow?", "ModPow Method", MessageBoxButtons.YesNo) == DialogResult.Yes)
         ex.ShowModPow();   
            
      if (MessageBox.Show("Illustrate exponentiation?", "Pow Method", MessageBoxButtons.YesNo) == DialogResult.Yes)
         ex.ShowExponentiation();    
   }

   private void CreateBigIntegers()
   {
      // <Snippet3>
      BigInteger bigIntFromDouble = new BigInteger(179032.6541);
      BigInteger bigIntFromInt64 = new BigInteger(934157136952);
      // </Snippet3>
      Console.WriteLine(bigIntFromDouble);
      Console.WriteLine(bigIntFromInt64);
      // <Snippet4>
      BigInteger assignedFromLong = 6315489358112;

      BigInteger assignedFromDouble = (BigInteger) 179032.6541D;
      BigInteger assignedFromDecimal = (BigInteger) 64312.65m;   
      // </Snippet4>
      Console.WriteLine(assignedFromLong);
      Console.WriteLine(assignedFromDecimal);
      Console.WriteLine(assignedFromDouble);
      
      // <Snippet34>
      decimal fractionalNumber = 13456.92m;
      BigInteger wholeNumber = new BigInteger(fractionalNumber);
      Console.WriteLine(wholeNumber);        // Displays 13456
      // </Snippet34>
      
      // <Snippet35>
      // Create a BigInteger from a large double value
      double impreciseNumber = -6e35;
      BigInteger preciseNumber = new BigInteger(impreciseNumber);
      Console.WriteLine(impreciseNumber.ToString("F"));
      Console.WriteLine(preciseNumber);
      impreciseNumber++;
      preciseNumber++;
      Console.WriteLine(impreciseNumber.ToString("F"));
      Console.WriteLine(preciseNumber);
      // The example displays the following output to the console:
      //       -600000000000000000000000000000000000.00
      //       -599999999999999981180196647507853312
      //       -600000000000000000000000000000000000.00
      //       -599999999999999981180196647507853311
      // </Snippet35>
      
      // <Snippet36>
      // Create a BigInteger from a large negatie float value
      float negativeFloat = Single.MinValue;
      BigInteger negativeNumber = new BigInteger(negativeFloat);
      Console.WriteLine(negativeFloat.ToString("F"));
      Console.WriteLine(negativeNumber);
      negativeFloat++;
      negativeNumber++;
      Console.WriteLine(negativeFloat.ToString("F"));
      Console.WriteLine(negativeNumber);
      // The example displays the following output to the console:
      //       -340282300000000000000000000000000000000.00
      //       -340282346638528859811704183484516925440
      //       -340282300000000000000000000000000000000.00
      //       -340282346638528859811704183484516925439      
      // </Snippet36>
   }
   
   private void CreatePositiveValueFromByteArray()
   {
      // <Snippet1>
      byte[] byteArray = { 5, 4, 3, 2, 1};
      BigInteger newBigInt = new BigInteger(byteArray);
      Console.WriteLine("Value of newBigInt is {0} (or 0x{0:x} hex)", newBigInt);    
      //
      // The code produces the following output:
      //
      //    Value of newBigInt is 4328719365 (or 0x102030405 hex)   
      // </Snippet1>
   }
   
   private void CreateNegativeValueFromByteArray()
   {
     // <Snippet2>
     byte[] byteArray = { 5, 4, 3, 2, 1};
     BigInteger newBigInt = new BigInteger(byteArray);
     Console.WriteLine("Value of newBigInt is {0} (or 0x{0:x} hex)", newBigInt);    
     // </Snippet2>
   }

   private void CreateThroughOperation()
   {
      // <Snippet33>
      long longValue = 987654321;
      BigInteger number = BigInteger.Pow(longValue, 3);
      Console.WriteLine(number);        // Displays 963418328693495609108518161
      // </Snippet33>      
   }
     
   private void CallCompareTo()
   {
      // <Snippet6>
      BigInteger bigIntegerInstance = BigInteger.Parse("3221123045552");

      byte byteInteger = 16;
      sbyte sByteInteger = -16;
      short shortInteger = 1233;      
      ushort uShortInteger = 1233;
      int normalInteger = -12233;
      uint normalUInteger = 12233;
      long longInteger = 12382222;
      ulong uLongInteger = 1238222;
      float singleValue = -123.49951F;
      double doubleValue = 123.49951992;
      decimal decimalValue = 1234.556M;

      Console.WriteLine("Comparison of {0} with {1}: {2}", 
                        bigIntegerInstance, byteInteger, 
                        bigIntegerInstance.CompareTo(byteInteger));
      Console.WriteLine("Comparison of {0} with {1}: {2}", 
                        bigIntegerInstance, sByteInteger, 
                        bigIntegerInstance.CompareTo(sByteInteger)); 
      Console.WriteLine("Comparison of {0} with {1}: {2}",
                        bigIntegerInstance, shortInteger, 
                        bigIntegerInstance.CompareTo(shortInteger)); 
      Console.WriteLine("Comparison of {0} with {1}: {2}", 
                        bigIntegerInstance, uShortInteger, 
                        bigIntegerInstance.CompareTo(uShortInteger)); 
      Console.WriteLine("Comparison of {0} with {1}: {2}", 
                        bigIntegerInstance, normalInteger, 
                        bigIntegerInstance.CompareTo(normalInteger));
      Console.WriteLine("Comparison of {0} with {1}: {2}", 
                        bigIntegerInstance, normalUInteger,
                        bigIntegerInstance.CompareTo(normalUInteger)); 
      Console.WriteLine("Comparison of {0} with {1}: {2}", 
                        bigIntegerInstance, longInteger, 
                        bigIntegerInstance.CompareTo(longInteger)); 
      Console.WriteLine("Comparison of {0} with {1}: {2}",
                        bigIntegerInstance, uLongInteger, 
                        bigIntegerInstance.CompareTo(uLongInteger));
      try
      {
         Console.WriteLine("Comparison of {0} with {1}: {2}", 
                           bigIntegerInstance, singleValue, 
                           bigIntegerInstance.CompareTo(singleValue));
      }
      catch (ArgumentException)
      {
         Console.WriteLine("Unable to compare {0} with a {1} value of {2}", 
                           bigIntegerInstance, singleValue.GetType().Name, 
                           singleValue);
      }
                            
      try
      {
         Console.WriteLine("Comparison of {0} with {1}: {2}", 
                           bigIntegerInstance, doubleValue, 
                           bigIntegerInstance.CompareTo(doubleValue));
      }                     
      catch (ArgumentException)
      {
         Console.WriteLine("Unable to compare {0} with a {1} value of {2}", 
                           bigIntegerInstance, doubleValue.GetType().Name, 
                           doubleValue);
      }
                            
      try
      {
         Console.WriteLine("Comparison of {0} with {1}: {2}", 
                           bigIntegerInstance, decimalValue, 
                           bigIntegerInstance.CompareTo(decimalValue));
      }
      catch (ArgumentException)
      {
         Console.WriteLine("Unable to compare {0} with a {1} value of {2}", 
                           bigIntegerInstance, decimalValue.GetType().Name, 
                           decimalValue);
      } 
      //
      // The code produces the following output to the console:
      //
      // Comparison of 3221123045552 with 16: 1
      // Comparison of 3221123045552 with -16: 1
      // Comparison of 3221123045552 with 1233: 1
      // Comparison of 3221123045552 with 1233: 1
      // Comparison of 3221123045552 with -12233: 1
      // Comparison of 3221123045552 with 12233: 1
      // Comparison of 3221123045552 with 12382222: 1
      // Comparison of 3221123045552 with 1238222: 1
      // Unable to compare 3221123045552 with a Single value of -123.4995
      // Unable to compare 3221123045552 with a Double value of 123.49951992
      // Unable to compare 3221123045552 with a Decimal value of 1234.556                              
      // </Snippet6>
   }

   private void MultiplyIfOverflow()
   {
      // <Snippet7> 
      long number1 = 1234567890;
      long number2 = 9876543210;
      try
      {
         long product; 
         product = checked(number1 * number2);
      }
      catch (OverflowException)
      {
         BigInteger product;
         product = BigInteger.Multiply(number1, number2);
         Console.WriteLine(product.ToString());
         }   
      // </Snippet7>
   }

   private void CompareDivisionResults(BigInteger dividend, BigInteger divisor)
   {
      // <Snippet8>
      BigInteger remainder = 0;
      BigInteger quotient;
      quotient = BigInteger.DivRem(dividend, divisor, out remainder);
      Console.WriteLine("DivRem({0}, {1}) returns {2} with a remainder of {3}", 
                        dividend, 
                        divisor, 
                        quotient, 
                        remainder);
      Console.WriteLine("Result of division: {0}", 
                        BigInteger.Divide(dividend, divisor));
      Console.WriteLine("Remainder after division: {0}", 
                        BigInteger.Remainder(dividend, divisor));
      // </Snippet8>                                          
   }

   private void GCD()
   {
      // <Snippet10>
      BigInteger n1 = BigInteger.Pow(154382190, 3);
      BigInteger n2 = BigInteger.Multiply(1643590, 166935);
      try
      {
         Console.WriteLine("The greatest common divisor of {0} and {1} is {2}.", 
                           n1, n2, BigInteger.GreatestCommonDivisor(n1, n2));
      }
      catch (ArgumentOutOfRangeException e)
      {
         Console.WriteLine("Unable to calculate the greatest common divisor:");
         Console.WriteLine("   {0} is an invalid value for {1}", 
                           e.ActualValue, e.ParamName);
      }
      // </Snippet10>
   }

   private void ShowModPow()
   {
      // <Snippet15>
      BigInteger number = 10;
      int exponent = 3;
      BigInteger modulus = 30;
      Console.WriteLine("({0}^{1}) Mod {2} = {3}", 
                        number, exponent, modulus, 
                        BigInteger.ModPow(number, exponent, modulus));   // Displays 10
      // </Snippet15>
   }
 
    private void ShowNegationMethods()
    {
      // <Snippet16> 
      BigInteger number = 12645002;
      
      Console.WriteLine(BigInteger.Negate(number));        // Displays -12645002
      Console.WriteLine(-number);                          // Displays -12645002
      Console.WriteLine(number * BigInteger.MinusOne);     // Displays -12645002
      // </Snippet16> 
   }

   private void Multiply()
   {
      // <Snippet11>
      BigInteger num1 = 1000456321;
      BigInteger num2 = 90329434;
      BigInteger result = num1 * num2;
      // </Snippet11>      
   }

   private void Add()
   {
      // <Snippet12>
      BigInteger num1 = 1000456321;
      BigInteger num2 = 90329434;
      BigInteger sum = num1 + num2;
      // </Snippet12>      
   }

   private void Divide()
   {
      // <Snippet13>
      BigInteger num1 = 100045632194;
      BigInteger num2 = 90329434;
      BigInteger quotient = num1 / num2;
      // </Snippet13>      
   }

   private void Subtract()
   {
      // <Snippet14>
      BigInteger num1 = 100045632194;
      BigInteger num2 = 90329434;
      BigInteger result = num1 - num2;
      // </Snippet14>      
   }

   private void Decrement()
   {
      // <Snippet17>
      BigInteger number = 93843112;
      Console.WriteLine(--number);               // Displays 93843111
      // </Snippet17>
   }

   private void Equality()
   {
      Console.WriteLine("Equality:");
      // <Snippet19>
      BigInteger number1 = 945834723;
      BigInteger number2 = 345145625;
      BigInteger number3 = 945834723; 
      Console.WriteLine(number1 == number2);             // Displays False
      Console.WriteLine(number1 == number3);             // Displays True
      // </Snippet19>
      Console.WriteLine();
   }

   private void GreaterThan()
   {
      Console.WriteLine("Greater Than:");
      // <Snippet20>
      BigInteger number1 = 945834723;
      BigInteger number2 = 345145625;
      BigInteger number3 = 945834724;
      Console.WriteLine(number1 > number2);              // Displays True
      Console.WriteLine(number1 > number3);              // Displays False
      // </Snippet20>
      Console.WriteLine();
   }  
   
   private void GreaterThanOrEqualTo()
   {
      Console.WriteLine("Greater Than Or Equal To:");
      // <Snippet22>
      BigInteger number1 = 945834723;
      BigInteger number2 = 345145625;
      BigInteger number3 = 945834724;
      BigInteger number4 = 945834723;
      Console.WriteLine(number1 >= number2);             // Displays True
      Console.WriteLine(number1 >= number3);             // Displays False
      Console.WriteLine(number1 >= number4);             // Displays True
      // </Snippet22>
      Console.WriteLine();
   }  
   
   private void Increment()
   {
      Console.WriteLine("\nIncrement operation:");
      // <Snippet24>
      BigInteger number = 93843112;
      Console.WriteLine(++number);               // Displays 93843113
      // </Snippet24>
   }

   private void Inequality()
   {
      Console.WriteLine("\nInequality:");
      // <Snippet26>
      BigInteger number1 = 945834723;
      BigInteger number2 = 345145625;
      BigInteger number3 = 945834723; 
      Console.WriteLine(number1 != number2);             // Displays True
      Console.WriteLine(number1 != number3);             // Displays False
      // </Snippet26>
      Console.WriteLine();
   }

   private void LessThan()
   {
      Console.WriteLine("Less Than:");
      // <Snippet27>
      BigInteger number1 = 945834723;
      BigInteger number2 = 345145625;
      BigInteger number3 = 945834724;
      Console.WriteLine(number1 < number2);              // Displays False
      Console.WriteLine(number1 < number3);              // Displays True
      // </Snippet27>
      Console.WriteLine();
   }  
   
   private void LessThanOrEqualTo()
   {
      Console.WriteLine("\nLess Than Or Equal To:");
      // <Snippet29>
      BigInteger number1 = 945834723;
      BigInteger number2 = 345145625;
      BigInteger number3 = 945834724;
      BigInteger number4 = 945834723;
      Console.WriteLine(number1 <= number2);             // Displays False
      Console.WriteLine(number1 <= number3);             // Displays True
      Console.WriteLine(number1 <= number4);             // Displays True
      // </Snippet29>
      Console.WriteLine();
   }  

   private void Modulus()
   {
      Console.Write("\nModulus operation: ");
      // <Snippet31>
      BigInteger num1 = 100045632194;
      BigInteger num2 = 90329434;
      BigInteger remainder = num1 % num2;
      Console.WriteLine(remainder);           // Displays 50948756
      // </Snippet31>      
   }

   private void ShowExponentiation()
   {
      // <Snippet32>
      BigInteger numericBase = 3040506;
      for (int ctr = 0; ctr <= 10; ctr++)
      {
         Console.WriteLine(BigInteger.Pow(numericBase, ctr));
      }
      // 
      // The example produces the following output to the console:
      //
      // 1
      // 3040506
      // 9244676736036
      // 28108495083977874216
      // 85464047953805230420993296
      // 259853950587832525926412642447776
      // 790087495886008322074413197838317614656
      // 2402265771766383619317185774506591737267255936
      // 7304103492650319992835619250501939216711515276943616
      // 22208170494024253840136657344866649200046662468638726109696
      // 67524075636103707946458547477011116092637077515870858568887346176     //
      // </Snippet32>
   }
}

// <Snippet9>
public class StarDistances
{
   private const long LIGHT_YEAR = 5878625373183;

   public void CompareStarDistances()
   {
      BigInteger altairDistance = 17 * LIGHT_YEAR;
      BigInteger epsilonIndiDistance = 12 * LIGHT_YEAR;
      BigInteger ursaeMajoris47Distance = 46 * LIGHT_YEAR;
      BigInteger tauCetiDistance = 12 * LIGHT_YEAR;
      long procyon2Distance = 12 * LIGHT_YEAR;
      object wolf424ABDistance = 14 * LIGHT_YEAR;
      
      Console.WriteLine("Approx. equal distances from Epsilon Indi to:");
      Console.WriteLine("   Altair: {0}", 
                        epsilonIndiDistance.Equals(altairDistance));
      Console.WriteLine("   Ursae Majoris 47: {0}", 
                        epsilonIndiDistance.Equals(ursaeMajoris47Distance));
      Console.WriteLine("   TauCeti: {0}", 
                        epsilonIndiDistance.Equals(tauCetiDistance));
      Console.WriteLine("   Procyon 2: {0}", 
                        epsilonIndiDistance.Equals(procyon2Distance));
      Console.WriteLine("   Wolf 424 AB: {0}", 
                        epsilonIndiDistance.Equals(wolf424ABDistance));
   }
}
// </Snippet9>
