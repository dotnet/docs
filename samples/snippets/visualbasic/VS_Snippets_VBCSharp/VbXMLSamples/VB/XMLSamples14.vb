' Topic: How to: Access XML Descendant Elements (Visual Basic)

Public Class Samples14
    Public Shared Sub Main()

        '<Snippet39>
        Dim contactName As String = "Patrick Hines"
        Dim contact As XElement = 
          <contact>
            <name><%= contactName %></name>
          </contact>
        Console.WriteLine(contact)
        '</Snippet39>

        '<Snippet40>
        Dim phoneType As String = "home"
        Dim contact2 As XElement = 
          <contact>
            <phone type=<%= phoneType %>>206-555-0144</phone>
          </contact>
        Console.WriteLine(contact2)
        '</Snippet40>

        '<Snippet41>
        Dim elementName As String = "contact"
        Dim contact3 As XElement = 
            <<%= elementName %>>
                <name>Patrick Hines</name>
            </>
        Console.WriteLine(contact3)
        '</Snippet41>

    End Sub
End Class