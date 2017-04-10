using System;
using System.Numerics;

public class Complex2
{
   double Real, Imaginary;
   
   public bool Equals(Complex2 value)
   {
      // <Snippet1>
      return this.Real.Equals(value) && this.Imaginary.Equals(value);      
      // </Snippet1>
   } 
   
   public override bool Equals(object value)
   {
      // <Snippet2>
      return this.Real.Equals(((Complex) value).Real) && 
             this.Imaginary.Equals(((Complex) value).Imaginary);
      // </Snippet2>
   }  

   public bool opEquality(Complex2 value )
   {
      // <Snippet3>
      return this.Real == value.Real && this.Imaginary == value.Imaginary;
      // </Snippet3>
   }
}

public class Example
{
   public static void Main()
   {


   }
}
