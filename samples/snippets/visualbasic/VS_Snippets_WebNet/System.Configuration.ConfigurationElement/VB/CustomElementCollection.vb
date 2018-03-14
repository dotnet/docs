' File name: CustomElementCollection.cs
' Allowed snippet tags range: [51 - 70].

'<Snippet51>
Imports System
Imports System.Configuration
Imports System.Collections

Public Class UrlsCollection
    Inherits ConfigurationElementCollection

    '<Snippet52>
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
    '</Snippet52>

    '<Snippet53>    
    Public Overrides ReadOnly Property CollectionType() _
        As ConfigurationElementCollectionType

        Get
            Return ConfigurationElementCollectionType.AddRemoveClearMap
        End Get
    End Property
    '</Snippet53>

    '<Snippet54>
    Protected Overloads Overrides Function CreateNewElement() _
        As ConfigurationElement

        Return New UrlConfigElement()
    End Function 'CreateNewElement
    '</Snippet54>

    '<Snippet55>
    Protected Overloads Overrides Function CreateNewElement( _
        ByVal elementName As String) _
        As ConfigurationElement

        Return New UrlConfigElement(elementName)
    End Function 'CreateNewElement
    '</Snippet55>

    '<Snippet56>
    Protected Overrides Function GetElementKey( _
        ByVal element As ConfigurationElement) As [Object]

        Return CType(element, UrlConfigElement).Name
    End Function 'GetElementKey
    '</Snippet56>

    ' <Snippet57>
    Public Shadows Property AddElementName() As String

        Get
            Return MyBase.AddElementName
        End Get

        Set(ByVal value As String)
            MyBase.AddElementName = value
        End Set
    End Property
    ' </Snippet57>

    ' <Snippet58>
    Public Shadows Property ClearElementName() As String
        Get
            Return MyBase.ClearElementName
        End Get

        Set(ByVal value As String)
            MyBase.ClearElementName = value
        End Set
    End Property
    ' </Snippet58>

    ' <Snippet59>
    Public Shadows ReadOnly Property RemoveElementName() As String
        Get
            Return MyBase.RemoveElementName
        End Get
    End Property
    ' </Snippet59>

    '<Snippet60>
    Public Shadows ReadOnly Property Count() As Integer
        Get
            Return MyBase.Count
        End Get
    End Property
    '</Snippet60>

    '<Snippet61>
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
    '</Snippet61>

    '<Snippet62>
    Default Public Shadows ReadOnly Property Item( _
        ByVal Name As String) As UrlConfigElement

        Get
            Return CType(BaseGet(Name), UrlConfigElement)
        End Get
    End Property
    '</Snippet62>

    '<Snippet63>
    Public Function IndexOf( _
        ByVal url As UrlConfigElement) As Integer

        Return BaseIndexOf(url)
    End Function 'IndexOf
    '</Snippet63>

    '<Snippet64>
    Public Sub Add(ByVal url As UrlConfigElement)
        BaseAdd(url)
        ' Add custom code here.
    End Sub 'Add
    '</Snippet64>

    '<Snippet65>
    Protected Overrides Sub BaseAdd( _
    ByVal element As ConfigurationElement)
        BaseAdd(element, False)
        ' Add custom code here.
    End Sub 'BaseAdd
    '</Snippet65>        

    '<Snippet66>
    Public Overloads Sub Remove( _
        ByVal url As UrlConfigElement)

        If BaseIndexOf(url) >= 0 Then
            BaseRemove(url.Name)
        End If
    End Sub 'Remove
    '</Snippet66>

    '<Snippet67>
    Public Sub RemoveAt(ByVal index As Integer)
        BaseRemoveAt(index)
    End Sub 'RemoveAt
    '</Snippet67>

    '<Snippet68>
    Public Overloads Sub Remove(ByVal name As String)
        BaseRemove(name)
    End Sub 'Remove    
    '</Snippet68>

    '<Snippet69>
    Public Sub Clear()
        BaseClear()
    End Sub 'Clear ' 
    '</Snippet69>
End Class 'UrlsCollection
'</Snippet51>