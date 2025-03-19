using System;

public class Example7
{
    public static void Main()
    {
        // <Snippet9>
        string number = "-1";
        string name = "Early";

        try
        {
            ArrivalStatus status1 = (ArrivalStatus)Enum.Parse(typeof(ArrivalStatus), number);
            if (!(Enum.IsDefined(typeof(ArrivalStatus), status1)))
                status1 = ArrivalStatus.Unknown;
            Console.WriteLine($"Converted '{number}' to {status1}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to convert '{number}' to an ArrivalStatus value.");
        }

        ArrivalStatus status2;
        if (Enum.TryParse<ArrivalStatus>(name, out status2))
        {
            if (!(Enum.IsDefined(typeof(ArrivalStatus), status2)))
                status2 = ArrivalStatus.Unknown;
            Console.WriteLine($"Converted '{name}' to {status2}");
        }
        else
        {
            Console.WriteLine($"Unable to convert '{number}' to an ArrivalStatus value.");
        }
        // The example displays the following output:
        //       Converted '-1' to Late
        //       Converted 'Early' to Early
        // </Snippet9>
    }
}
