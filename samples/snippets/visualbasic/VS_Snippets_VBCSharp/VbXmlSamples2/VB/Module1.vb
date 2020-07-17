Option Strict On

Module Module1

  Sub Main()
    '<Snippet1>
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
    '</Snippet1>

    '<Snippet3>
    Dim htmlOutput = <html>
                       <body>
                         <%= From book In catalog.<Catalog>.<Book> 
                             Select <div>
                                    <h1><%= book.<Title>.Value %></h1>
                                    <h3><%= "By " & book.<Author>.Value %></h3>
                                    <h3><%= "Price = " & book.<Price>.Value %></h3>
                                    <h2>Description</h2>
                                    <%= TransformDescription(book.<Description>(0)) %>
                                    <hr/>
                                  </div> %>
                       </body>
                     </html>

    htmlOutput.Save("BookDescription.html")
    '</Snippet3>

  End Sub

  '<Snippet2>
  Public Function TransformDescription(ByVal desc As XElement) As XElement

    ' Replace <technology> elements with <b>.
    Dim content = (From element In desc...<technology>).ToList()

    If content.Count > 0 Then
      For i = 0 To content.Count - 1
        content(i).ReplaceWith(<b><%= content(i).Value %></b>)
      Next
    End If

    ' Replace <audience> elements with <i>.
    content = (From element In desc...<audience>).ToList()

    If content.Count > 0 Then
      For i = 0 To content.Count - 1
        content(i).ReplaceWith(<i><%= content(i).Value %></i>)
      Next
    End If

    ' Return the updated contents of the <Description> element.
    Return <p><%= desc.Nodes %></p>
  End Function
  '</Snippet2>

End Module
