// <Snippet1>
using System;

class Example
{
    static void Main(string[] args)
    {
        Tuple<int, int, int> from1980 = Tuple.Create(1203339, 1027974, 951270);
        var from1910 = new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>> 
            (465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980);
        var population = new Tuple<string, int, int, int, int, int, int,
            Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>> 
            ("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910);

        Console.WriteLine(population.ToString());
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
//   (Detroit, 1860, 45619, 79577, 116340, 205876, 285704, 465766, 993078, 
//    1568622, 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270)
// </Snippet1>
