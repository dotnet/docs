Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(CustomerMetadata))> _
Partial Public Class Customer

End Class

Public Class CustomerMetadata

    ' Apply RequitedAttribute.
    <Required(ErrorMessage:="Title is required.")> _
    Public Title As Object

   
End Class
