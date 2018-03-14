Imports <xmlns:ns = "http://SomeNamespace"> 
 
Class TestClass4

    Shared Sub TestPrefix()
        Dim contact = <ns:contact>
                        <ns:name>Patrick Hines</ns:name>
                      </ns:contact>
        Console.WriteLine(contact.<ns:name>.Value)
    End Sub

End Class