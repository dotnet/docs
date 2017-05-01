'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

<MetadataType(GetType(ProductMetaData))> _
Partial Public Class Product

End Class


Public Class ProductMetaData
    
    ' <Snippet12>
    <Range(10, 1000, _
           ErrorMessage:="Value for {0} must be between {1} and {2}.")> _
    Public Weight As Object
    ' </Snippet12>

    ' <Snippet11>
    <Range(300, 3000)> _
    Public ListPrice As Object
    ' </Snippet11>

    ' <Snippet13>
    <Range(GetType(DateTime), "1/2/2004", "3/4/2004", _
           ErrorMessage:="Value for {0} must be between {1} and {2}")> _
    Public SellEndDate As Object
    ' </Snippet13>

End Class

'</Snippet1>
