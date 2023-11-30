using LinqSamples.Joins;

namespace LinqSamples;

public static class NullValues
{
    static readonly Category[] categories = [];
    static readonly Product[] products = [];

    public static void NullValues1()
    {
        // <null_values_1>
        var query1 =
            from c in categories
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
