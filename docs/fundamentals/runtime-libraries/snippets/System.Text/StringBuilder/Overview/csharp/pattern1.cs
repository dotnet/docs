// <Snippet12>
using System;
using System.Text;

public class Example9
{
    public static void Main()
    {
        Random rnd = new Random();
        string[] tempF = { "47.6F", "51.3F", "49.5F", "62.3F" };
        string[] tempC = { "21.2C", "16.1C", "23.5C", "22.9C" };
        string[][] temps = { tempF, tempC };

        StringBuilder sb = new StringBuilder();
        var f = new StringBuilderFinder(sb, "F");
        var baseDate = new DateTime(2013, 5, 1);
        String[] temperatures = temps[rnd.Next(2)];
        bool isFahrenheit = false;
        foreach (var temperature in temperatures)
        {
            if (isFahrenheit)
                sb.AppendFormat("{0:d}: {1}\n", baseDate, temperature);
            else
                isFahrenheit = f.SearchAndAppend(String.Format("{0:d}: {1}\n",
                                                 baseDate, temperature));
            baseDate = baseDate.AddDays(1);
        }
        if (isFahrenheit)
        {
            sb.Insert(0, "Average Daily Temperature in Degrees Fahrenheit");
            sb.Insert(47, "\n\n");
        }
        else
        {
            sb.Insert(0, "Average Daily Temperature in Degrees Celsius");
            sb.Insert(44, "\n\n");
        }
        Console.WriteLine(sb.ToString());
    }
}

public class StringBuilderFinder
{
    private StringBuilder sb;
    private String text;

    public StringBuilderFinder(StringBuilder sb, String textToFind)
    {
        this.sb = sb;
        this.text = textToFind;
    }

    public bool SearchAndAppend(String stringToSearch)
    {
        sb.Append(stringToSearch);
        return stringToSearch.Contains(text);
    }
}
// The example displays output similar to the following:
//    Average Daily Temperature in Degrees Celsius
//    
//    5/1/2013: 21.2C
//    5/2/2013: 16.1C
//    5/3/2013: 23.5C
//    5/4/2013: 22.9C
// </Snippet12>
