    Public Shared Sub Constructor3() 
        ' Create an instance of the DataContractSerializer
        ' specifying the type, and name and 
        ' namespace as strings.
        Dim ser As New DataContractSerializer(GetType(Person), _
        "Customer", _
        "http://www.contoso.com")

        ' Other code not shown.
    End Sub 