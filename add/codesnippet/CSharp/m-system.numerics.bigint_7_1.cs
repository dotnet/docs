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