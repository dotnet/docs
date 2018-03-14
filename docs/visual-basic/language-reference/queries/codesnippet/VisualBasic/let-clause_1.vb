    Dim discountedProducts = From prod In products
                             Let Discount = prod.UnitPrice * 0.1
                             Where Discount >= 50
                             Select prod.ProductName, prod.UnitPrice, Discount

    For Each prod In discountedProducts
      Console.WriteLine("Product: {0}, Price: {1}, Discounted Price: {2}",
                        prod.ProductName, prod.UnitPrice.ToString("$#.00"),
                        (prod.UnitPrice - prod.Discount).ToString("$#.00"))
    Next