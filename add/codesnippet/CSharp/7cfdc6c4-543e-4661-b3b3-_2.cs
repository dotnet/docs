
        Product[] fruits = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 }, 
                               new Product { Name = "lemon", Code = 12 } };

        Product apple = new Product { Name = "apple", Code = 9 };
        Product kiwi = new Product {Name = "kiwi", Code = 8 };

        ProductComparer prodc = new ProductComparer();

        bool hasApple = fruits.Contains(apple, prodc);
        bool hasKiwi = fruits.Contains(kiwi, prodc);

        Console.WriteLine("Apple? " + hasApple);
        Console.WriteLine("Kiwi? " + hasKiwi);

        /*
            This code produces the following output:
         
            Apple? True
            Kiwi? False
        */    
