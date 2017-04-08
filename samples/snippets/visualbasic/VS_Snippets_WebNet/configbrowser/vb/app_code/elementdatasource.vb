' <Snippet80>
Imports Microsoft.VisualBasic
Imports System.Web.Configuration
Imports System.Configuration
Imports System.Reflection

''' <summary>
''' Retrieves a list of properties for an element or for each
''' item in an element collection. 
''' </summary>
Public Class ElementDataSource
    Public Sub New()
    End Sub

    Public Function GetElements(ByVal sectionName As String,
                                ByVal elementName As String,
                                ByVal virtualPath As String,
                                ByVal site As String,
                                ByVal locationSubPath As String,
                                ByVal server As String) _
                            As List(Of ElementItemHeaderInfo)

        Dim elementList As New List(Of ElementItemHeaderInfo)()

        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(virtualPath,
                                                         site,
                                                         locationSubPath,
                                                         server)

        Dim cs As ConfigurationSection = config.GetSection(sectionName)

        Dim sectionType As Type = cs.GetType()
        Dim reflectionElement As System.Reflection.PropertyInfo =
            sectionType.GetProperty(elementName)
        Dim elementObject As Object =
            reflectionElement.GetValue(cs, Nothing)

        Dim elementType As Type = elementObject.GetType()
        Dim reflectionProperty As System.Reflection.PropertyInfo =
            elementType.GetProperty("Count")

        If reflectionProperty IsNot Nothing Then
            Dim elementCount As Integer =
                Convert.ToInt32(reflectionProperty.GetValue(
                                elementObject, Nothing))
            For i As Integer = 0 To elementCount - 1
                Dim ei As New ElementItemHeaderInfo()
                ei.ItemName = String.Format(
                    "Item {0} of {1}", i + 1, elementCount)
                ei.Index = i
                ei.Name = elementName
                ei.SectionName = sectionName
                elementList.Add(ei)
            Next
        Else
            Dim ei As New ElementItemHeaderInfo()
            ei.Name = elementName
            ei.ItemName = "Item 1 of 1"
            ei.SectionName = sectionName
            elementList.Add(ei)
        End If
        Return elementList
    End Function

    Public Function GetProperties(ByVal sectionName As String,
                                  ByVal elementName As String,
                                  ByVal index As Integer,
                                  ByVal virtualPath As String,
                                  ByVal site As String,
                                  ByVal locationSubPath As String,
                                  ByVal server As String) _
                              As List(Of ElementItemInfo)

        Dim elementItemList As New List(Of ElementItemInfo)()

        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server)

        Dim cs As ConfigurationSection = config.GetSection(sectionName)

        Dim sectionType As Type = cs.GetType()
        Dim reflectionElement As System.Reflection.PropertyInfo =
            sectionType.GetProperty(elementName)
        Dim elementObject As Object =
            reflectionElement.GetValue(cs, Nothing)

        Dim elementType As Type = elementObject.GetType()
        Dim reflectionProperty As System.Reflection.PropertyInfo =
            elementType.GetProperty("Count")

        Dim elementCount As Integer = IIf(reflectionProperty Is Nothing,
            0, Convert.ToInt32(reflectionProperty.GetValue(
                               elementObject, Nothing)))

        If elementCount > 0 Then
            Dim i As Integer = 0
            Dim elementItems As ConfigurationElementCollection =
                TryCast(elementObject, ConfigurationElementCollection)
            For Each elementItem As ConfigurationElement In elementItems
                If i = index Then
                    elementObject = elementItem
                End If
                i += 1
            Next
        End If

        Dim reflectionItemType As Type = elementObject.GetType()
        Dim elementProperties As PropertyInfo() =
            reflectionItemType.GetProperties()

        For Each rpi As System.Reflection.PropertyInfo In elementProperties
            If rpi.Name <> "SectionInformation" _
                AndAlso rpi.Name <> "LockAttributes" _
                AndAlso rpi.Name <> "LockAllAttributesExcept" _
                AndAlso rpi.Name <> "LockElements" _
                AndAlso rpi.Name <> "LockAllElementsExcept" _
                AndAlso rpi.Name <> "LockItem" _
                AndAlso rpi.Name <> "Item" _
                AndAlso rpi.Name <> "ElementInformation" _
                AndAlso rpi.Name <> "CurrentConfiguration" Then

                Dim eii As New ElementItemInfo()
                eii.Name = rpi.Name
                eii.TypeName = rpi.PropertyType.ToString()
                Dim uniqueID As String = rpi.Name + index.ToString()
                eii.UniqueID = uniqueID.Replace("/", "")
                Dim indexParms As ParameterInfo() =
                    rpi.GetIndexParameters()
                If rpi.PropertyType Is GetType(IList) _
                    OrElse rpi.PropertyType Is GetType(ICollection) _
                    OrElse indexParms.Length > 0 Then

                    eii.Value = "List"
                Else
                    Dim propertyValue As Object =
                        rpi.GetValue(elementObject, Nothing)
                    eii.Value = IIf(propertyValue Is Nothing, "",
                                    propertyValue.ToString())
                End If
                elementItemList.Add(eii)
            End If
        Next
        Return elementItemList
    End Function
End Class

Public Class ElementItemHeaderInfo
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Private _ItemName As String
    Public Property ItemName() As String
        Get
            Return _ItemName
        End Get
        Set(ByVal value As String)
            _ItemName = value
        End Set
    End Property
    Private _SectionName As String
    Public Property SectionName() As String
        Get
            Return _SectionName
        End Get
        Set(ByVal value As String)
            _SectionName = value
        End Set
    End Property
    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Private _Index As Integer
    Public Property Index() As Integer
        Get
            Return _Index
        End Get
        Set(ByVal value As Integer)
            _Index = value
        End Set
    End Property
End Class

Public Class ElementItemInfo
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Private _TypeName As String
    Public Property TypeName() As String
        Get
            Return _TypeName
        End Get
        Set(ByVal value As String)
            _TypeName = value
        End Set
    End Property
    Public ReadOnly Property TypeNameUrl() As String
        Get
            Return "http://msdn.microsoft.com/en-us/library/" _
                & TypeName & ".aspx"
        End Get
    End Property
    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Private _UniqueID As String
    Public Property UniqueID() As String
        Get
            Return _UniqueID
        End Get
        Set(ByVal value As String)
            _UniqueID = value
        End Set
    End Property
End Class
' </Snippet80>