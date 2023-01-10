'<snippet0>
Imports System.ServiceModel
Imports System.Net.Security
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.Serialization
Imports System.ComponentModel
Imports System.Collections.Generic

'</snippet0>

Namespace ImportExport1
    '<snippet1>
    Partial Class Vehicle
        Implements IExtensibleDataObject

        Private yearField As Integer
        Private colorField As String

        <DataMember()> _
        Public Property year() As Integer
            Get
                Return Me.yearField
            End Get
            Set
                Me.yearField = value
            End Set
        End Property

        <DataMember()> _
        Public Property color() As String
            Get
                Return Me.colorField
            End Get
            Set
                Me.colorField = value
            End Set
        End Property
        Private extensionDataField As ExtensionDataObject

        Public Property ExtensionData() As ExtensionDataObject _
            Implements IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(ByVal value As ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property
    End Class
    '</snippet1>
End Namespace

Namespace ImportExport2
    '<snippet2>
    Class Vehicle
        Implements IExtensibleDataObject
        Private yearField As Integer
        Private colorField As String

        <DataMember()> _
        Friend Property year() As Integer
            Get
                Return Me.yearField
            End Get
            Set
                Me.yearField = value
            End Set
        End Property

        <DataMember()> _
        Friend Property color() As String
            Get
                Return Me.colorField
            End Get
            Set
                Me.colorField = value
            End Set
        End Property
        Private extensionDataField As ExtensionDataObject

        Public Property ExtensionData() As ExtensionDataObject _
            Implements IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(ByVal value As ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property
    End Class
    '</snippet2>
End Namespace

Namespace ImportExport3
    '<snippet3>
    Namespace Contoso.Cars

        Class Vehicle
            Implements IExtensibleDataObject
            Private extensionDataField As ExtensionDataObject

            Public Property ExtensionData() As ExtensionDataObject _
                Implements IExtensibleDataObject.ExtensionData
                Get
                    Return Me.extensionDataField
                End Get
                Set(ByVal value As ExtensionDataObject)
                    Me.extensionDataField = value
                End Set
            End Property
        End Class
    End Namespace
    '</snippet3>

End Namespace
'<snippet4>
<DataContract(), Serializable()> _
Partial Class Vehicle
    Implements IExtensibleDataObject
    Private extensionDataField As ExtensionDataObject

    ' Code not shown.

    Public Property ExtensionData() As ExtensionDataObject _
        Implements IExtensibleDataObject.ExtensionData
        Get
            Return Me.extensionDataField
        End Get
        Set(ByVal value As ExtensionDataObject)
            Me.extensionDataField = value
        End Set
    End Property

End Class
'</snippet4>

Namespace ImporteExport4

    '<snippet5>
    Partial Class Vehicle
        Implements IExtensibleDataObject, INotifyPropertyChanged
        Private yearField As Integer
        Private colorField As String

        <DataMember()> _
        Public Property year() As Integer
            Get
                Return Me.yearField
            End Get
            Set
                If Me.yearField.Equals(value) <> True Then
                    Me.yearField = value
                    Me.RaisePropertyChanged("year")
                End If
            End Set
        End Property

        <DataMember()> _
        Public Property color() As String
            Get
                Return Me.colorField
            End Get
            Set
                If Me.colorField.Equals(value) <> True Then
                    Me.colorField = value
                    Me.RaisePropertyChanged("color")
                End If
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler _
          Implements INotifyPropertyChanged.PropertyChanged

        Private Sub RaisePropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, _
             New PropertyChangedEventArgs(propertyName))
        End Sub

        Private extensionDataField As ExtensionDataObject

        Public Property ExtensionData() As ExtensionDataObject _
            Implements IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(ByVal value As ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

    End Class
    '</snippet5>
End Namespace

Namespace ImportExport5
    '<snippet6>
    Public Partial Class Vehicle
        Implements IExtensibleDataObject

        <DataMember()> _
        Public yearField As Integer
        <DataMember()> _
        Public colorField As String
        <DataMember()> _
        Public passengers As people

        ' Other code not shown.

        Public Property ExtensionData() As ExtensionDataObject _
        Implements IExtensibleDataObject.ExtensionData
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
            Set
                Throw New Exception("The method or operation is not implemented.")
            End Set
        End Property
    End Class

    <CollectionDataContract(ItemName:="person")> _
    Public Class people
        Inherits List(Of String)
    End Class
    '</snippet6>
End Namespace
Namespace ImportExport6

    '<snippet7>
    <CollectionDataContract(ItemName:="person")> _
    Public Class people
        Inherits BindingList(Of String)
        '</snippet7>
    End Class
End Namespace

Namespace ImportExport7
    Sub Snippet
        ' <snippet8>
        Dim importer As New XsdDataContractImporter
        importer.Options.Namespaces.Add(New KeyValuePair(Of String, String)("http://schemas.contoso.com/carSchema", "Contoso.Cars"))
        ' </snippet8>
    End Sub

End Namespace
