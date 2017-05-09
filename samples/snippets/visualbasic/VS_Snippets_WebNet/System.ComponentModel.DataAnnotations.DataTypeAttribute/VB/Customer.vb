'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(CustomerMetadata))> _
Partial Public Class Customer


End Class

Public Class CustomerMetadata

    '<Snippet11>
    ' Add type information.
    <DataType(DataType.EmailAddress)> _
    Public EmailAddress As Object
    '</Snippet11>

End Class

'</Snippet1>