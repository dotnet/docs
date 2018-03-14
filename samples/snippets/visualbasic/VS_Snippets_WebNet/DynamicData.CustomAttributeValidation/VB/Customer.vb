' <Snippet2>
Imports Microsoft.VisualBasic
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(CustomerMetadata))> _
Partial Public Class Customer

End Class

Public Class CustomerMetadata
    <PhoneMask("999-999-9999", _
    ErrorMessage:="{0} field value does not match the mask {1}.")> _
  Public Phone As Object

End Class
' </Snippet2>