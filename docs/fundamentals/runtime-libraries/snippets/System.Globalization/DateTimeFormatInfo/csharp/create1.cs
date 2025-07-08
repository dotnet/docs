using System;

public class Example
{
    public static void Main()
    {
        CreateInvariant1();
        Console.WriteLine();
        CreateNeutral2();
        Console.WriteLine();
        CreateSpecific3();
    }

    private static void CreateInvariant1()
    {
        // <Snippet1>
        System.Globalization.DateTimeFormatInfo dtfi;

        dtfi = System.Globalization.DateTimeFormatInfo.InvariantInfo;
        Console.WriteLine(dtfi.IsReadOnly);

        dtfi = new System.Globalization.DateTimeFormatInfo();
        Console.WriteLine(dtfi.IsReadOnly);

        dtfi = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat;
        Console.WriteLine(dtfi.IsReadOnly);
        // The example displays the following output:
        //       True
        //       False
        //       True
        // </Snippet1>
    }

    private static void CreateNeutral2()
    {
        // <Snippet2>
        System.Globalization.CultureInfo specific, neutral;
        System.Globalization.DateTimeFormatInfo dtfi;

        // Instantiate a culture by creating a specific culture and using its Parent property.
        specific = System.Globalization.CultureInfo.GetCultureInfo("fr-FR");
        neutral = specific.Parent;
        dtfi = neutral.DateTimeFormat;
        Console.WriteLine($"{neutral.Name} from Parent property: {dtfi.IsReadOnly}");

        dtfi = System.Globalization.CultureInfo.GetCultureInfo("fr-FR").Parent.DateTimeFormat;
        Console.WriteLine($"{neutral.Name} from Parent property: {dtfi.IsReadOnly}");

        // Instantiate a neutral culture using the CultureInfo constructor.
        neutral = new System.Globalization.CultureInfo("fr");
        dtfi = neutral.DateTimeFormat;
        Console.WriteLine($"{neutral.Name} from CultureInfo constructor: {dtfi.IsReadOnly}");

        // Instantiate a culture using CreateSpecificCulture.
        neutral = System.Globalization.CultureInfo.CreateSpecificCulture("fr");
        dtfi = neutral.DateTimeFormat;
        Console.WriteLine($"{neutral.Name} from CreateSpecificCulture: {dtfi.IsReadOnly}");

        // Retrieve a culture by calling the GetCultureInfo method.
        neutral = System.Globalization.CultureInfo.GetCultureInfo("fr");
        dtfi = neutral.DateTimeFormat;
        Console.WriteLine($"{neutral.Name} from GetCultureInfo: {dtfi.IsReadOnly}");

        // Instantiate a DateTimeFormatInfo object by calling GetInstance.
        neutral = System.Globalization.CultureInfo.CreateSpecificCulture("fr");
        dtfi = System.Globalization.DateTimeFormatInfo.GetInstance(neutral);
        Console.WriteLine($"{neutral.Name} from GetInstance: {dtfi.IsReadOnly}");

        // The example displays the following output:
        //       fr from Parent property: False
        //       fr from Parent property: False
        //       fr from CultureInfo constructor: False
        //       fr-FR from CreateSpecificCulture: False
        //       fr from GetCultureInfo: True
        //       fr-FR from GetInstance: False
        // </Snippet2>
    }

    private static void CreateSpecific3()
    {
        // <Snippet3>
        System.Globalization.CultureInfo ci = null;
        System.Globalization.DateTimeFormatInfo dtfi = null;

        // Instantiate a culture using CreateSpecificCulture.
        ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
        dtfi = ci.DateTimeFormat;
        Console.WriteLine($"{ci.Name} from CreateSpecificCulture: {dtfi.IsReadOnly}");

        // Instantiate a culture using the CultureInfo constructor.
        ci = new System.Globalization.CultureInfo("en-CA");
        dtfi = ci.DateTimeFormat;
        Console.WriteLine($"{ci.Name} from CultureInfo constructor: {dtfi.IsReadOnly}");

        // Retrieve a culture by calling the GetCultureInfo method.
        ci = System.Globalization.CultureInfo.GetCultureInfo("en-AU");
        dtfi = ci.DateTimeFormat;
        Console.WriteLine($"{ci.Name} from GetCultureInfo: {dtfi.IsReadOnly}");

        // Instantiate a DateTimeFormatInfo object by calling DateTimeFormatInfo.GetInstance.
        ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
        dtfi = System.Globalization.DateTimeFormatInfo.GetInstance(ci);
        Console.WriteLine($"{ci.Name} from GetInstance: {dtfi.IsReadOnly}");

        // The example displays the following output:
        //      en-US from CreateSpecificCulture: False
        //      en-CA from CultureInfo constructor: False
        //      en-AU from GetCultureInfo: True
        //      en-GB from GetInstance: False
        // </Snippet3>
    }
}
