// <Snippet30>
using System;

[assembly:CLSCompliant(true)]

public class Number<T> where T : struct
{
   // use Double as the underlying type, since its range is a superset of
   // the ranges of all numeric types except BigInteger.
   protected double number;

   public Number(T value)
   {
      try {
         this.number = Convert.ToDouble(value);
      }
      catch (OverflowException e) {
         throw new ArgumentException("value is too large.", e);
      }
      catch (InvalidCastException e) {
         throw new ArgumentException("The value parameter is not numeric.", e);
      }
   }

   public T Add(T value)
   {
      return (T) Convert.ChangeType(number + Convert.ToDouble(value), typeof(T));
   }

   public T Subtract(T value)
   {
      return (T) Convert.ChangeType(number - Convert.ToDouble(value), typeof(T));
   }
}

public class FloatingPoint<T> : Number<T>
{
   public FloatingPoint(T number) : base(number)
   {
      if (typeof(float) == number.GetType() ||
          typeof(double) == number.GetType() ||
          typeof(decimal) == number.GetType())
         this.number = Convert.ToDouble(number);
      else
         throw new ArgumentException("The number parameter is not a floating-point number.");
   }
}
// The attempt to compile the example displays the following output:
//       error CS0453: The type 'T' must be a non-nullable value type in
//               order to use it as parameter 'T' in the generic type or method 'Number<T>'
// </Snippet30>

public class Example
{
   public static void Main()
   {
      Number<Byte> byt = new Number<Byte>(12);
      Console.WriteLine(byt.Add(12));

      Number<SByte> sbyt = new Number<SByte>(-3);
      Console.WriteLine(sbyt.Subtract(12));

      Number<ushort> ush = new Number<ushort>(16);
      Console.WriteLine(ush.Add((ushort)3));

      Number<double> dbl = new Number<double>(Math.PI);
      Console.WriteLine(dbl.Add(1.0));

      FloatingPoint<Single> sng = new FloatingPoint<float>(12.3f);
      Console.WriteLine(sng.Add(3.0f));

//       FloatingPoint<int> f2 = new FloatingPoint<int>(16);
//       Console.WriteLine(f2.Add(6));
   }
}
