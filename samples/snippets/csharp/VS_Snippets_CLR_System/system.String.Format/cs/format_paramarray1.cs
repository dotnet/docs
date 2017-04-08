// <Snippet10>
using System;

public class CityInfo
{
   public CityInfo(String name, int population, Decimal area, int year)
   {
      this.Name = name;
      this.Population = population;
      this.Area = area;
      this.Year = year;
   }
   
   public readonly String Name; 
   public readonly int Population;
   public readonly Decimal Area;
   public readonly int Year;
}

public class Example
{
   public static void Main()
   {
      CityInfo nyc2010 = new CityInfo("New York", 8175133, 302.64m, 2010);
      ShowPopulationData(nyc2010);
      CityInfo sea2010 = new CityInfo("Seattle", 608660, 83.94m, 2010);      
      ShowPopulationData(sea2010); 
   }

   private static void ShowPopulationData(CityInfo city)
   {
      object[] args = { city.Name, city.Year, city.Population, city.Area };
      String result = String.Format("{0} in {1}: Population {2:N0}, Area {3:N1} sq. feet", 
                                    args);
      Console.WriteLine(result); 
   }
}
// The example displays the following output:
//       New York in 2010: Population 8,175,133, Area 302.6 sq. feet
//       Seattle in 2010: Population 608,660, Area 83.9 sq. feet
// </Snippet10>