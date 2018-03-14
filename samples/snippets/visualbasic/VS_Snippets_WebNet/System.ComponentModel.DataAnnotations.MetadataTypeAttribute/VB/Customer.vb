'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

'<Snippet2>
<MetadataType(GetType(CustomerMetadata))> _
Partial Public Class Customer

End Class
'</Snippet2>

Public Class CustomerMetadata

    '<Snippet3>
    ' Apply RequitedAttribute.
    <Required(ErrorMessage:="Title is required.")> _
    Public Title As Object
    '</Snippet3>

   
End Class

'</Snippet1>