// <Snippet8>
using System;
using System.IO;

public class Example12
{
    public static void Main()
    {
        StreamWriter sw = new StreamWriter(@".\Doubles.dat");
        Double[] values = { 2.2 / 1.01, 1.0 / 3, Math.PI };
        for (int ctr = 0; ctr < values.Length; ctr++)
            sw.Write("{0:G17}{1}", values[ctr], ctr < values.Length - 1 ? "|" : "");

        sw.Close();

        Double[] restoredValues = new Double[values.Length];
        StreamReader sr = new StreamReader(@".\Doubles.dat");
        string temp = sr.ReadToEnd();
        string[] tempStrings = temp.Split('|');
        for (int ctr = 0; ctr < tempStrings.Length; ctr++)
            restoredValues[ctr] = Double.Parse(tempStrings[ctr]);

        for (int ctr = 0; ctr < values.Length; ctr++)
            Console.WriteLine($"{values[ctr]} {values[ctr].Equals(restoredValues[ctr]) ? "=" : "<>"} {restoredValues[ctr]}");
    }
}
// The example displays the following output:
//       2.17821782178218 = 2.17821782178218
//       0.333333333333333 = 0.333333333333333
//       3.14159265358979 = 3.14159265358979
// </Snippet8>
