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
        var latitude = 47.6062;
        var longitude = -122.3321;
        var city = "Seattle";

        var json = FormattableString.Invariant($$"""
        {
            "city": "{{city}}",
            "coordinates": {
                "latitude": {{latitude}},
                "longitude": {{longitude}}
            }
        }
        """);
        // </InterpolatedRawString>
        Console.WriteLine(json);
    }
}
