Public Class Samples4

Public Shared Sub Main()

        ' Topic: XML Comment Literal
        '<Snippet9>
        Dim com As XComment = <!-- This is a comment -->
        '</Snippet9>



        ' Topic: How to: Access XML Child Elements (Visual Basic)
        '<Snippet10>
        Dim contact As XElement = 
        <contact>
            <name>Patrick Hines</name>
            <phone type="home">206-555-0144</phone>
            <phone type="work">425-555-0145</phone>
        </contact>

        Console.WriteLine("Contact name: " & contact.<name>.Value)

        Dim phoneTypes As XElement = 
          <phoneTypes>
              <%= From phone In contact.<phone> 
                  Select <type><%= phone.@type %></type> 
              %>
          </phoneTypes>

        Console.WriteLine(phoneTypes)
        '</Snippet10>

End Sub

End Class