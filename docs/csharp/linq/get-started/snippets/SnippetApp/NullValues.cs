namespace LinqSamples;

// <dataSourceTypes>
record Product(string Name, int CategoryID);
record Category(string Name, int ID);
// </dataSourceTypes>


public static class NullValues
{
    // <source>
    static Category?[] categories =
    [
        new ("brass", 1),
        null,
        new ("winds", 2),
        default,
        new ("percussion", 3)
    ];

    static Product?[] products =
    [
        new Product("Trumpet", 1),
        new Product("Trombone", 1),
        new Product("French Horn", 1),
        null,
        new Product("Clarinet", 2),
        new Product("Flute", 2),
        null,
        new Product("Cymbal", 3),
        new Product("Drum", 3)
    ];
    // </source>


    public static void NullValues1()
    {
        // <null_values_1>
        var query1 = from c in categories
                     where c != null
                     join p in products on c.ID equals p?.CategoryID
                     select new
                     {
                         Category = c.Name,
                         Name = p.Name
                     };
        // </null_values_1>
    }
}
