' Place Imports statements at the top of your program.  
Imports <xmlns:ns="http://SomeNamespace">

Module GetXmlNamespaceSample

    Sub RunSample()

        ' Create test by using a global XML namespace prefix. 

        Dim contact = 
            <ns:contact>
                <ns:name>Patrick Hines</ns:name>
                <ns:phone ns:type="home">206-555-0144</ns:phone>
                <ns:phone ns:type="work">425-555-0145</ns:phone>
            </ns:contact>

        ShowName(contact.<ns:phone>(0))
    End Sub

    Sub ShowName(ByVal phone As XElement)
        Dim qualifiedName = GetXmlNamespace(ns) + "contact"
        Dim contact = phone.Ancestors(qualifiedName)(0)
        Console.WriteLine("Name: " & contact.<ns:name>.Value)
    End Sub

End Module