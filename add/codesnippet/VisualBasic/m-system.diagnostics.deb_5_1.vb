    Public Shared Sub MyMethod(type As Type, baseType As Type)
        Debug.Assert(Not (type Is Nothing), "Type parameter is null")
    End Sub 'MyMethod 