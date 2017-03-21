        Product[] fruits1 = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 },
                                new Product { Name = "lemon", Code = 12 } };

        Product[] fruits2 = { new Product { Name = "apple", Code = 9 } };

        //Get all the elements from the first array
        //except for the elements from the second array.

        IEnumerable<Product> except =
            fruits1.Except(fruits2, new ProductComparer());

        foreach (var product in except)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
          This code produces the following output:
         
          orange 4
          lemon 12
        */
