Imports System.Runtime.Serialization
Imports System.Collections.Generic
Imports System.Collections
Imports System.Security.Permissions



Public NotInheritable Class Test

    Private Sub New()

    End Sub

    Shared Sub Main()
        SayHello()

    End Sub


    Shared Function SayHello() As String
        Return "Hello"

    End Function
End Class
' <snippet1>
<DataContract()> _
Public Class Shape
End Class

<DataContract(Name:="Circle")> _
Public Class CircleType
    Inherits Shape
End Class
<DataContract(Name:="Triangle")> _
Public Class TriangleType
    Inherits Shape
End Class
' </snippet1>

' <snippet2>
<DataContract()> _
Public Class CompanyLogo
    <DataMember()> _
    Private ShapeOfLogo As Shape
    <DataMember()> _
    Private ColorOfLogo As Integer
End Class
' </snippet2>

' <snippet3>
<DataContract(), KnownType(GetType(CircleType)), KnownType(GetType(TriangleType))> _
Public Class CompanyLogo2
    <DataMember()> _
    Private ShapeOfLogo As Shape
    <DataMember()> _
    Private ColorOfLogo As Integer
End Class
' </snippet3>

' <snippet4>
Public Interface ICustomerInfo
    Function ReturnCustomerName() As String
End Interface

<DataContract(Name:="Customer")> _
Public Class CustomerTypeA
    Implements ICustomerInfo
    Public Function ReturnCustomerName() _
    As String Implements ICustomerInfo.ReturnCustomerName
        Return "no name"
    End Function
End Class

<DataContract(Name:="Customer")> _
Public Class CustomerTypeB
    Implements ICustomerInfo
    Public Function ReturnCustomerName() _
    As String Implements ICustomerInfo.ReturnCustomerName
        Return "no name"
    End Function
End Class

<DataContract(), KnownType(GetType(CustomerTypeB))> _
Public Class PurchaseOrder
    <DataMember()> _
    Private buyer As ICustomerInfo

    <DataMember()> _
    Private amount As Integer
End Class
'</snippet4>
'<snippet5>
<DataContract()> _
Public Class Book
End Class

<DataContract()> _
Public Class Magazine
End Class

<DataContract(), KnownType(GetType(Book)), KnownType(GetType(Magazine))> _
Public Class LibraryCatalog
    <DataMember()> _
    Private theCatalog As System.Collections.Hashtable
End Class
'</snippet5>

'<snippet6>
<DataContract(), KnownType(GetType(Integer()))> _
Public Class MathOperationData
    Private numberValue As Object

    <DataMember()> _
    Public Property Numbers() As Object
        Get
            Return numberValue
        End Get
        Set(ByVal value As Object)
            numberValue = value
        End Set
    End Property
End Class
'</snippet6>

Public NotInheritable Class MathService
    Private Sub New()
    End Sub
    '<snippet7>
    ' This is in the service application code:
    Shared Sub Run()
        Dim md As New MathOperationData()
        ' This will serialize and deserialize successfully because primitive 
        ' types like int are always known.
        Dim a As Integer = 100
        md.Numbers = a

        ' This will serialize and deserialize successfully because the array of 
        ' integers was added to known types.
        Dim b(99) As Integer
        md.Numbers = b

        ' This will serialize and deserialize successfully because the generic 
        ' List(Of Integer) is equivalent to Integer(), which was added to known types.
        Dim c As List(Of Integer) = New List(Of Integer)()
        md.Numbers = c
        ' This will serialize but will not deserialize successfully because 
        ' ArrayList is a non-generic collection, which is equivalent to 
        ' an array of type object. To make it succeed, object[]
        ' must be added to the known types.
        Dim d As New ArrayList()
        md.Numbers = d

    End Sub
    '</snippet7>
End Class


Public Class Square
End Class

Public Class Circle
End Class

'<snippet8>
<DataContract(), KnownType(GetType(Square)), KnownType(GetType(Circle))> _
Public Class MyDrawing
    <DataMember()> _
    Private Shape As Object
    <DataMember()> _
    Private Color As Integer
End Class

<DataContract()> _
Public Class DoubleDrawing
    Inherits MyDrawing
    <DataMember()> _
    Private additionalShape As Object
End Class
'</snippet8>

Public MustInherit Class GenericDrawing(Of T)
End Class

'<snippet9>
<DataContract()> _
Public Class DrawingRecord(Of T)
    <DataMember()> _
    Private theData As T
    <DataMember()> _
    Private theDrawing As GenericDrawing(Of T)
End Class
'</snippet9>

Public Class ColorDrawing(Of T)
    Inherits GenericDrawing(Of T)
End Class

Public Class BlackAndWhiteDrawing(Of T)
    Inherits GenericDrawing(Of T)
End Class

'<snippet10>
<DataContract(), KnownType("GetKnownType")> _
Public Class DrawingRecord2(Of T)
    Private TheData As T
    Private TheDrawing As GenericDrawing(Of T)

    Private Shared Function GetKnownType() As Type()
        Dim t(1) As Type
        t(0) = GetType(ColorDrawing(Of T))
        t(1) = GetType(BlackAndWhiteDrawing(Of T))
        Return t
    End Function
End Class
'</snippet10>
