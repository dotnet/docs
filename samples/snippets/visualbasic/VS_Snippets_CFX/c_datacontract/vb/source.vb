Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization

Namespace Example
    '<snippet1>
    <ServiceContract()> _
    Public Interface ISampleInterface
        ' No data contract is required since both the parameter and return 
        ' types are both primitive types.
        <OperationContract()> _
        Function SquareRoot(ByVal root As Integer) As Double

        ' No Data Contract required because both parameter and return 
        ' types are marked with the SerializableAttribute attribute.
        <OperationContract()> _
        Function GetPicture(ByVal pictureUri As System.Uri) As System.Drawing.Bitmap

        ' The MyTypes.PurchaseOrder is a complex type, and thus 
        ' requires a data contract.
        <OperationContract()> _
        Function ApprovePurchaseOrder(ByVal po As MyTypes.PurchaseOrder) As Boolean
    End Interface
    '</snippet1>

    NotInheritable Public Class Test

        Private Sub New()

        End Sub

        Shared Sub Main()

        End Sub
    End Class
End Namespace


'<snippet2>
Namespace MyTypes
    <System.Runtime.Serialization.DataContractAttribute()> _
    Public Class PurchaseOrder
        Private poId_value As Integer

        ' Apply the DataMemberAttribute to the property.

        <DataMember()> _
        Public Property PurchaseOrderId() As Integer

            Get
                Return poId_value
            End Get
            Set
                poId_value = value
            End Set
        End Property
    End Class
End Namespace
'</snippet2>

Namespace GenericTypes

    '<snippet3>
    <DataContract()> _
    Public Class MyGenericType1(Of T)
        ' Code not shown.
    End Class
    '</snippet3>

    '<snippet4>
    <DataContract()> _
    Public Class MyGenericType2(Of T)
        <DataMember()> _
        Dim theData As T
    End Class
    '</snippet4>
End Namespace

Namespace Intro

    '<snippet5>
    <DataContractAttribute> _
    Public Class Person
        <DataMemberAttribute> _
        Private Name As String

        Private NickName As String
        <DataMemberAttribute> _
        Private Address As Address
    End Class

    <DataContractAttribute()> _
    Public Class Address
        <DataMemberAttribute()> _
        Private AddressLine1 As String
        <DataMemberAttribute()> _
        Private AddressLine2 As String
        <DataMemberAttribute()> _
        Private AddressLine3 As String
        <DataMemberAttribute()> _
        Private DityName As String
        <DataMemberAttribute()> _
        Private Postcode As String
        <DataMemberAttribute()> _
        Private CountryName As String
    End Class
    '</snippet5>
End Namespace


Namespace Intro2
    '<snippet6>
    Public Class Person
        Private Name As String
        Private NickName As String
        Private Address As Address
    End Class

    Public Class Address
        Private AddressLine1 As String
        Private AddressLine2 As String
        Private AddressLine3 As String
        Private CityName As String
        Private PostCode As String
        Private CountryName As String
    End Class
    '</snippet6>
End Namespace

Namespace ForwardCompatible1
    '<snippet7>
    <DataContract()> _
    Public Class Person
        <DataMember()> _
        Public fullName As String
    End Class
    '</snippet7>
End Namespace

Namespace ForwardCompatible
    '<snippet8>
    <DataContract()> _
    Public Class Person
        Implements IExtensibleDataObject
        <DataMember()> _
        Public fullName As String
        Private theData As ExtensionDataObject


        Public Overridable Property ExtensionData() As _
         ExtensionDataObject Implements _
         IExtensibleDataObject.ExtensionData
            Get
                Return theData
            End Get
            Set
                theData = value
            End Set
        End Property
    End Class
    '</snippet8>
End Namespace

Namespace VersionTolerantCallback
    '<snippet9>
    ' The following Data Contract is version 2 of an earlier data 
    ' contract.
    <DataContract()> _
    Public Class Address
        <DataMember()> _
        Public Street As String
        <DataMember()> _
        Public State As String

        ' This data member was added in version 2, and thus may be missing 
        ' in the incoming data if the data conforms to version 1 of the 
        ' Data Contract.
        <DataMember(Order:=2)> _
        Public CountryRegion As String

        ' This method is used as a kind of constructor to initialize
        ' a default value for the CountryRegion data member before 
        ' deserialization.
        <OnDeserializing()> _
        Private Sub setDefaultCountryRegion(ByVal c As StreamingContext)
            CountryRegion = "Japan"
        End Sub
    End Class
    '</snippet9>
End Namespace
