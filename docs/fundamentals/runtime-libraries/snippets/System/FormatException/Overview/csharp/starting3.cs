using System;
using System.Text;

class Example16
{
    public static void Main()
    {
        // <Snippet33>
        int[] years = { 2013, 2014, 2015 };
        int[] population = { 1025632, 1105967, 1148203 };
        var sb = new System.Text.StringBuilder();
        sb.Append(String.Format("{0,6} {1,15}\n\n", "Year", "Population"));
        for (int index = 0; index < years.Length; index++)
            sb.Append(String.Format("{0,6} {1,15:N0}\n", years[index], population[index]));

        Console.WriteLine(sb);

        // Result:
        //      Year      Population
        //
        //      2013       1,025,632
        //      2014       1,105,967
        //      2015       1,148,203
        // </Snippet33>
    }
}
