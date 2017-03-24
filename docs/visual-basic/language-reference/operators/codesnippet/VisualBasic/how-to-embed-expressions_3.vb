        Dim elementName As String = "contact"
        Dim contact3 As XElement = 
            <<%= elementName %>>
                <name>Patrick Hines</name>
            </>
        Console.WriteLine(contact3)