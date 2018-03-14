Imports <xmlns:ns = "http://SomeNamespace"> 
 
Class TestClass3

    Shared Sub TestPrefix()
        Dim phone = 
            <ns:phone ns:type="home">206-555-0144</ns:phone>

        Console.WriteLine("Phone type: " & phone.@ns:type)
    End Sub

End Class