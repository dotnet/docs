//<snippet1>
using System;

public class EnumTest {
    enum Days { Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
    enum BoilingPoints { Celsius = 100, Fahrenheit = 212 };
    [Flags]
    enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };

    public static void Main() {

        Type weekdays = typeof(Days);
        Type boiling = typeof(BoilingPoints);

        Console.WriteLine("The days of the week, and their corresponding values in the Days Enum are:");

        foreach ( string s in Enum.GetNames(weekdays) )
            Console.WriteLine( "{0,-11}= {1}", s, Enum.Format( weekdays, Enum.Parse(weekdays, s), "d"));

        Console.WriteLine();
        Console.WriteLine("Enums can also be created which have values that represent some meaningful amount.");
        Console.WriteLine("The BoilingPoints Enum defines the following items, and corresponding values:");

        foreach ( string s in Enum.GetNames(boiling) )
            Console.WriteLine( "{0,-11}= {1}", s, Enum.Format(boiling, Enum.Parse(boiling, s), "d"));

        Colors myColors = Colors.Red | Colors.Blue | Colors.Yellow;
        Console.WriteLine();
        Console.WriteLine($"myColors holds a combination of colors. Namely: {myColors}");
    }
}
//</snippet1>
