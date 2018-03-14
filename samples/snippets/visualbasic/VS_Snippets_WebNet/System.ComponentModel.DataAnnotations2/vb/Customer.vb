'C:\_ricka08\code\DD\Walk\VB_DataType\App_Code\Customer.vb
' C:\sdtree\Orcas\Web.NET\System.ComponentModel.DataAnnotations2

'<snippet1>
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(CustomerMetaData))> _
Partial Public Class Customer

End Class


Public Class CustomerMetaData

    <ScaffoldColumn(False)> _
    Public PasswordHash As Object

    <ScaffoldColumn(False)> _
    Public PasswordSalt As Object

    <DataTypeAttribute(DataType.Date)> _
    Public ModifiedDate As Object

    <DataTypeAttribute(DataType.EmailAddress)> _
    Public EmailAddress As Object

    <DataTypeAttribute(DataType.Url)> _
    Public SalesPerson As Object


    <DataTypeAttribute("BoldRed")> _
    <DisplayName("Last")> _
    Public ReadOnly Property LastName() As Object
        Get
            Return ""
        End Get
    End Property

End Class
'</snippet1>