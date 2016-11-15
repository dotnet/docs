    Dim titlesDescendingPrice = From book In books
                                Order By book.Price Descending, book.Title
                                Select book.Title, book.Price