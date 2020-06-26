' Topic: XML Literals Overview

Public Class Samples2

  Public Shared Sub Main()

    '<Snippet5>
    Dim contact1 As XElement = 
        <contact>
          <name>Patrick Hines</name>
          <phone type="home">206-555-0144</phone>
          <phone type="work">425-555-0145</phone>
        </contact>
    '</Snippet5>

    '<Snippet6>  
    Dim contactDoc As XDocument = 
        <?xml version="1.0"?>
        <contact>
          <name>Patrick Hines</name>
          <phone type="home">206-555-0144</phone>
          <phone type="work">425-555-0145</phone>
        </contact>
    '</Snippet6>
  End Sub
End Class

'<Snippet7>  
Public Class XmlSamples

  Public Sub Main()
    ' Initialize the objects. 

    Dim phoneNumbers2 As Phone() = { 
        New Phone("home", "206-555-0144"), 
        New Phone("work", "425-555-0145")}

    ' Convert the data contained in phoneNumbers2 to XML. 

    Dim contact2 = 
        <contact>
          <name>Patrick Hines</name>
          <%= From p In phoneNumbers2 
            Select <phone type=<%= p.Type %>><%= p.Number %></phone> 
          %>
        </contact>

    Console.WriteLine(contact2)
  End Sub

End Class

Class Phone
  Public Type As String
  Public Number As String
  Public Sub New(ByVal t As String, ByVal n As String)
    Type = t
    Number = n
  End Sub
End Class
'</Snippet7>