Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Security.Permissions

Namespace SerializationGuidelines


    Public Class Test

        Shared Sub Main()

            Dim p As Person = New Person("John", "Lennon")
            Dim p2 As Person2 = New Person2("John", "Lennon")
            Console.WriteLine("Done")
            Console.ReadLine()
        End Sub
    End Class

    '<snippet1>
    <DataContract()> Public Class Person
        <DataMember()> Public Property LastName As String
        <DataMember()> Public Property FirstName As String

        Public Sub New(ByVal firstNameValue As String, ByVal lastNameValue As String)
            FirstName = firstNameValue
            LastName = lastNameValue
        End Sub

    End Class
    '</snippet1>

    '<snippet2>
    <DataContract()> Class Person2
        Private lastNameValue As String
        Private firstNameValue As String

        Public Sub New(ByVal firstName As String, ByVal lastName As String)
            Me.lastNameValue = lastName
            Me.firstNameValue = firstName
        End Sub

        <DataMember()> Property LastName As String
            Get
                Return lastNameValue
            End Get

            Set(ByVal value As String)
                lastNameValue = value
            End Set

        End Property

        <DataMember()> Property FirstName As String
            Get
                Return firstNameValue

            End Get
            Set(ByVal value As String)
                firstNameValue = value
            End Set
        End Property

    End Class
    '</snippet2>


    '<snippet3>
    <DataContract()> _
    Class Person3
        <DataMember()> Private lastNameValue As String
        <DataMember()> Private firstNameValue As String
        Dim fullNameValue As String

        Public Sub New(ByVal firstName As String, ByVal lastName As String)
            lastNameValue = lastName
            firstNameValue = firstName
            fullNameValue = firstName & " " & lastName
        End Sub

        Public ReadOnly Property FullName As String
            Get
                Return fullNameValue
            End Get
        End Property

        <OnDeserialized()> Sub OnDeserialized(ByVal context As StreamingContext)
            fullNameValue = firstNameValue & " " & lastNameValue
        End Sub
    End Class
    '</snippet3>

    '<snippet4>
    <KnownType(GetType(USAddress)), _
    DataContract()> Class Person4
        <DataMember()> Property fullNameValue As String
        <DataMember()> Property addressValue As USAddress ' Address is abstract

        Public Sub New(ByVal fullName As String, ByVal address As Address)
            fullNameValue = fullName
            addressValue = address
        End Sub

        Public ReadOnly Property FullName() As String
            Get
                Return fullNameValue
            End Get

        End Property
    End Class

    <DataContract()> Public MustInherit Class Address
        Public MustOverride Function FullAddress() As String
    End Class

    <DataContract()> Public Class USAddress
        Inherits Address
        <DataMember()> Public Property Street As String
        <DataMember()> Public City As String
        <DataMember()> Public State As String
        <DataMember()> Public ZipCode As String

        Public Overrides Function FullAddress() As String
            Return Street & "\n" & City & ", " & State & " " & ZipCode
        End Function
    End Class
    '</snippet4>

    '<snippet5>
    <DataContract()> Class Person5
        Implements IExtensibleDataObject
        <DataMember()> Dim fullNameValue As String

        Public Sub New(ByVal fullName As String)
            fullName = fullName
        End Sub

        Public ReadOnly Property FullName
            Get
                Return fullNameValue
            End Get
        End Property
        Private serializationData As ExtensionDataObject
        Public Property ExtensionData As ExtensionDataObject Implements IExtensibleDataObject.ExtensionData
            Get
                Return serializationData
            End Get
            Set(ByVal value As ExtensionDataObject)
                serializationData = value
            End Set
        End Property
    End Class
    '</snippet5>

    '<snippet6>
    Public Class Address2
        ' Supports XML Serialization.
        <System.Xml.Serialization.XmlAttribute()> _
        Public ReadOnly Property Name As String ' Serialize as XML attribute, instead of an element.
            Get
                Return "Poe, Toni"
            End Get
        End Property
        <System.Xml.Serialization.XmlElement(ElementName:="StreetLine")> _
        Public Street As String = "1 Main Street"  ' Explicitly names the element 'StreetLine'.
    End Class
    '</snippet6>

    '<snippet7>
    <Serializable()> Public Class Person6 ' Support runtime serialization with the SerializableAttribute.

        ' Code not shown.
    End Class
    '</snippet7>

    '<snippet8>
    ' Implement the ISerializable interface for more control.
    <Serializable()> Public Class Person_Runtime_Serializable
        Implements ISerializable

        Private fullNameValue As String

        Public Sub New()
            ' empty constructor.
        End Sub
        '<snippet9>
        Protected Sub New(ByVal info As SerializationInfo, _
                          ByVal context As StreamingContext)
            '</snippet9>
            If info Is Nothing Then
                Throw New System.ArgumentNullException("info")
                FullName = CType(info.GetValue("name", GetType(String)), String)
            End If
        End Sub

        '<Snippet10>
        Private Sub GetObjectData(ByVal info As SerializationInfo, _
                                  ByVal context As StreamingContext) _
                              Implements ISerializable.GetObjectData
            '</Snippet10>
            If info Is Nothing Then
                Throw New System.ArgumentNullException("info")
            End If
            info.AddValue("name", FullName)
        End Sub

        Public Property FullName As String

            Get
                Return fullNameValue
            End Get
            Set(ByVal value As String)
                fullNameValue = value

            End Set
        End Property

    End Class

    '</snippet8>
    '<Snippet11>
    <Serializable()> Public Class Person_Runtime_Serializable2
        Implements ISerializable
        <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)> _
        Private Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, _
                                 ByVal context As System.Runtime.Serialization.StreamingContext) _
                             Implements System.Runtime.Serialization.ISerializable.GetObjectData
            ' Code not shown.
        End Sub
    End Class
    '</Snippet11>
End Namespace
