Imports System
Imports System.Configuration
Imports System.Collections

Public Class UrlsCollection
    Inherits ConfigurationElementCollection

    Public Sub New()
        ' Add one url to the collection.  This is
        ' not necessary; could leave the collection 
        ' empty until items are added to it outside
        ' the constructor.
        Dim url As UrlConfigElement = _
            CType(CreateNewElement(), UrlConfigElement)
        ' Add the element to the collection.
        Add(url)
    End Sub 'New

    Public Overrides ReadOnly Property CollectionType() _
        As ConfigurationElementCollectionType

        Get
            Return ConfigurationElementCollectionType.AddRemoveClearMap
        End Get
    End Property

    Protected Overloads Overrides Function CreateNewElement() _
        As ConfigurationElement

        Return New UrlConfigElement()
    End Function 'CreateNewElement

    Protected Overloads Overrides Function CreateNewElement( _
        ByVal elementName As String) _
        As ConfigurationElement

        Return New UrlConfigElement(elementName)
    End Function 'CreateNewElement

    Protected Overrides Function GetElementKey( _
        ByVal element As ConfigurationElement) As [Object]

        Return CType(element, UrlConfigElement).Name
    End Function 'GetElementKey

    Public Shadows Property AddElementName() As String

        Get
            Return MyBase.AddElementName
        End Get

        Set(ByVal value As String)
            MyBase.AddElementName = value
        End Set
    End Property

    Public Shadows Property ClearElementName() As String
        Get
            Return MyBase.ClearElementName
        End Get

        Set(ByVal value As String)
            MyBase.ClearElementName = value
        End Set
    End Property

    Public Shadows ReadOnly Property RemoveElementName() As String
        Get
            Return MyBase.RemoveElementName
        End Get
    End Property

    Public Shadows ReadOnly Property Count() As Integer
        Get
            Return MyBase.Count
        End Get
    End Property

    Default Public Shadows Property Item( _
    ByVal index As Integer) As UrlConfigElement
        Get
            Return CType(BaseGet(index), UrlConfigElement)
        End Get

        Set(ByVal value As UrlConfigElement)
            If Not (BaseGet(index) Is Nothing) Then
                BaseRemoveAt(index)
            End If
            BaseAdd(index, value)
        End Set
    End Property

    Default Public Shadows ReadOnly Property Item( _
        ByVal Name As String) As UrlConfigElement

        Get
            Return CType(BaseGet(Name), UrlConfigElement)
        End Get
    End Property

    Public Function IndexOf( _
        ByVal url As UrlConfigElement) As Integer

        Return BaseIndexOf(url)
    End Function 'IndexOf

    Public Sub Add(ByVal url As UrlConfigElement)
        BaseAdd(url)
        ' Add custom code here.
    End Sub 'Add

    Protected Overrides Sub BaseAdd( _
    ByVal element As ConfigurationElement)
        BaseAdd(element, False)
        ' Add custom code here.
    End Sub 'BaseAdd

    Public Overloads Sub Remove( _
        ByVal url As UrlConfigElement)

        If BaseIndexOf(url) >= 0 Then
            BaseRemove(url.Name)
        End If
    End Sub 'Remove

    Public Sub RemoveAt(ByVal index As Integer)
        BaseRemoveAt(index)
    End Sub 'RemoveAt

    Public Overloads Sub Remove(ByVal name As String)
        BaseRemove(name)
    End Sub 'Remove    

    Public Sub Clear()
        BaseClear()
    End Sub 'Clear ' 
End Class 'UrlsCollection