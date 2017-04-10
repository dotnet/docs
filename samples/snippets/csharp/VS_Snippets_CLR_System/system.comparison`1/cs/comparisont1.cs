// <Snippet1>
using System;

public class CityInfo
{
   string cityName;
   string countryName;
   int pop2010;
   
   public CityInfo(string name, string country, int pop2010)
   {
      this.cityName = name;
      this.countryName = country;
      this.pop2010 = pop2010;
   }
   
   public string City
   { get { return this.cityName; } } 
   
   public string Country
   { get { return this.countryName; } }

   public int Population
   { get { return this.pop2010; } }
   
   public static int CompareByName(CityInfo city1, CityInfo city2)
   { 
      return String.Compare(city1.City, city2.City);
   }
   
   public static int CompareByPopulation(CityInfo city1, CityInfo city2)
   {
      return city1.Population.CompareTo(city2.Population);
   }
   
   public static int CompareByNames(CityInfo city1, CityInfo city2)
   {
      return String.Compare(city1.Country + city1.City, city2.Country + city2.City);
   }      
}

public class Example
{
   public static void Main()
   {
      CityInfo NYC = new CityInfo("New York City", "United States of America", 8175133 );
      CityInfo Det = new CityInfo("Detroit", "United States of America", 713777);
      CityInfo Paris = new CityInfo("Paris", "France",  2193031);
      CityInfo[] cities = { NYC, Det, Paris };
      // Display ordered array.
      DisplayArray(cities);
      
      // Sort array by city name.
      Array.Sort(cities, CityInfo.CompareByName);
      DisplayArray(cities);
      
      // Sort array by population.
      Array.Sort(cities, CityInfo.CompareByPopulation);
      DisplayArray(cities);
      
      // Sort array by country + city name.
      Array.Sort(cities, CityInfo.CompareByNames);
      DisplayArray(cities);
   }
   
   private static void DisplayArray(CityInfo[] cities)
   {
      Console.WriteLine("{0,-20} {1,-25} {2,10}", "City", "Country", "Population");
      foreach (var city in cities)
         Console.WriteLine("{0,-20} {1,-25} {2,10:N0}", city.City, 
                           city.Country, city.Population);

      Console.WriteLine();
   }
}
// The example displays the following output:
//     City                 Country                   Population
//     New York City        United States of America   8,175,133
//     Detroit              United States of America     713,777
//     Paris                France                     2,193,031
//     
//     City                 Country                   Population
//     Detroit              United States of America     713,777
//     New York City        United States of America   8,175,133
//     Paris                France                     2,193,031
//     
//     City                 Country                   Population
//     Detroit              United States of America     713,777
//     Paris                France                     2,193,031
//     New York City        United States of America   8,175,133
//     
//     City                 Country                   Population
//     Paris                France                     2,193,031
//     Detroit              United States of America     713,777
//     New York City        United States of America   8,175,133
// </Snippet1>
