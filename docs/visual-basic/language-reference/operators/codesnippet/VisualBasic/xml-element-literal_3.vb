' Place Imports statements at the top of your program.  
Imports <xmlns:ns="http://SomeNamespace">

Class TestClass1

    Shared Sub TestPrefix()
        ' Create test using a global XML namespace prefix. 
        Dim inner2 = <ns:inner2/>

        Dim test = 
        <ns:outer>
            <ns:middle xmlns:ns="http://NewNamespace">
                <ns:inner1/>
                <%= inner2 %>
            </ns:middle>
        </ns:outer>

        ' Display test to see its final form. 
        Console.WriteLine(test)
    End Sub

End Class