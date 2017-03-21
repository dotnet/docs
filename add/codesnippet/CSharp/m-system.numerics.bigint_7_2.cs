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