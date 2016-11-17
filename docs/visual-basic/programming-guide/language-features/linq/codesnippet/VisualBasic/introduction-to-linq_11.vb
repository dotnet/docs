        ' Returns a list of books sorted by price in 
        ' ascending order.
        Dim titlesAscendingPrice = From b In books
                                   Order By b.price