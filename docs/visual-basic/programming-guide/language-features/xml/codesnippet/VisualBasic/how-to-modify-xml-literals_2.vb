    Dim newAttribute = "editorEmail"
    Dim editorID = "someone@example.com"
    For Each book In From element In catalog.<Catalog>.<Book>
      ' Add an attribute by using an XML attribute axis property.
      book.@genre = "Computer"

      ' Add an attribute to the Attributes collection.
      book.Add(New XAttribute(newAttribute, editorID))
    Next