// <Snippet1>
using System;

public struct Complex
{
   public double re, im;

   public override bool Equals(Object obj)
   {
      return obj is Complex && this == (Complex)obj;
   }

   public override int GetHashCode()
   {
      return Tuple.Create(re, im).GetHashCode();
   }

   public static bool operator ==(Complex x, Complex y)
   {
      return x.re == y.re && x.im == y.im;
   }

   public static bool operator !=(Complex x, Complex y)
   {
      return !(x == y);
   }

    public override String ToString()
    {
       return String.Format("({0}, {1})", re, im);
    }
}

class MyClass
{
  public static void Main()
  {
    Complex cmplx1, cmplx2;

    cmplx1.re = 4.0;
    cmplx1.im = 1.0;

    cmplx2.re = 2.0;
    cmplx2.im = 1.0;

    Console.WriteLine($"{cmplx1} <> {cmplx2}: {cmplx1 != cmplx2}");
    Console.WriteLine("{0} = {1}: {2}", cmplx1, cmplx2, cmplx1.Equals(cmplx2));

    cmplx2.re = 4.0;

    Console.WriteLine($"{cmplx1} = {cmplx2}: {cmplx1 == cmplx2}");
    Console.WriteLine("{0} = {1}: {2}", cmplx1, cmplx2, cmplx1.Equals(cmplx2));
  }
}
// The example displays the following output:
//       (4, 1) <> (2, 1): True
//       (4, 1) = (2, 1): False
//       (4, 1) = (4, 1): True
//       (4, 1) = (4, 1): True
// </Snippet1>
