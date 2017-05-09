' <Snippet1> 
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class ReadWriteCache
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Label1.Text = "Application Cache goes here."
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")


        ' <Snippet2>
        Dim cacheSection As System.Web.Configuration.CacheSection =
            CType(config.GetSection("system.web/caching/cache"), System.Web.Configuration.CacheSection)
        ' </Snippet2>

        ' <Snippet6>
        ' Increase the PrivateBytesLimit property to 0.
        cacheSection.PrivateBytesLimit = cacheSection.PrivateBytesLimit + 10
        ' </Snippet6>


        ' <Snippet7>
        ' Increase memory limit.
        cacheSection.PercentagePhysicalMemoryUsedLimit =
            cacheSection.PercentagePhysicalMemoryUsedLimit + 1
        ' </Snippet7>

        ' <Snippet8>
        ' Increase poll time.
        cacheSection.PrivateBytesPollTime =
            cacheSection.PrivateBytesPollTime + TimeSpan.FromMinutes(1)
        ' </Snippet8>


        ' <Snippet3>
        ' Enable or disable memory collection.
        cacheSection.DisableMemoryCollection =
            Not cacheSection.DisableMemoryCollection
        ' </Snippet3>

        ' <Snippet4>
        ' Enable or disable cache expiration.
        cacheSection.DisableExpiration =
            Not cacheSection.DisableExpiration
        ' </Snippet4>

        ' Save the configuration file.
        config.Save(System.Configuration.ConfigurationSaveMode.Modified)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/")


        Dim cacheSection As System.Web.Configuration.CacheSection =
            CType(config.GetSection("system.web/caching/cache"), System.Web.Configuration.CacheSection)

        ' Read the cache section.
        Dim buffer As New System.Text.StringBuilder()

        Dim currentFile As String = cacheSection.CurrentConfiguration.FilePath
        Dim dExpiration As Boolean = cacheSection.DisableExpiration
        Dim dMemCollection As Boolean = cacheSection.DisableMemoryCollection
        Dim pollTime As TimeSpan = cacheSection.PrivateBytesPollTime
        Dim phMemUse As Integer = cacheSection.PercentagePhysicalMemoryUsedLimit
        Dim pvBytesLimit As Long = cacheSection.PrivateBytesLimit

        Dim cacheEntry As String = String.Format("File: {0} <br/>", currentFile)
        buffer.Append(cacheEntry)
        cacheEntry = String.Format("Expiration Disabled: {0} <br/>", dExpiration)
        buffer.Append(cacheEntry)
        cacheEntry = String.Format("Memory Collection Disabled: {0} <br/>", dMemCollection)
        buffer.Append(cacheEntry)
        cacheEntry = String.Format("Poll Time: {0} <br/>", pollTime.ToString())
        buffer.Append(cacheEntry)
        cacheEntry = String.Format("Memory Limit: {0} <br/>", phMemUse.ToString())
        buffer.Append(cacheEntry)
        cacheEntry = String.Format("Bytes Limit: {0} <br/>", pvBytesLimit.ToString())
        buffer.Append(cacheEntry)

        Label1.Text = buffer.ToString()
    End Sub
End Class
' </Snippet1>