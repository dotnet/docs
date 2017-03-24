Imports <xmlns:ns = "http://SomeNamespace"> 
 
Class TestClass2

    Shared Sub TestPrefix()
        Dim contacts = 
            <ns:contacts>
                <ns:contact>
                    <ns:name>Patrick Hines</ns:name>
                </ns:contact>
            </ns:contacts>

        Console.WriteLine("Name: " & contacts...<ns:name>.Value)
    End Sub

End Class