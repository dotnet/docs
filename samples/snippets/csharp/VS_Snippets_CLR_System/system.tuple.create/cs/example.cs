using System;

class Example
{
    static void Main(string[] args)
    {
        // <Snippet19>
        var from1980 = Tuple.Create(1203339, 1027974, 951270);
        var from1910 = new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>> 
            (465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980);
        var population = new Tuple<string, int, int, int, int, int, int,
            Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>> 
            ("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910);
        // </Snippet19>
        Console.WriteLine("Population of {0}", population.Item1);
        Console.WriteLine();
        Console.WriteLine("{0,5}  {1,14}  {2,10}", "Year", "Population", "Change");

        int year = population.Item2;
        ShowPopulation(year, population.Item3);
        year += 10;
        ShowPopulationChange(year, population.Item4, population.Item3);
        year += 10;
        ShowPopulationChange(year, population.Item5, population.Item4);
        year += 10;
        ShowPopulationChange(year, population.Item6, population.Item5);
        year += 10;
        ShowPopulationChange(year, population.Item7, population.Item6);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item1, population.Item7);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item2, population.Rest.Item1);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item3, population.Rest.Item2);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item4, population.Rest.Item3);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item5, population.Rest.Item4);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item6, population.Rest.Item5);
        year += 10;
        ShowPopulationChange(year, population.Rest.Item7, population.Rest.Item6);
        year += 10;
        ShowPopulationChange(year, population.Rest.Rest.Item1, population.Rest.Item7);
        year += 10;
        ShowPopulationChange(year, population.Rest.Rest.Item2, population.Rest.Rest.Item1);
        year += 10;
        ShowPopulationChange(year, population.Rest.Rest.Item3, population.Rest.Rest.Item2);
    }

    private static void ShowPopulationChange(int year, int newPopulation, int oldPopulation)
    {
        Console.WriteLine("{0,5}  {1,14:N0}  {2,10:P2}", year, newPopulation,
                          ((double)(newPopulation - oldPopulation) / oldPopulation) / 10);
    }

    private static void ShowPopulation(int year, int newPopulation)
    {
        Console.WriteLine("{0,5}  {1,14:N0}  {2,10:P2}", year, newPopulation, "n/a");
    }
}
// The example displays the following output:
//
//    Population of Detroit
//    Year      Population      Change
//    1860          45,619         n/a
//    1870          79,577      7.44 %
//    1880         116,340      4.62 %
//    1890         205,876      7.70 %
//    1900         285,704      3.88 %
//    1910         465,766      6.30 %
//    1920         993,078     11.32 %
//    1930       1,568,622      5.80 %
//    1940       1,623,452      0.35 %
//    1950       1,849,568      1.39 %
//    1960       1,670,144     -0.97 %
//    1970       1,511,462     -0.95 %
//    1980       1,203,339     -2.04 %
//    1990       1,027,974     -1.46 %
//    2000         951,270     -0.75 %
