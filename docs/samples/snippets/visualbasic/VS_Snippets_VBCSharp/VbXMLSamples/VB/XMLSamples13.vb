' Topic: How to: Access XML Descendant Elements (Visual Basic)

Public Class Samples13
Public Shared Sub Main()

        '<Snippet31>
        Dim contacts As XElement = 
        <contacts>
            <contact>
                <name>Patrick Hines</name>
                <phone type="home">206-555-0144</phone>
                <phone type="work">425-555-0145</phone>
            </contact>
        </contacts>

        Console.WriteLine("Name: " & contacts...<name>.Value)

        Dim phoneTypes As XElement = 
          <phoneTypes>
              <%= From phone In contacts...<phone> 
                  Select <type><%= phone.@type %></type> 
              %>
          </phoneTypes>

        Console.WriteLine(phoneTypes)
        '</Snippet31>

        ' Topic: Embedded Expressions in XML
        '<Snippet27>
        Dim isbnNumber As String = "12345"
        Dim modifiedDate As String = "3/5/2006"
        Dim book As XElement = 
            <book category="fiction" isbn=<%= isbnNumber %>>
                <modifiedDate><%= modifiedDate %></modifiedDate>
            </book>
        '</Snippet27>

        ' Topic: XML Processing Instruction Literal
        '<Snippet28>
        Dim pi As XProcessingInstruction = 
          <?xml-stylesheet type="text/xsl" href="show_book.xsl"?>
        '</Snippet28>

        ' Topic: White Space in XML Literals
        '<Snippet29>
        Dim example As XElement = <outer>
                                      <inner> 
                                          Inner text 
                                      </inner>
                                  </outer>

        Console.WriteLine(example)
        '</Snippet29>
        '<outer>
        '  <inner>
        '                                          Inner text
        '                                      </inner>
        '</outer>


        ' Topic: XML Document Literal
        '<Snippet30>
        Dim libraryRequest As XDocument = 
            <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
            <?xml-stylesheet type="text/xsl" href="show_book.xsl"?>
            <!-- Tests that the application works. -->
            <books>
                <book/>
            </books>
        Console.WriteLine(libraryRequest)
        '</Snippet30>

'<Snippet32>
Dim elementName As String = "contact"
Dim contact1 As XElement = <<%= elementName %>/>
'</Snippet32>

'<Snippet33>
Dim contactName As String = "Patrick Hines"
Dim contact2 As XElement = 
  <contact><%= contactName %></contact>
'</Snippet33>

'<Snippet34>
Dim phoneType As String = "home"
Dim contact3 As XElement = 
  <contact <%= phoneType %>="206-555-0144"/>
'</Snippet34>

'<Snippet35>
Dim phoneNumber As String = "206-555-0144"
Dim contact4 As XElement = 
  <contact home=<%= phoneNumber %>/>
'</Snippet35>

'<Snippet36>
Dim phoneAttribute As XAttribute = 
  New XAttribute(XName.Get(phoneType), phoneNumber)
Dim contact5 As XElement = 
  <contact <%= phoneAttribute %>/>
'</Snippet36>

'<Snippet37>
Dim document As XDocument = 
  <?xml version="1.0"?><%= contact1 %>
'</Snippet37>

End Sub
End Class