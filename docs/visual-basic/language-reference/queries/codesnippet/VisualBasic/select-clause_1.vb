    ' 10% discount 
    Dim discount_10 = 0.1
    Dim priceList =
      From product In products
      Let DiscountedPrice = product.UnitPrice * (1 - discount_10)
      Select product.ProductName, Price = product.UnitPrice,
      Discount = discount_10, DiscountedPrice