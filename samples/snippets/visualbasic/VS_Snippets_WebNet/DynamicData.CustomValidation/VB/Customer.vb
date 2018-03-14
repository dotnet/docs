' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(CustomerMetadata))> _
Partial Public Class Customer


    Private Sub OnValidate(ByVal action As System.Data.Linq.ChangeAction)
        If Not Char.IsUpper(Me._LastName(0)) _
        OrElse Not Char.IsUpper(Me._FirstName(0)) _
        OrElse Not Char.IsUpper(Me._Title(0)) Then
            Throw New ValidationException( _
               "Data value must start with an uppercase letter.")
        End If
    End Sub


End Class

Public Class CustomerMetadata
    <Required()> _
    Public Title As Object

End Class
' </Snippet1>
