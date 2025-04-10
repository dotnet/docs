using System;
using System.IO;

public class Example10
{
    public static void Main()
    {
        // <Snippet17>
        StreamWriter sw = new(@"./Singles.dat");
        float[] values = { 3.2f / 1.11f, 1.0f / 3f, (float)Math.PI };
        for (int ctr = 0; ctr < values.Length; ctr++)
        {
            sw.Write(values[ctr].ToString());
            if (ctr != values.Length - 1)
                sw.Write("|");
        }
        sw.Close();

        float[] restoredValues = new float[values.Length];
        StreamReader sr = new(@"./Singles.dat");
        string temp = sr.ReadToEnd();
        string[] tempStrings = temp.Split('|');
        for (int ctr = 0; ctr < tempStrings.Length; ctr++)
            restoredValues[ctr] = float.Parse(tempStrings[ctr]);

        for (int ctr = 0; ctr < values.Length; ctr++)
            Console.WriteLine($"{values[ctr]} {(values[ctr].Equals(restoredValues[ctr]) ? "=" : "<>")} {restoredValues[ctr]}");

        // The example displays the following output:
        //       2.882883 <> 2.882883
        //       0.3333333 <> 0.3333333
        //       3.141593 <> 3.141593
        // </Snippet17>
    }
}
