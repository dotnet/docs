        Product[] products = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 }, 
                               new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "lemon", Code = 12 } };

        //Exclude duplicates.
        
        IEnumerable<Product> noduplicates =
            products.Distinct();

        foreach (var product in noduplicates)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
            apple 9 
            orange 4
            lemon 12
        */