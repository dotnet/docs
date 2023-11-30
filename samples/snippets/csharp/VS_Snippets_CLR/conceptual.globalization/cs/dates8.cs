// <Snippet11>
using System;
using System.IO;

public class Example9
{
    public static void Main9()
    {
        // Serialize a date.
        DateTime dateOriginal = new DateTime(2023, 3, 30, 18, 0, 0);
        dateOriginal = DateTime.SpecifyKind(dateOriginal, DateTimeKind.Local);

        // Serialize the date in string form.
        if (!File.Exists("DateInfo2.dat"))
        {
            StreamWriter sw = new StreamWriter("DateInfo2.dat");
            sw.Write("{0:o}|{1:r}|{1:u}", dateOriginal,
                                          dateOriginal.ToUniversalTime());
            sw.Close();
        }

        // Restore the date from string values.
        StreamReader sr = new StreamReader("DateInfo2.dat");
        string datesToSplit = sr.ReadToEnd();
        string[] dateStrings = datesToSplit.Split('|');
        for (int ctr = 0; ctr < dateStrings.Length; ctr++)
        {
            DateTime newDate = DateTime.Parse(dateStrings[ctr]);
            if (ctr == 1)
            {
                Console.WriteLine($"'{dateStrings[ctr]}' --> {newDate} {newDate.Kind}");
            }
            else
            {
                DateTime newLocalDate = newDate.ToLocalTime();
                Console.WriteLine($"'{dateStrings[ctr]}' --> {newLocalDate} {newLocalDate.Kind}");
            }
        }
    }
}
// </Snippet11>
