        // Get the products from the first array 
        // that have duplicates in the second array.
        
        IEnumerable<ProductA> duplicates =
            store1.Intersect(store2, new ProductComparer());

        foreach (var product in duplicates)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
            apple 9
        */