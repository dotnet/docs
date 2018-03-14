    For Each book In From element In catalog.<Catalog>.<Book>
      book.Attributes("genre").Remove()
    Next

    For Each book In From element In catalog.<Catalog>.<Book> 
                     Where element.@id = "bk999"
      book.Remove()
    Next