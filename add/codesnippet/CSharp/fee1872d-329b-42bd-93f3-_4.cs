        //Get the products from the both arrays
        //excluding duplicates.

        IEnumerable<ProductA> union =
          store1.Union(store2);

        foreach (var product in union)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
         
            apple 9
            orange 4
            lemon 12
        */