// <Snippet1>
using System;

public class Class1
{
   public static void Main()
   {
      // Create five 8-tuple objects containing prime numbers.
      var prime1 = new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>> (2, 3, 5, 7, 11, 13, 17, 
                           new Tuple<Int32>(19));
      var prime2 = new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>> (23, 29, 31, 37, 41, 43, 47, 
                           new Tuple<Int32>(55));
      var prime3 = new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>> (3, 2, 5, 7, 11, 13, 17, 
                           new Tuple<Int32>(19)); 
      var prime4 = new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32, Int32>> (2, 3, 5, 7, 11, 13, 17, 
                           new Tuple<Int32, Int32>(19, 23));
      var prime5 = new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>> (2, 3, 5, 7, 11, 13, 17, 
                           new Tuple<Int32>(19));
      Console.WriteLine("{0} = {1} : {2}", prime1, prime2, prime1.Equals(prime2));
      Console.WriteLine("{0} = {1} : {2}", prime1, prime3, prime1.Equals(prime3));
      Console.WriteLine("{0} = {1} : {2}", prime1, prime4, prime1.Equals(prime4));
      Console.WriteLine("{0} = {1} : {2}", prime1, prime5, prime1.Equals(prime5));
   }
}
// The example displays the following output:
//    (2, 3, 5, 7, 11, 13, 17, 19) = (23, 29, 31, 37, 41, 43, 47, 55) : False
//    (2, 3, 5, 7, 11, 13, 17, 19) = (3, 2, 5, 7, 11, 13, 17, 19) : False
//    (2, 3, 5, 7, 11, 13, 17, 19) = (2, 3, 5, 7, 11, 13, 17, 19, 23) : False
//    (2, 3, 5, 7, 11, 13, 17, 19) = (2, 3, 5, 7, 11, 13, 17, 19) : True
// </Snippet1>