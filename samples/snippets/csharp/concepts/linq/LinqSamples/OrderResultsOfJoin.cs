using LinqSamples.Joins;

namespace LinqSamples;

public static class OrderResultsOfJoin
{
    public static void OrderResultsOfJoin1()
    {
        // <order_results_of_join_1>
        List<Category> categories =
        [
            new(Name: "Beverages", ID: 001),
            new("Condiments", 002),
            new("Vegetables", 003),
            new("Grains", 004),
            new("Fruit", 005)
        ];

        List<Product> products =
        [
            new(Name: "Cola", CategoryID: 001),
            new("Tea", 001),
            new("Mustard", 002),
            new("Pickles", 002),
            new("Carrots", 003),
            new("Bok Choy", 003),
            new("Peaches", 005),
            new("Melons", 005),
        ];

        var groupJoinQuery2 =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID into prodGroup
            orderby category.Name
            select new
            {
                Category = category.Name,
                Products =
                    from prod2 in prodGroup
                    orderby prod2.Name
                    select prod2
            };

        foreach (var productGroup in groupJoinQuery2)
        {
            Console.WriteLine(productGroup.Category);
            foreach (var prodItem in productGroup.Products)
            {
                Console.WriteLine($"  {prodItem.Name,-10} {prodItem.CategoryID}");
            }
        }

        /* Output:
            Beverages
              Cola       1
              Tea        1
            Condiments
              Mustard    2
              Pickles    2
            Fruit
              Melons     5
              Peaches    5
            Grains
            Vegetables
              Bok Choy   3
              Carrots    3
         */
        // </order_results_of_join_1>
    }
}
