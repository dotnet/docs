Module Module2

  Sub Main()
    Dim catalog = <?xml version="1.0"?>
                  <Catalog>
                    <Book id="bk101">
                      <Author>Garghentini, Davide</Author>
                      <Title>XML Developer's Guide</Title>
                      <Price>44.95</Price>
                      <Description>
                        An in-depth look at creating applications
                        with <technology>XML</technology>. For 
                        <audience>beginners</audience> or 
                        <audience>advanced</audience> developers.
                      </Description>
                    </Book>
                    <Book id="bk331">
                      <Author>Spencer, Phil</Author>
                      <Title>Developing Applications with Visual Basic .NET</Title>
                      <Price>45.95</Price>
                      <Description>
                        Get the expert insights, practical code samples, and best practices you need 
                        to advance your expertise with <technology>Visual Basic .NET</technology>. 
                        Learn how to create faster, more reliable applications based on professional, 
                        pragmatic guidance by today's top <audience>developers</audience>.
                      </Description>
                    </Book>
                  </Catalog>

    '<Snippet4>
    For Each book In From element In catalog.<Catalog>.<Book>
      book.<Price>.Value = (book.<Price>.Value * 1.05).ToString("#.00")
    Next
    '</Snippet4>

    '<Snippet5>
    Dim newAttribute = "editorEmail"
    Dim editorID = "someone@example.com"
    For Each book In From element In catalog.<Catalog>.<Book>
      ' Add an attribute by using an XML attribute axis property.
      book.@genre = "Computer"

      ' Add an attribute to the Attributes collection.
      book.Add(New XAttribute(newAttribute, editorID))
    Next
    '</Snippet5>

    '<Snippet6>
    Dim vbBook = From book In catalog.<Catalog>.<Book> 
                 Where book.<Title>.Value = 
                   "Developing Applications with Visual Basic .NET"

    vbBook(0).AddFirst(<Publisher>Microsoft Press</Publisher>)

    vbBook(0).Add(<PublishDate>2005-2-14</PublishDate>)

    vbBook(0).AddAfterSelf(<Book id="bk999"></Book>)

    vbBook(0).AddBeforeSelf(<Book id="bk000"></Book>)
    '</Snippet6>

    '<Snippet7>
    For Each book In From element In catalog.<Catalog>.<Book>
      book.Attributes("genre").Remove()
    Next

    For Each book In From element In catalog.<Catalog>.<Book> 
                     Where element.@id = "bk999"
      book.Remove()
    Next
    '</Snippet7>

    '<Snippet8>
    For Each desc In From element In catalog.<Catalog>.<Book>.<Description>
      ' Replace and preserve inner XML.
      desc.ReplaceWith(<Abstract><%= desc.Nodes %></Abstract>)
    Next

    For Each price In From element In catalog.<Catalog>.<Book>.<Price>
      ' Replace with text value.
      price.ReplaceWith(<MSRP><%= price.Value %></MSRP>)
    Next
    '</Snippet8>

    Console.WriteLine(catalog)
    Console.ReadLine()
  End Sub

End Module
