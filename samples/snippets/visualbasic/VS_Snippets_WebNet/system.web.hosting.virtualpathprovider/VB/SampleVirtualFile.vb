' <Snippet40>
Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.IO
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.Caching
Imports System.Web.Hosting

Namespace Samples.AspNet.VB
  <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal), _
   AspNetHostingPermission(SecurityAction.InheritanceDemand, level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class SampleVirtualFile
    Inherits VirtualFile

    Private content As String
    Private spp As SamplePathProvider

    Public ReadOnly Property Exists() As Boolean
      Get
        Return (content <> String.Empty)
      End Get
    End Property

    ' <Snippet41>
    Public Sub New(ByVal virtualPath As String, ByVal provider As SamplePathProvider)
      MyBase.New(virtualPath)
      spp = provider
      GetData()
    End Sub

    Protected Sub GetData()
      ' Get the data from the SamplePathProvider.
      Dim spp As SamplePathProvider
      spp = CType(HostingEnvironment.VirtualPathProvider, SamplePathProvider)

      Dim ds As DataSet
      ds = spp.GetVirtualData

      ' Get the virtual file data from the resource table.
      Dim files As DataTable
      files = ds.Tables("resource")

      Dim rows As DataRow()
      rows = files.Select( _
        String.Format("(name='{0}') AND (type='file')", Me.Name))

      ' If the select returned a row, store the file contents.
      If (rows.Length > 0) Then
        Dim row As DataRow
        row = rows(0)

        content = row("content").ToString()
      End If
    End Sub
    ' </Snippet41>

    ' <Snippet42>

    Private Function FormatTimeStamp(ByVal time As DateTime) As String
      Return String.Format("{0} at {1}", _
        time.ToLongDateString(), time.ToLongTimeString)
    End Function

    Public Overrides Function Open() As System.IO.Stream
      Dim templateFile As String
      templateFile = HostingEnvironment.ApplicationPhysicalPath & "App_Data\template.txt"

      Dim pageTemplate As String
      Dim now As DateTime
      now = DateTime.Now

      ' Try to get the page template out of the cache.
      pageTemplate = CType(HostingEnvironment.Cache.Get("pageTemplate"), String)

      If pageTemplate Is Nothing Then
        ' Get the page template.
        Try
          pageTemplate = My.Computer.FileSystem.ReadAllText(templateFile)
        Catch fileException As Exception
          Throw fileException
        End Try

        ' Set template timestamp.
        pageTemplate = pageTemplate.Replace("%templateTimestamp%", _
          FormatTimeStamp(Now))

        ' Make pageTemplate dependent on the template file.
        Dim cd As CacheDependency
        cd = New CacheDependency(templateFile)

        ' Put pageTemplate into cache for maximum of 20 minutes.
        HostingEnvironment.Cache.Add("pageTemplate", pageTemplate, cd, _
          Cache.NoAbsoluteExpiration, _
          New TimeSpan(0, 20, 0), _
          CacheItemPriority.Default, Nothing)
      End If

      ' Put the page data into the template.
      pageTemplate = pageTemplate.Replace("%file%", Me.Name)
      pageTemplate = pageTemplate.Replace("%content%", content)

      ' Get the data timestamp from the cache.
      Dim dataTimeStamp As DateTime
      dataTimeStamp = CType(HostingEnvironment.Cache.Get("dataTimeStamp"), DateTime)
      pageTemplate = pageTemplate.Replace("%dataTimestamp%", _
        FormatTimeStamp(dataTimeStamp))

      ' Set a timestamp for the page.
      Dim pageTimeStamp As String
      pageTimeStamp = FormatTimeStamp(now)
      pageTemplate = pageTemplate.Replace("%pageTimestamp%", pageTimeStamp)

      ' Put the page content on the stream.
      Dim stream As MemoryStream
      stream = New MemoryStream()

      Dim writer As StreamWriter
      writer = New StreamWriter(stream)

      writer.Write(pageTemplate)
      writer.Flush()
      stream.Seek(0, SeekOrigin.Begin)

      Return stream
    End Function
    ' </Snippet42>
  End Class
End Namespace
' </Snippet40>
