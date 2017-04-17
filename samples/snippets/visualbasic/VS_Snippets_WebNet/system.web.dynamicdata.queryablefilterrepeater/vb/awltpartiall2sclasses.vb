'<Snippet4>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.ComponentModel.DataAnnotations
Imports System.Web.DynamicData

'Define the enumeration to apply
'to the OrderQty data field.
'This enumeration is used for filtering.
Public Enum QtyEnum
    None = 0
    Small1 = 1
    Small2 = 2
    Small3 = 3
    Medium10 = 10
    Medium11 = 11
    Medium12 = 12
    Medium13 = 13
    Medium14 = 14
    Large21 = 21
    Large22 = 22
    Large23 = 23
    XLarge60 = 60
    XLarge70 = 70
End Enum

<MetadataType(GetType(SalesOrderDetail_MD))> _
Partial Public Class SalesOrderDetail


End Class

Public Class SalesOrderDetail_MD
    Private _oq As Object

    'Qualify the OrderQty field 
    'with the applicable 
    'enumeration type.
    <EnumDataType(GetType(QtyEnum))> _
    Public Property OrderQty() As Object
        Get
            Return _oq
        End Get
        Set(ByVal value As Object)
            _oq = value
        End Set
    End Property
End Class
'</Snippet4>

