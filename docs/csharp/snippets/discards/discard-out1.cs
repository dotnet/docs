using System;

public class DiscardExamples
{
    public static void DiscardOutParameter()
    {
        // <DiscardOutParameter>
        string[] dateStrings = {"05/01/2018 14:57:32.8", "2018-05-01 14:57:32.8",
                              "2018-05-01T14:57:32.8375298-04:00", "5/01/2018",
                              "5/01/2018 14:57:32.80 -07:00",
                              "1 May 2018 2:57:32.8 PM", "16-05-2018 1:00:32 PM",
                              "Fri, 15 May 2018 20:10:57 GMT" };
        foreach (string dateString in dateStrings)
        {
            if (DateTime.TryParse(dateString, out _))
                Console.WriteLine($"'{dateString}': valid");
            else
                Console.WriteLine($"'{dateString}': invalid");
        }
        // The example displays output like the following:
        //       '05/01/2018 14:57:32.8': valid
        //       '2018-05-01 14:57:32.8': valid
        //       '2018-05-01T14:57:32.8375298-04:00': valid
        //       '5/01/2018': valid
        //       '5/01/2018 14:57:32.80 -07:00': valid
        //       '1 May 2018 2:57:32.8 PM': valid
        //       '16-05-2018 1:00:32 PM': invalid
        //       'Fri, 15 May 2018 20:10:57 GMT': invalid
        // </DiscardOutParameter>
    }
}
