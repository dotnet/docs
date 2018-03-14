
' <snippet11>
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Web.DynamicData


'<TableName("Prod Model Desc")> _
<MetadataType(GetType(ProductModelProductDescriptionMetaData))> _
<DisplayName("Modified")> _
Public Class ProductModelProductDescription

End Class


Public Class ProductModelProductDescriptionMetaData

    '<DisplayFormat(False, True, "{0:d}", True)> _
    <DisplayName("Modified")> _
    Public ReadOnly Property ModifiedDate() As Object
        Get
            Return ""
        End Get
    End Property


    <DisplayName("Description")> _
    Public ReadOnly Property ProductDescription() As Object
        Get
            Return ""
        End Get
    End Property

End Class

' </snippet11>

