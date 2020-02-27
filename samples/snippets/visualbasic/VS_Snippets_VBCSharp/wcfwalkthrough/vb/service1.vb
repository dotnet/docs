' NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
Public Class Service1
    Implements IService1
    ' <Snippet2>
    Public Function GetData(ByVal value As String) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function
    ' </Snippet2>

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

End Class
