' <Snippet20>
Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.Caching
Imports System.Web.Hosting


Namespace Samples.AspNet.VB
  <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Medium), _
   AspNetHostingPermission(SecurityAction.InheritanceDemand, level:=AspNetHostingPermissionLevel.High)> _
  Public Class SamplePathProvider
    Inherits VirtualPathProvider

    Private dataFile As String

    ' <Snippet25>
    Public Sub New()
      MyBase.New()
    End Sub
    ' </Snippet25>

    ' <Snippet26>
    Protected Overrides Sub Initialize()
      ' <Snippet27>
      ' Set the datafile path relative to the application's path.
      dataFile = HostingEnvironment.ApplicationPhysicalPath & _
        "App_Data\XMLData.xml"
      ' </Snippet27>
    End Sub
    ' </Snippet26>

    ' <summary>
    '   Data set provider for the SampleVirtualFile and
    '   SampleVirtualDirectory classes. In a production application
    '   this method would be on a provider class that accesses
    '   the virtual resource data source.
    ' </summary>
    ' <returns>
    '   The System.Data.DataSet containing the virtual resources
    '   provided by the SamplePathProvider.
    ' </returns>
    Public Function GetVirtualData() As DataSet
      ' Get the data from the cache.
      Dim ds As DataSet
      ds = CType(HostingEnvironment.Cache.Get("VPPData"), DataSet)

      If ds Is Nothing Then
        ' Data set not in cache. Read XML file.
        ds = New DataSet
        ds.ReadXml(dataFile)

        ' Make DataSet dependent on XML file.
        Dim cd As CacheDependency
        cd = New CacheDependency(dataFile)

        ' Put DataSet into cache for maximum of 20 minutes.
        HostingEnvironment.Cache.Add("VPPData", ds, cd, _
         Cache.NoAbsoluteExpiration, _
         New TimeSpan(0, 20, 0), _
         CacheItemPriority.Default, Nothing)

        ' Set data timestamp.
        Dim dataTimeStamp As DateTime
        dataTimeStamp = DateTime.Now
        ' Cache it so we can get the timestamp in later calls.
        HostingEnvironment.Cache.Add("dataTimeStamp", dataTimeStamp, Nothing, _
          Cache.NoAbsoluteExpiration, _
          New TimeSpan(0, 20, 0), _
          CacheItemPriority.Default, Nothing)
      End If
      Return ds
    End Function

    Private Function IsPathVirtual(ByVal virtualPath As String) As Boolean
      Dim checkPath As String
      checkPath = VirtualPathUtility.ToAppRelative(virtualPath)
      Return checkPath.StartsWith("~/vrdir", StringComparison.InvariantCultureIgnoreCase)
    End Function

    ' <Snippet21>
    Public Overrides Function FileExists(ByVal virtualPath As String) As Boolean
      If (IsPathVirtual(virtualPath)) Then
        Dim file As SampleVirtualFile
        file = CType(GetFile(virtualPath), SampleVirtualFile)
        Return file.Exists
      Else
        Return Previous.FileExists(virtualPath)
      End If
    End Function
    ' </Snippet21>

    ' <Snippet22>
    Public Overrides Function DirectoryExists(ByVal virtualDir As String) As Boolean
      If (IsPathVirtual(virtualDir)) Then
        Dim dir As SampleVirtualDirectory
        dir = CType(GetDirectory(virtualDir), SampleVirtualDirectory)
        Return dir.exists
      Else
        Return Previous.DirectoryExists(virtualDir)
      End If
    End Function
    ' </Snippet22>

    ' <Snippet23>
    Public Overrides Function GetFile(ByVal virtualPath As String) As VirtualFile
      If (IsPathVirtual(virtualPath)) Then
        Return New SampleVirtualFile(virtualPath, Me)
      Else
        Return Previous.GetFile(virtualPath)
      End If
    End Function
    ' </Snippet23>

    ' <Snippet24>
    Public Overrides Function GetDirectory(ByVal virtualDir As String) As VirtualDirectory
      If (IsPathVirtual(virtualDir)) Then
        Return New SampleVirtualDirectory(virtualDir, Me)
      Else
        Return Previous.GetDirectory(virtualDir)
      End If
    End Function
    ' </Snippet24>

    ' <Snippet28>
    Public Overrides Function GetCacheDependency(ByVal virtualPath As String, ByVal virtualPathDependencies As IEnumerable, ByVal utcStart As Date) As CacheDependency
      If (IsPathVirtual(virtualPath)) Then

        Dim fullPathDependencies As System.Collections.Specialized.StringCollection
        fullPathDependencies = Nothing

        ' Get the full path to all dependencies.
        For Each virtualDependency As String In virtualPathDependencies
          If fullPathDependencies Is Nothing Then
            fullPathDependencies = New System.Collections.Specialized.StringCollection
          End If

          fullPathDependencies.Add(virtualDependency)
        Next

        If fullPathDependencies Is Nothing Then
          Return Nothing
        End If

        Dim fullPathDependenciesArray As String()
        fullPathDependencies.CopyTo(fullPathDependenciesArray, 0)

        Return New CacheDependency(fullPathDependenciesArray, utcStart)
      Else
        Return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart)
      End If
    End Function
    ' </Snippet28>
  End Class
End Namespace
' </Snippet20>