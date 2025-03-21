using System;
using System.IO;

public class Example11
{
    public static void Main()
    {
        // <Snippet7>
        StreamWriter sw = new(@"./Doubles.dat");
        double[] values = [2.2 / 1.01, 1.0 / 3, Math.PI];
        for (int ctr = 0; ctr < values.Length; ctr++)
        {
            sw.Write(values[ctr].ToString());
            if (ctr != values.Length - 1)
                sw.Write("|");
        }
        sw.Close();

        double[] restoredValues = new double[values.Length];
        StreamReader sr = new(@"./Doubles.dat");
        string temp = sr.ReadToEnd();
        string[] tempStrings = temp.Split('|');
        for (int ctr = 0; ctr < tempStrings.Length; ctr++)
            restoredValues[ctr] = double.Parse(tempStrings[ctr]);

        for (int ctr = 0; ctr < values.Length; ctr++)
        Console.WriteLine($"{values[ctr]} {(values[ctr].Equals(restoredValues[ctr]) ? "=" : "<>")} {restoredValues[ctr]}");

        // For .NET Framework only, the example displays the following output:
        //       2.17821782178218 <> 2.17821782178218
        //       0.333333333333333 <> 0.333333333333333
        //       3.14159265358979 <> 3.14159265358979
        // </Snippet7>
    }
}
