using System;

public static class RawStrings
{
    internal static void Examples()
    {
        // <SingleLine>
        var singleLine = """This is a "raw string literal". It can contain characters like \, ' and ".""";
        // </SingleLine>
        Console.WriteLine(singleLine);

        // <MultiLine>
        var xml = """
                <element attr="content">
                    <body>
                    </body>
                </element>
                """;
        // </MultiLine>
        Console.WriteLine(xml);

        // <MoarQuotes>
        var moreQuotes = """" As you can see,"""Raw string literals""" can start and end with more than three double-quotes when needed."""";
        // </MoarQuotes>
        Console.WriteLine(moreQuotes);

        // <InitialQuotes>
        var MultiLineQuotes = """"
                       """Raw string literals""" can start and end with more than three double-quotes when needed.
                       """";
        // </InitialQuotes>
        Console.WriteLine(MultiLineQuotes);

        // <InterpolatedRawString>
        var longitude = 47.6062;
        var latitude = -122.3321;
        var city = "Seattle";

        var json = $$"""
        {
            "city": "{{city}}",
            "coordinates": {
                "longitude": {{longitude}},
                "latitude": {{latitude}}
            }
        }
        """;
        // </InterpolatedRawString>
        Console.WriteLine(json);
    }
}
