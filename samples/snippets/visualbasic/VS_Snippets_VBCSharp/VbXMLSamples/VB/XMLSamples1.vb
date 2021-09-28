' Topic: Overview of LINQ to XML in Visual Basic
'<Snippet1>
Imports <xmlns:ns="http://someNamespace">
'</Snippet1>
'<Snippet50>
Imports <xmlns="http://defaultNamespace">
'</Snippet50>

Public Class Samples1

    Public Shared Sub Main()

        '<Snippet2>  
        Dim contact1 As XElement = 
            <ns:contact>
                <ns:name>Patrick Hines</ns:name>
                <ns:phone type="home">206-555-0144</ns:phone>
                <ns:phone type="work">425-555-0145</ns:phone>
            </ns:contact>

        Console.WriteLine(contact1)
        '</Snippet2>

        '<Snippet3>  
        Dim contact2 As XElement = 
            <ns1:contact xmlns:ns1="http://someNamespace">
                <ns1:name>Patrick Hines</ns1:name>
                <ns1:phone type="home">206-555-0144</ns1:phone>
                <ns1:phone type="work">425-555-0145</ns1:phone>
            </ns1:contact>

        Console.WriteLine(contact2)
        '</Snippet3>

        '<Snippet4>  
        Console.WriteLine("Contact name is: " & contact1.<ns:name>.Value)
        '</Snippet4>

    End Sub

End Class
