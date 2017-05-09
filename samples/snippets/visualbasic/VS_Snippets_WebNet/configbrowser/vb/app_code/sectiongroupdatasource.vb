' <Snippet30>
Imports Microsoft.VisualBasic
Imports System.Web.Configuration
Imports System.Configuration

''' <summary>
''' Retrieves a list of sections in a section group. 
''' </summary>
Public Class SectionGroupDataSource
    Public Sub New()
    End Sub

    Public Function GetSections(ByVal sectionGroupName As String,
                                ByVal virtualPath As String,
                                ByVal site As String,
                                ByVal locationSubPath As String,
                                ByVal server As String) _
                            As List(Of SectionInfo)

        Dim sectionList As New List(Of SectionInfo)()

        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server)

        Dim csg As ConfigurationSectionGroup =
            config.GetSectionGroup(sectionGroupName)

        For Each section As ConfigurationSection In csg.Sections
            Dim si As New SectionInfo()
            si.Name = section.SectionInformation.Name
            si.NameUrl = "Section.aspx?Section=" _
                & section.SectionInformation.SectionName

            Dim i As Integer =
                section.SectionInformation.Type.IndexOf(",")
            si.TypeName =
                section.SectionInformation.Type.Substring(0, i)
            sectionList.Add(si)
        Next

        For Each group As ConfigurationSectionGroup In csg.SectionGroups
            Dim si As New SectionInfo()
            si.Name = group.Name
            si.NameUrl = "SectionGroup.aspx?SectionGroup=" _
                & group.SectionGroupName
            si.TypeName =
                "System.Configuration.ConfigurationSectionGroup"
            sectionList.Add(si)
        Next
        Return sectionList
    End Function
End Class

Public Class SectionInfo
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
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
            Return "http://msdn.microsoft.com/en-us/library/" _
                & TypeName & ".aspx"
        End Get
    End Property
End Class
' </Snippet30>