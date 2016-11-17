        ' Returns a list of products with a calculation of
        ' a ten percent discount.
        Dim discountedProducts = From prod In products
                                 Let Discount = prod.UnitPrice * 0.1
                                 Where Discount >= 50
                                 Select prod.Name, prod.UnitPrice, Discount