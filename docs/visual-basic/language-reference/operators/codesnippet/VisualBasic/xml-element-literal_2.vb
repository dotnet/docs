        Dim elementType = "book"
        Dim authorName = "My Author"
        Dim attributeName1 = "year"
        Dim attributeValue1 = 1999
        Dim attributeName2 = "title"
        Dim attributeValue2 = "My Book"

        Dim book As XElement = 
        <<%= elementType %>
            isbn="1234"
            author=<%= authorName %>
            <%= attributeName1 %>=<%= attributeValue1 %>
            <%= New XAttribute(attributeName2, attributeValue2) %>
        />

        Console.WriteLine(book)