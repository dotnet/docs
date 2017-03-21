Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

<MetadataType(GetType(ProductMetaData))> _
Partial Public Class Product

End Class


Public Class ProductMetaData
    
    <Range(10, 1000, _
           ErrorMessage:="Value for {0} must be between {1} and {2}.")> _
    Public Weight As Object

    <Range(300, 3000)> _
    Public ListPrice As Object

    <Range(GetType(DateTime), "1/2/2004", "3/4/2004", _
           ErrorMessage:="Value for {0} must be between {1} and {2}")> _
    Public SellEndDate As Object

End Class
