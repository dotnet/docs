    Dim bookOrders =
      From book In books
      Select book.Title, book.Price, book.PublishDate, book.Author
      Order By Author, Title, Price