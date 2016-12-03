    For Each book In From element In catalog.<Catalog>.<Book>
      book.<Price>.Value = (book.<Price>.Value * 1.05).ToString("#.00")
    Next