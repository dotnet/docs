Imports System
Imports System.Collections.Generic
Imports System.Security.Permissions
Imports System.Text
Imports System.Web

Namespace System.Web.Script.Serialization.TypeResolver.VB

    ' <Snippet2>
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
    ' </Snippet2>

    Public Class ColorType
        Public rgb() As String = {"00", "00", "FF"}
        Public defaultColor As FavoriteColors = FavoriteColors.Blue
    End Class

    Public Enum FavoriteColors
        Black
        White
        Blue
        Red
    End Enum

End Namespace