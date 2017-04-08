' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration

' Define a UrlsSection custom section that contains a 
' UrlsCollection collection of UrlConfigElement elements.
Public Class UrlsSection
    Inherits ConfigurationSection

    ' Declare the UrlsCollection collection property.
    <ConfigurationProperty("urls", IsDefaultCollection:=False), ConfigurationCollection(GetType(UrlsCollection), AddItemName:="add", ClearItemsName:="clear", RemoveItemName:="remove")>
    Public Property Urls() As UrlsCollection
        Get
            Dim urlsCollection As UrlsCollection = CType(MyBase.Item("urls"), UrlsCollection)

            Return urlsCollection
        End Get

        Set(ByVal value As UrlsCollection)
            Dim urlsCollection As UrlsCollection = value
        End Set

    End Property

    ' Create a new instance of the UrlsSection.
    ' This constructor creates a configuration element 
    ' using the UrlConfigElement default values.
    ' It assigns this element to the collection.
    Public Sub New()
        Dim url As New UrlConfigElement()
        Urls.Add(url)

    End Sub

End Class

' Define the UrlsCollection that contains the 
' UrlsConfigElement elements.
' This class shows how to use the ConfigurationElementCollection.
Public Class UrlsCollection
    Inherits System.Configuration.ConfigurationElementCollection


    Public Sub New()

    End Sub

    '<Snippet5>
    Public ReadOnly Property CollectionType() As ConfigurationElementCollectionType
        Get
            Return ConfigurationElementCollectionType.AddRemoveClearMap
        End Get
    End Property
    '</Snippet5>

    '<Snippet6>
    Protected Overloads Overrides Function CreateNewElement() As ConfigurationElement
        Return New UrlConfigElement()
    End Function
    '</Snippet6>

    '<Snippet7>
    Protected Overrides Function GetElementKey(ByVal element As ConfigurationElement) As Object
        Return (CType(element, UrlConfigElement)).Name
    End Function
    '</Snippet7>

    '<Snippet8>
    Default Public Shadows Property Item(ByVal index As Integer) As UrlConfigElement
        Get
            Return CType(BaseGet(index), UrlConfigElement)
        End Get
        Set(ByVal value As UrlConfigElement)
            If BaseGet(index) IsNot Nothing Then
                BaseRemoveAt(index)
            End If
            BaseAdd(value)
        End Set
    End Property
    '</Snippet8>

    '<Snippet9>
    Default Public Shadows ReadOnly Property Item(ByVal Name As String) As UrlConfigElement
        Get
            Return CType(BaseGet(Name), UrlConfigElement)
        End Get
    End Property
    '</Snippet9>

    '<Snippet10>
    Public Function IndexOf(ByVal url As UrlConfigElement) As Integer
        Return BaseIndexOf(url)
    End Function
    '</Snippet10>

    '<Snippet2>
    Public Sub Add(ByVal url As UrlConfigElement)
        BaseAdd(url)

        ' Your custom code goes here.

    End Sub
    ' </Snippet2>

    Protected Overloads Sub BaseAdd(ByVal element As ConfigurationElement)
        BaseAdd(element, False)

        ' Your custom code goes here.

    End Sub

    '<Snippet3>
    Public Sub Remove(ByVal url As UrlConfigElement)
        If BaseIndexOf(url) >= 0 Then
            BaseRemove(url.Name)
            ' Your custom code goes here.
            Console.WriteLine("UrlsCollection: {0}", "Removed collection element!")
        End If
    End Sub
    '</Snippet3>

    Public Sub RemoveAt(ByVal index As Integer)
        BaseRemoveAt(index)

        ' Your custom code goes here.

    End Sub

    Public Sub Remove(ByVal name As String)
        BaseRemove(name)

        ' Your custom code goes here.

    End Sub

    ' <Snippet4>
    Public Sub Clear()
        BaseClear()

        ' Your custom code goes here.
        Console.WriteLine("UrlsCollection: {0}", "Removed entire collection!")
    End Sub
    ' </Snippet4>

End Class

' Define the UrlsConfigElement elements that are contained 
' by the UrlsCollection.
Public Class UrlConfigElement
    Inherits ConfigurationElement
    Public Sub New(ByVal name As String, ByVal url As String, ByVal port As Integer)
        Me.Name = name
        Me.Url = url
        Me.Port = port
    End Sub

    Public Sub New()

    End Sub

    <ConfigurationProperty("name", DefaultValue:="Contoso", IsRequired:=True, IsKey:=True)>
    Public Property Name() As String
        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property

    <ConfigurationProperty("url", DefaultValue:="http://www.contoso.com", IsRequired:=True), RegexStringValidator("\w+:\/\/[\w.]+\S*")>
    Public Property Url() As String
        Get
            Return CStr(Me("url"))
        End Get
        Set(ByVal value As String)
            Me("url") = value
        End Set
    End Property

    <ConfigurationProperty("port", DefaultValue:=CInt(4040), IsRequired:=False), IntegerValidator(MinValue:=0, MaxValue:=8080, ExcludeRange:=False)>
    Public Property Port() As Integer
        Get
            Return CInt(Fix(Me("port")))
        End Get
        Set(ByVal value As Integer)
            Me("port") = value
        End Set
    End Property

End Class
'</Snippet1>