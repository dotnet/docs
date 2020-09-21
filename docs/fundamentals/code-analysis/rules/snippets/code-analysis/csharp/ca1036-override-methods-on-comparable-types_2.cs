using System;

namespace DesignLibrary
{
    public class Test
    {
       public static void Main(string [] args)
       {
          if (args.Length < 2)
          {
             Console.WriteLine ("usage - TestRatings  string 1 string2");
             return;
          }
          RatingInformation r1 = new RatingInformation(args[0]) ;
          RatingInformation r2 = new RatingInformation( args[1]);
          string answer;
    
          if (r1.CompareTo(r2) > 0)
             answer = "greater than";
          else if (r1.CompareTo(r2) < 0)
             answer = "less than";
          else
             answer = "equal to";
    
          Console.WriteLine("{0} is {1} {2}", r1.Rating, answer, r2.Rating);      
       }
    }
}