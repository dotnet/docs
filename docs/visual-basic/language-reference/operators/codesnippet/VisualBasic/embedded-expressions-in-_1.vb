        Dim isbnNumber As String = "12345"
        Dim modifiedDate As String = "3/5/2006"
        Dim book As XElement = 
            <book category="fiction" isbn=<%= isbnNumber %>>
                <modifiedDate><%= modifiedDate %></modifiedDate>
            </book>