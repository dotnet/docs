    Public Shared Sub MyMethod(type As Type, baseType As Type)
        Debug.Assert( Not (type Is Nothing), "Type parameter is null", "Can't get object for null type")
        ' Perform some processing.
    End Sub 'MyMethod