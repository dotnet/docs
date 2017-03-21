
Imports System
Imports System.Configuration




' Define a custom section that contains a custom
' UrlsCollection collection of custom UrlConfigElement elements.
' This class shows how to use the ConfigurationCollectionAttribute.
Public Class UrlsSection
	Inherits ConfigurationSection
    ' Declare the Urls collection property using the
    ' ConfigurationCollectionAttribute.
    ' This allows to build a nested section that contains
    ' a collection of elements.
    <ConfigurationProperty("urls", IsDefaultCollection:=False),
        System.Configuration.ConfigurationCollection(GetType(UrlsCollection),
        AddItemName:="add", ClearItemsName:="clear", RemoveItemName:="remove")> _
    Public ReadOnly Property Urls() As UrlsCollection
        Get
            Dim urlsCollection As UrlsCollection = CType(MyBase.Item("urls"), UrlsCollection)
            Return urlsCollection
        End Get
    End Property

End Class

' Define the custom UrlsCollection that contains the 
' custom UrlsConfigElement elements.
Public Class UrlsCollection
    Inherits ConfigurationElementCollection
    Public Sub New()
        Dim url As UrlConfigElement = CType(CreateNewElement(), UrlConfigElement)
        Add(url)
    End Sub

    Public Overrides ReadOnly Property CollectionType() As ConfigurationElementCollectionType
        Get
            Return ConfigurationElementCollectionType.AddRemoveClearMap
        End Get
    End Property

    Protected Overloads Overrides Function CreateNewElement() As ConfigurationElement
        Return New UrlConfigElement()
    End Function

    Protected Overrides Function GetElementKey(ByVal element As ConfigurationElement) As Object
        Return (CType(element, UrlConfigElement)).Name
    End Function

    Default Shadows Property Item(ByVal index As Integer) As UrlConfigElement
        Get
            Return CType(BaseGet(index), UrlConfigElement)
        End Get
        Set(ByVal value As UrlConfigElement)
            If BaseGet(index) IsNot Nothing Then
                BaseRemoveAt(index)
            End If
            BaseAdd(index, value)
        End Set
    End Property

    Default Public Shadows ReadOnly Property Item(ByVal Name As String) As UrlConfigElement
        Get
            Return CType(BaseGet(Name), UrlConfigElement)
        End Get
    End Property

    Public Function IndexOf(ByVal url As UrlConfigElement) As Integer
        Return BaseIndexOf(url)
    End Function

    Public Sub Add(ByVal url As UrlConfigElement)
        BaseAdd(url)
    End Sub
    Protected Overloads Overrides Sub BaseAdd(ByVal element As ConfigurationElement)
        BaseAdd(element, False)
    End Sub

    Public Sub Remove(ByVal url As UrlConfigElement)
        If BaseIndexOf(url) >= 0 Then
            BaseRemove(url.Name)
        End If
    End Sub

    Public Sub RemoveAt(ByVal index As Integer)
        BaseRemoveAt(index)
    End Sub

    Public Sub Remove(ByVal name As String)
        BaseRemove(name)
    End Sub

    Public Sub Clear()
        BaseClear()
    End Sub
End Class

' Define the custom UrlsConfigElement elements that are contained 
' by the custom UrlsCollection.
Public Class UrlConfigElement
    Inherits ConfigurationElement
    Public Sub New(ByVal name As String, ByVal url As String)
        Me.Name = name
        Me.Url = url
    End Sub

    Public Sub New()
        Me.Name = "Contoso"
        Me.Url = "http://www.contoso.com"
        Me.Port = 0
    End Sub

    <ConfigurationProperty("name", DefaultValue:="Contoso", IsRequired:=True, IsKey:=True)> _
    Public Property Name() As String
        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property

    <ConfigurationProperty("url", DefaultValue:="http://www.contoso.com", IsRequired:=True),
        RegexStringValidator("\w+:\/\/[\w.]+\S*")> _
    Public Property Url() As String
        Get
            Return CStr(Me("url"))
        End Get
        Set(ByVal value As String)
            Me("url") = value
        End Set
    End Property

    <ConfigurationProperty("port", DefaultValue:=0, IsRequired:=False),
        IntegerValidator(MinValue:=0, MaxValue:=8080, ExcludeRange:=False)> _
    Public Property Port() As Integer
        Get
            Return CInt(Fix(Me("port")))
        End Get
        Set(ByVal value As Integer)
            Me("port") = value
        End Set
    End Property
End Class
