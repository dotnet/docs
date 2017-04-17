
Imports System
Imports System.Configuration
Imports System.Web.Configuration




Class UsingOutputCacheSection
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim webConfig _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim configPath As String = _
        "system.web/caching/outputCache"
        Dim outputCacheSection _
        As System.Web.Configuration.OutputCacheSection = _
        CType(webConfig.GetSection(configPath), _
        System.Web.Configuration.OutputCacheSection)
      
      ' </Snippet1>
      
    
      
      ' <Snippet3>
      ' Get the current EnabledOutputCache.
        Dim enabledOutputCache As [Boolean] = _
        outputCacheSection.EnableOutputCache
      
      ' Set the EnabledOutputCache.
      outputCacheSection.EnableOutputCache = False
      
      ' </Snippet3>
      ' <Snippet4>
      ' Get the current EnabledFragmentCache.
        Dim enabledFragmentCache As [Boolean] = _
        outputCacheSection.EnableFragmentCache
      
      ' Set the EnabledFragmentCache.
      outputCacheSection.EnableFragmentCache = False
      
      ' </Snippet4>
      ' <Snippet5>
      ' Get the current OmitVaryStar.
        Dim omitVaryStar As [Boolean] = _
        outputCacheSection.OmitVaryStar
      
      ' Set the OmitVaryStar.
      outputCacheSection.OmitVaryStar = False
      
      ' </Snippet5>
      
      ' <Snippet6>
      ' Get the current SendCacheControlHeader.
        Dim sendCacheControlHeaderValue As [Boolean] = _
        outputCacheSection.SendCacheControlHeader
      
      ' Set the SendCacheControlHeader.
      outputCacheSection.SendCacheControlHeader = False
      
      ' </Snippet6>
      ' <Snippet7>
      ' Create a .OutputCacheSection object.
        Dim outputCache _
        As New System.Web.Configuration.OutputCacheSection()
        ' </Snippet7>

    End Sub 'Main

End Class 'UsingOutputCacheSection 
' UsingOutputCacheSection class end.
' Samples.Aspnet.SystemWebConfiguration namespace end.