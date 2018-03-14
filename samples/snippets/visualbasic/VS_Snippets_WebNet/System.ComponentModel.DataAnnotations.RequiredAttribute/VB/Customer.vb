'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

<MetadataType(GetType(CustomerMetaData))> _
Partial Public Class Customer

   
End Class

Public Class CustomerMetaData
    ' <Snippet2>
    ' Require that the Title is not null.
    ' Use custom validation error.
    <Required(ErrorMessage:="Title is required.")> _
    Public Title As Object
    ' </Snippet2>

    ' <Snippet3>
    ' Require that the MiddleName is not null.
    ' Use standard validation error.
    <Required()> _
    Public MiddleName As Object
    ' </Snippet3>

End Class

'</Snippet1>

