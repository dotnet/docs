using System;

public class BooleanMembers {

    public static void Main() {
        // <Snippet1>
        bool raining = false;
        bool busLate = true;

        Console.WriteLine("raining.ToString() returns {0}", raining);
        Console.WriteLine("busLate.ToString() returns {0}", busLate);
        // The example displays the following output:
        //       raining.ToString() returns False
        //       busLate.ToString() returns True
        // </Snippet1>

        // <Snippet2>
        bool val;
        string input;

        input = bool.TrueString;
        val = bool.Parse(input);
        Console.WriteLine("'{0}' parsed as {1}", input, val);
        // The example displays the following output:
        //       'True' parsed as True        
        // </Snippet2>

    }
}


