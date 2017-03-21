    Public Shared Sub Constructor3() 
        ' Create an instance of the NetDataContractSerializer
        ' specifying the name and namespace as strings.
        Dim ser As New System.Runtime.Serialization. _
           NetDataContractSerializer("Customer", "http://www.contoso.com")
    
       ' Other code not shown.
    
    End Sub 