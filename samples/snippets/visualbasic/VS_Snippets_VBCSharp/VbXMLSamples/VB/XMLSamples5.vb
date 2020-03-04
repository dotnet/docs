Public Class Samples5
Public Shared Sub Main()
        ' Topic: How to: Access XML Attributes (Visual Basic)
        '<Snippet11>
        Dim phone As XElement = <phone type="home">206-555-0144</phone>

        Console.WriteLine("Type: " & phone.@type)
        '</Snippet11>
    End Sub

    Public Shared Sub Main1()
        '<Snippet12>
        ' Topic: XML Attribute Axis Property
        Dim phones As XElement = 
            <phones>
                <phone type="home">206-555-0144</phone>
                <phone type="work">425-555-0145</phone>
            </phones>

        Dim phoneTypes As XElement = 
          <phoneTypes>
              <%= From phone In phones.<phone> 
                  Select <type><%= phone.@type %></type> 
              %>
          </phoneTypes>

        Console.WriteLine(phoneTypes)
        '</Snippet12>
    End Sub

    Public Shared Sub Main2()
        '<Snippet13>  
       Dim phone As XElement = 
            <phone number-type=" work">425-555-0145</phone>

        Console.WriteLine("Phone type: " & phone.@<number-type>)
        '</Snippet13>

        '<Snippet44>
        Dim phone2 As XElement = <phone type="home">206-555-0144</phone>
        phone2.@owner = "Harris, Phyllis"

        Console.WriteLine(phone2)
        '</Snippet44>

    End Sub
End Class

