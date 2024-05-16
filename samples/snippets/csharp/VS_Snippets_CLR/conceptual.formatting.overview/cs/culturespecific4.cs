// <Snippet20>
using System.Globalization;

public class Example7
{
    public static void Main()
    {
        double value = 1043.62957;
        string[] cultureNames = { "en-US", "en-GB", "ru", "fr" };

        foreach (string? name in cultureNames)
        {
            NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture(name).NumberFormat;
            Console.WriteLine("{0,-6} {1}", name + ":", value.ToString("N3", nfi));
        }
    }
}
// The example displays the following output:
//       en-US: 1,043.630
//       en-GB: 1,043.630
//       ru:    1 043,630
//       fr:    1 043,630
// </Snippet20>
