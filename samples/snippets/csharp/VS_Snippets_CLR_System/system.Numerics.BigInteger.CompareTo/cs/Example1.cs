
// <Snippet1>
using System;
using System.Collections.Generic;
using System.Numerics;

public struct StarInfo : IComparable<StarInfo>
{
   // Define constructors.
   public StarInfo(string name, double lightYears)
   {
      this.Name = name;
      
      // Calculate distance in miles from light years.
      this.Distance = (BigInteger) Math.Round(lightYears * 5.88e12);
   }

   public StarInfo(string name, BigInteger distance)
   {
      this.Name = name;
      this.Distance = distance;
   }

   // Define public fields.
   public string Name;
   public BigInteger Distance;

   // Display name of star and its distance in parentheses.
   public override string ToString()
   {
      return String.Format("{0,-10} ({1:N0})", this.Name, this.Distance);
   }

   // Compare StarInfo objects by their distance from Earth.
   public int CompareTo(StarInfo other)
   {
      return this.Distance.CompareTo(other.Distance);
   }
}
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      StarInfo star;
      List<StarInfo> stars = new List<StarInfo>();

      star = new StarInfo("Sirius", 8.6d);
      stars.Add(star);
      star = new StarInfo("Rigel", 1400d);
      stars.Add(star);
      star = new StarInfo("Castor", 49d);
      stars.Add(star);
      star = new StarInfo("Antares", 520d);
      stars.Add(star);

      stars.Sort();

      foreach (StarInfo sortedStar in stars)
         Console.WriteLine(sortedStar);
   }
}
// The example displays the following output:
//       Sirius     (50,568,000,000,000)
//       Castor     (288,120,000,000,000)
//       Antares    (3,057,600,000,000,000)
//       Rigel      (8,232,000,000,000,000)
// </Snippet2>