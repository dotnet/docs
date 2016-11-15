        ' Returns all product names for which the Category of
        ' the product is "Beverages".
        Dim names = From product In products
                    Where product.Category = "Beverages"
                    Select product.Name