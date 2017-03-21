    Public Shared Sub Constructor2() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        ' Create a DatatContractSerializer with the collection.
        Dim ser2 As New System.Runtime.Serialization.NetDataContractSerializer(sc)
    
       ' Other code not shown.
    End Sub 