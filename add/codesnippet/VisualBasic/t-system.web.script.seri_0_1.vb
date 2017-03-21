    Public Class CustomTypeResolver
        Inherits JavaScriptTypeResolver

        Public Overrides Function ResolveType(ByVal id As String) As Type
            Return Type.GetType(id)
        End Function

        Public Overrides Function ResolveTypeId(ByVal type As Type) As String
            If type Is Nothing Then
                Throw New ArgumentNullException("type")
            End If

            Return type.Name
        End Function
    End Class