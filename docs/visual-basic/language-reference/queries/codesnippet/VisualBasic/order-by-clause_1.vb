    Dim titlesAscendingPrice = From book In books
                               Order By book.Price, book.Title
                               Select book.Title, book.Price