'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations


<MetadataType(GetType(ProductMetaData))> _
Partial Public Class Product

End Class

Public Class ProductMetaData
   
    ' Applying DisplayFormatAttribute

    '<Snippet2>
    ' Display the text [Null] when the data field is empty.
    ' Also, convert empty string to null for storing.
    <DisplayFormat(ConvertEmptyStringToNull:=True, NullDisplayText:="[Null]")> _
    Public Size As Object
    '</Snippet2>

    '<Snippet3>
    ' Display currency data field in the format such as $1,345.50.
    <DisplayFormat(DataFormatString:="{0:C}")> _
    Public StandardCost As Object
    '</Snippet3>

    '<Snippet4>
    ' Display date data field in the short format such as 11/12/08.
    ' Also, apply format in edit mode.
    <DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:d}")> _
    Public SellStartDate As Object
    '</Snippet4>

End Class

'</Snippet1>
