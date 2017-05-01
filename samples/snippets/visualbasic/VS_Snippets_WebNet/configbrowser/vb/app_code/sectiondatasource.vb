' <Snippet50>
Imports Microsoft.VisualBasic
Imports System.Web.Configuration
Imports System.Configuration
Imports System.Reflection

''' <summary>
''' Retrieves a list of elements in a section. 
''' </summary>
Public Class SectionDataSource
    Public Sub New()
    End Sub
    Public Function GetProperties(ByVal sectionName As String,
                                  ByVal virtualPath As String,
                                  ByVal site As String,
                                  ByVal locationSubPath As String,
                                  ByVal server As String) _
                              As List(Of ElementInfo)

        Dim sectionList As New List(Of ElementInfo)()

        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server)

        Dim cs As ConfigurationSection = config.GetSection(sectionName)
        Dim sectionType As Type = cs.[GetType]()
        Dim sectionProperties As PropertyInfo() =
            sectionType.GetProperties()

        For Each rpi As PropertyInfo In sectionProperties
            If rpi.Name <> "SectionInformation" _
                AndAlso rpi.Name <> "LockAttributes" _
                AndAlso rpi.Name <> "LockAllAttributesExcept" _
                AndAlso rpi.Name <> "LockElements" _
                AndAlso rpi.Name <> "LockAllElementsExcept" _
                AndAlso rpi.Name <> "LockItem" _
                AndAlso rpi.Name <> "ElementInformation" _
                AndAlso rpi.Name <> "CurrentConfiguration" Then

                Dim ei As New ElementInfo()
                ei.Name = rpi.Name
                ei.TypeName = rpi.PropertyType.ToString()

                If rpi.PropertyType.BaseType _
                    Is GetType(ConfigurationElement) Then

                    ei.NameUrl = ("Element.aspx?Section=" _
                                  & sectionName & "&Element=") + rpi.Name
                    ei.Value = "Element"
                ElseIf rpi.PropertyType.BaseType _
                    Is GetType(ConfigurationElementCollection) Then

                    ei.NameUrl = ("Element.aspx?Section=" _
                                  & sectionName & "&Element=") + rpi.Name
                    ei.Value = "Element Collection"
                Else
                    Dim indexParms As ParameterInfo() =
                        rpi.GetIndexParameters()
                    If rpi.PropertyType Is GetType(IList) _
                        OrElse rpi.PropertyType Is GetType(ICollection) _
                        OrElse indexParms.Length > 0 Then

                        ei.Value = "Collection"
                    Else
                        Dim propertyValue As Object =
                            rpi.GetValue(cs, Nothing)
                        ei.Value = IIf(propertyValue Is Nothing,
                                       "", propertyValue.ToString())
                    End If
                End If
                sectionList.Add(ei)
            End If
        Next
        Return sectionList
    End Function
End Class

Public Class ElementInfo
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
    Private _NameUrl As String
    Public Property NameUrl() As String
        Get
            Return _NameUrl
        End Get
        Set(ByVal value As String)
            _NameUrl = value
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
            Return "http://msdn.microsoft.com/en-us/library/" & TypeName & ".aspx"
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
' </Snippet50>