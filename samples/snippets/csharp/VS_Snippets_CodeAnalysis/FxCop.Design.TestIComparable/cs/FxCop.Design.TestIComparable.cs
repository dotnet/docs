using System.Globalization;
//<Snippet1>
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
//</Snippet1>

namespace DesignLibrary
{
   // Valid ratings are between A and C.
   // A is the highest rating; it is greater than any other valid rating.
   // C is the lowest rating; it is less than any other valid rating.

   public class RatingInformation :IComparable 
   {
      private string rating;

      public RatingInformation (string s)
      {
         string v = s.ToUpper(CultureInfo.InvariantCulture);
         if (v.CompareTo("C") > 0 || v.CompareTo("A") < 0 || v.Length != 1)
         {
            throw new ArgumentException("Invalid rating value was specified.");
         }
         rating = v;
      }

      public int CompareTo ( object obj)
      {
         if (!(obj is RatingInformation))
         {
            throw new ArgumentException(
               "A RatingInformation object is required for comparison.");
         }
         // Ratings compare opposite to normal string order,
         // so reverse the value returned by String.CompareTo.
         return -1 * this.rating.CompareTo(((RatingInformation)obj).rating);
      }

      public string Rating 
      {
         get { return rating;}
      }

      // Omitting Equals violates rule: OverrideMethodsOnComparableTypes.
      public override bool Equals (Object obj)
      {
         if (!(obj is RatingInformation))
            return false;
         return (this.CompareTo(obj)== 0);
      }  

      // Omitting getHashCode violates rule: OverrideGetHashCodeOnOverridingEquals.
      public override int GetHashCode ()
      {
         char [] c = this.Rating.ToCharArray();
         return (int) c[0];
      }  
      // Omitting any of the following operator overloads 
      // violates rule: OverrideMethodsOnComparableTypes.
      public static bool operator == (RatingInformation r1, RatingInformation r2)
      {
         return r1.Equals(r2);
      }  
      public static bool operator != (RatingInformation r1, RatingInformation r2)
      {
        return !(r1==r2);
      }  
      public static bool operator < (RatingInformation r1, RatingInformation r2)
      {
         return (r1.CompareTo(r2) < 0);
      }  
      public static bool operator > (RatingInformation r1, RatingInformation r2)
      {
         return (r1.CompareTo(r2) > 0);
      }  
   }
}