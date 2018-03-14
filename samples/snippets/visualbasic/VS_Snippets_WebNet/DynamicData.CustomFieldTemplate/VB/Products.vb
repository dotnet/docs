' <Snippet5>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations


<MetadataType(GetType(ProductMetadata))> _
Partial Public Class Product

End Class

Partial Public Class ProductMetadata
    <UIHint("UnitsInStock")> _
    <Range(100, 10000)> _
    Public UnitsInStock As Object
End Class

' </Snippet5>
