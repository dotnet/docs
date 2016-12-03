        Dim nameQuantityQuery = From prod In products
                                Select prod.Name, prod.OnHand