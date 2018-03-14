
// <Snippet1>
using System;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable] public struct SignAndMagnitude
{
   public int Sign; 
   public byte[] Bytes;
}

public class Example
{
   public static void Main()
   {
      FileStream fs;
      BinaryFormatter formatter = new BinaryFormatter();

      BigInteger number = BigInteger.Pow(Int32.MaxValue, 20) * BigInteger.MinusOne;
      Console.WriteLine("The original value is {0}.", number);
      SignAndMagnitude sm = new SignAndMagnitude();
      sm.Sign = number.Sign;
      sm.Bytes = BigInteger.Abs(number).ToByteArray();
      
      // Serialize SignAndMagnitude value.
      fs = new FileStream(@".\data.bin", FileMode.Create);
      formatter.Serialize(fs, sm);
      fs.Close();
      
      // Deserialize SignAndMagnitude value.
      fs = new FileStream(@".\data.bin", FileMode.Open);
      SignAndMagnitude smRestored = (SignAndMagnitude) formatter.Deserialize(fs);
      fs.Close();
      BigInteger restoredNumber = new BigInteger(smRestored.Bytes); 
      restoredNumber *= sm.Sign; 
      Console.WriteLine("The deserialized value is {0}.", restoredNumber);      
   }
}
// The example displays the following output:
//    The original value is -4.3510823966323432743748744058E+186.
//    The deserialized value is -4.3510823966323432743748744058E+186.
// </Snippet1>