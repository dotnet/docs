
        ProductA[] storeA = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 } };

        ProductA[] storeB = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 } };

        bool equalAB = storeA.SequenceEqual(storeB);

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:
            
            Equal? True
        */
