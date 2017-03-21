    Public Shared Sub MyMethod(type As Type, baseType As Type)
        Trace.Assert( Not (type Is Nothing), "Type parameter is null")

        ' Perform some processing.
    End Sub
    