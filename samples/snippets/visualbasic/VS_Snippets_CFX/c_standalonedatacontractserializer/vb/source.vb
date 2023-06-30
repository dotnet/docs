Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Xml

'<snippet1>
<DataContract()> _
Public Class Person
    ' Code not shown.
End Class

<DataContract()> _
Public Class PurchaseOrder
    ' Code not shown.
End Class
'</snippet1>

Public Class Test

    Private Sub Run()
        '<snippet2>
        Dim dcs As New DataContractSerializer(GetType(Person))
        ' This can now be used to serialize/deserialize Person but not PurchaseOrder.
        '</snippet2>
    End Sub

    '<snippet3>
    <DataContract()> _
    Public Class LibraryPatron
        <DataMember()> _
        Public borrowedItems() As LibraryItem
    End Class

    <DataContract()> _
    Public Class LibraryItem
        ' Code not shown.
    End Class

    <DataContract()> _
    Public Class Book
        Inherits LibraryItem
        ' Code not shown.
    End Class

    <DataContract()> _
    Public Class Newspaper
        Inherits LibraryItem
        ' Code not shown.
    End Class
    '</snippet3>

    Private Sub Run2()
        '<snippet4>
        ' Create a serializer for the inherited types using the knownType parameter.
        Dim knownTypes() As Type = {GetType(Book), GetType(Newspaper)}
        Dim dcs As New DataContractSerializer(GetType(LibraryPatron), knownTypes)
        ' All types are known after construction.
        '</snippet4>
    End Sub
End Class

'<snippet5>
<DataContract(Name:="PersonContract", [Namespace]:="http://schemas.contoso.com")> _
Public Class Person2
    <DataMember(Name:="AddressMember")> _
    Public theAddress As Address
End Class

<DataContract(Name:="AddressContract", [Namespace]:="http://schemas.contoso.com")> _
Public Class Address
    <DataMember(Name:="StreetMember")> _
    Public street As String
End Class
'</snippet5>

Public Class Test2

    Private Sub Serialize(ByVal path As String)
        Dim someStream As New FileStream(path, FileMode.Open)

        '<snippet8>
        Dim p As New Person()
        Dim dcs As New DataContractSerializer(GetType(Person))
        Dim xdw As XmlDictionaryWriter = _
            XmlDictionaryWriter.CreateTextWriter(someStream, Encoding.UTF8)
        dcs.WriteObject(xdw, p)
        '</snippet8>

        '<snippet9>
        dcs.WriteStartObject(xdw, p)
        xdw.WriteAttributeString("serializedBy", "myCode")
        dcs.WriteObjectContent(xdw, p)
        dcs.WriteEndObject(xdw)
        '</snippet9>

        '<snippet10>
        xdw.WriteStartElement("MyCustomWrapper")
        dcs.WriteObjectContent(xdw, p)
        xdw.WriteEndElement()
        '</snippet10>
    End Sub

    Private Sub Deserialize(ByVal path As String)
        '<snippet11>
        Dim dcs As New DataContractSerializer(GetType(Person))
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
           XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())

        Dim p As Person = CType(dcs.ReadObject(reader), Person)
        '</snippet11> 
    End Sub
End Class

Namespace ServiceModelSamples2

    Public Class Test

        Private Sub Run()
            '<snippet7>
            ' Construct a purchase order:
            Dim adr As New Address()
            adr.street = "123 Main St."
            Dim po As New PurchaseOrder()
            po.billTo = adr
            po.shipTo = adr
            '</snippet7>
        End Sub

        Private Sub CheckNodeType(ByVal path As String)

            '<snippet12>
            Dim ser As New DataContractSerializer(GetType(Person), "Customer", "http://www.contoso.com")
            Dim fs As New FileStream(path, FileMode.Open)
            Dim reader As XmlDictionaryReader = XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())

            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        If ser.IsStartObject(reader) Then
                            Console.WriteLine("Found the element")
                            Dim p As Person = CType(ser.ReadObject(reader), Person)
                            Console.WriteLine("{0} {1}", _
                                               p.Name, p.Address)
                        End If
                        Console.WriteLine(reader.Name)
                End Select
            End While
            '</snippet12>
        End Sub
    End Class


    '<snippet6>
    <DataContract()> _
    Public Class PurchaseOrder

        <DataMember()> _
        Public billTo As Address

        <DataMember()> _
        Public shipTo As Address

    End Class

    <DataContract()> _
    Public Class Address

        <DataMember()> _
        Public street As String

    End Class
    '</snippet6>

    Public Class Person
        Public Name As String
        Public Address As String
    End Class
End Namespace
