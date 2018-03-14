' Topic: XML CDATA Literal

Public Class Samples11
Public Shared Sub Main()

        '<Snippet23>
        Dim cdata As XCData = <![CDATA[Can contain literal <XML> tags]]>
        '</Snippet23>

        ' Topic: Extension Indexer Property
        '<Snippet24>
        Dim contact As XElement = 
            <contact>
                <name>Patrick Hines</name>
                <phone type="home">206-555-0144</phone>
                <phone type="work">425-555-0145</phone>
            </contact>

        Console.WriteLine("Second phone number: " & contact.<phone>(1).Value)
        '</Snippet24>


        ' Topic: XML Descendant Axis Property
        '<Snippet25>
        Dim contacts As XElement = 
            <contacts>
                <contact>
                    <name>Patrick Hines</name>
                    <phone type="home">206-555-0144</phone>
                    <phone type="work">425-555-0145</phone>
                </contact>
            </contacts>

        Console.WriteLine("Name: " & contacts...<name>.Value)

        Dim homePhone = From phone In contacts...<phone> 
                        Select phone.Value

        Console.WriteLine("Home Phone = {0}", homePhone(0))
        '</Snippet25>

End Sub
End Class