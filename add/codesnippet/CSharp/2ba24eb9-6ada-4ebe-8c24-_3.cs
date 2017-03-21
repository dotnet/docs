        ProductA[] fruits1 = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 },
                                new ProductA { Name = "lemon", Code = 12 } };

        ProductA[] fruits2 = { new ProductA { Name = "apple", Code = 9 } };

        //Get all the elements from the first array
        //except for the elements from the second array.

        IEnumerable<ProductA> except =
            fruits1.Except(fruits2);

        foreach (var product in except)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
          This code produces the following output:
         
          orange 4
          lemon 12
        */
