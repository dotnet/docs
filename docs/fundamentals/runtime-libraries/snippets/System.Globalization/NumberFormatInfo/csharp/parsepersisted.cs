// <Snippet6>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

public class ParsePersistedEx
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        PersistData();

        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        RestoreData();
    }

    private static void PersistData()
    {
        // Define an array of floating-point values.
        Double[] values = { 160325.972, 8631.16, 1.304e5, 98017554.385,
                          8.5938287084321676e94 };
        Console.WriteLine("Original values: ");
        foreach (var value in values)
            Console.WriteLine(value.ToString("R", CultureInfo.InvariantCulture));

        // Serialize an array of doubles to a file
        StreamWriter sw = new StreamWriter(@".\NumericData.bin");
        for (int ctr = 0; ctr < values.Length; ctr++)
        {
            sw.Write(values[ctr].ToString("R"));
            if (ctr < values.Length - 1) sw.Write("|");
        }
        sw.Close();
        Console.WriteLine();
    }

    private static void RestoreData()
    {
        // Deserialize the data
        StreamReader sr = new StreamReader(@".\NumericData.bin");
        String data = sr.ReadToEnd();
        sr.Close();

        String[] stringValues = data.Split('|');
        List<Double> newValueList = new List<Double>();

        foreach (var stringValue in stringValues)
        {
            try
            {
                newValueList.Add(Double.Parse(stringValue));
            }
            catch (FormatException)
            {
                newValueList.Add(Double.NaN);
            }
        }

        Console.WriteLine("Restored values:");
        foreach (var newValue in newValueList)
            Console.WriteLine(newValue.ToString("R", NumberFormatInfo.InvariantInfo));
    }
}
// The example displays the following output:
//       Original values:
//       160325.972
//       8631.16
//       130400
//       98017554.385
//       8.5938287084321671E+94
//
//       Restored values:
//       160325972
//       863116
//       130400
//       98017554385
//       8.5938287084321666E+110
// </Snippet6>
