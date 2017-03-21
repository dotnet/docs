
        Product[] storeA = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 } };

        Product[] storeB = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 } };

        bool equalAB = storeA.SequenceEqual(storeB, new ProductComparer());

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:
            
            Equal? True
        */
