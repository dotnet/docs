' Topic: XML Element Literal

Public Class Samples9
Public Shared Sub Main()

        '<Snippet20>
        Dim test1 As XElement = 
        <outer>
            <inner1></inner1>
            <inner2/>
        </outer>

        Console.WriteLine(test1)
        '</Snippet20>

        '<Snippet21>  
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
        '</Snippet21>

'Snippet#
        '<book isbn="1234" year="1999" title="My Book" /> 
'/Snippet#

End Sub
End Class
