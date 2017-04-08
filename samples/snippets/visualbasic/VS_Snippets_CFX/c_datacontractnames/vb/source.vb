Imports System
Imports System.Runtime.Serialization


'<snippet1>
' This overrides the standard namespace mapping for all contracts 
' in Contoso.CRM. 
<Assembly: ContractNamespace("http://schemas.example.com/crm", _
ClrNamespace:="Contoso.CRM")> 
Namespace Contoso.CRM
    ' The namespace is overridden to become: 
    ' http://schemas.example.com/crm.
    ' But the name is the default "Customer".
    <DataContract()> _
    Public Class Customer
        ' Code not shown.
    End Class
End Namespace

Namespace Contoso.OrderProc
    <DataContract()> _
    Public Class PurchaseOrder
        ' This data member is named "Amount" by default.
        <DataMember()> _
        Public Amount As Double

        ' The default is overridden to become "Address".
        <DataMember(Name:="Address")> _
        Public Ship_to As String
    End Class

    ' The namespace is the default value:
    ' http://schemas.datacontract.org/2004/07/Contoso.OrderProc
    ' The name is "PurchaseOrder" instead of "MyInvoice".
    <DataContract(Name:="PurchaseOrder")> _
    Public Class MyInvoice
        ' Code not shown.
    End Class

    ' The contract name is "Payment" instead of "MyPayment" 
    ' and the Namespace is "http://schemas.example.com" instead
    ' of the default.
    <DataContract(Name:="Payment", [Namespace]:="http://schemas.example.com")> _
    Public Class MyPayment
        ' Code not shown.
    End Class
End Namespace
'</snippet1>

Namespace Snippet2
    '<snippet2>
    <DataContract()> _
    Public Class Drawing(Of Shape, Brush)

        <DataContract([Namespace]:="urn:shapes")> _
        Public Class Square
            ' Code not shown.
        End Class


        <DataContract(Name:="RedBrush", [Namespace]:="urn:default")> _
        Public Class RegularRedBrush
            ' Code not shown.
        End Class

        <DataContract(Name:="RedBrush", [Namespace]:="urn:special")> _
        Public Class SpecialRedBrush
            ' Code not shown.
        End Class
    End Class
    '</snippet2>

    Namespace Snippet3
        '<snippet3>
        <DataContract(Name:="Drawing_using_{1}_brush_and_{0}_shape")> _
        Public Class Drawing(Of Shape, Brush)
            ' Code not shown.
        End Class
        '</snippet3>
    End Namespace

    Public Class Test

        Public Shared Sub Main()
        End Sub
    End Class
End Namespace

Namespace DataMemberOrder
    '<snippet4>
    <DataContract()> _
    Public Class BaseType
        <DataMember()> Public zebra As String
    End Class

    <DataContract()> _
    Public Class DerivedType
        Inherits BaseType
        <DataMember(Order:=0)> Public bird As String
        <DataMember(Order:=1)> Public parrot As String
        <DataMember()> Public dog As String
        <DataMember(Order:=3)> Public antelope As String
        <DataMember()> Public cat As String
        <DataMember(Order:=1)> Public albatross As String
    End Class
    '</snippet4>
End Namespace

Namespace DataContractEquivalence
    '<snippet5>
    <DataContract()> _
    Public Class Customer

        <DataMember()> _
        Public fullName As String

        <DataMember()> _
        Public telephoneNumber As String
    End Class

    <DataContract(Name:="Customer")> _
        Public Class Person

        <DataMember(Name:="fullName")> _
        Private nameOfPerson As String

        Private address As String

        <DataMember(Name:="telephoneNumber")> _
        Private phoneNumber As String
    End Class
    '</snippet5>

    '<snippet6>
    <DataContract(Name := "Coordinates")> _
    Public Class Coords1
        <DataMember()> _
        Public X As Integer
        <DataMember()> _
        Public Y As Integer
        ' Order is alphabetical (X,Y).
    End Class

    <DataContract(Name := "Coordinates")> _
    Public Class Coords2

        <DataMember()> _
        Public Y As Integer
        <DataMember()> _
        Public X As Integer
        ' Order is alphabetical (X,Y), equivalent 
        ' to the preceding code.
    End Class

    <DataContract(Name := "Coordinates")> _
    Public Class Coords3
        <DataMember(Order := 2)> _
        Public Y As Integer
        <DataMember(Order := 1)> _
        Public X As Integer
        ' Order is according to the Order property (X,Y), 
        ' equivalent to the preceding code.
    End Class
    '</snippet6>

    '<snippet7>
    <DataContract(Name := "Coordinates")> _
    Public Class Coords4

        <DataMember(Order := 1)> _
        Public Y As Integer
        <DataMember(Order := 2)> _
        Public X As Integer
        ' Order is according to the Order property (Y,X), 
        ' different from the preceding code.
    End Class
    '</snippet7>
End Namespace

Namespace DataContractEQ2
    '<snippet8>
    <DataContract()> _
    Public Class Person
        <DataMember()> Public name As String
    End Class

    <DataContract()> _
    Public Class Employee
        Inherits Person
        <DataMember()> Public department As Integer
        <DataMember()> Public title As String
        <DataMember()> Public salary As Integer
    End class 

    ' Order is "name", "department", "salary", "title" 
    ' (base class first, then alphabetical).

    <DataContract(Name:="Employee")> _
    Public Class Worker

        <DataMember(Order := 1)> _
        Public name As String
        <DataMember(Order := 2)> _
        Public department As Integer
        <DataMember(Order := 2)> _
        Public title As String
        <DataMember(Order := 2)> _
        Public salary As Integer
    End Class
    ' Order is "name", "department", "salary", "title" 
    ' (Order=1 first, then Order=2 in alphabetical order), 
    ' which is equivalent to the Employee order}.
    '</snippet8>
End Namespace