Imports System
Imports System.Configuration
Imports System.Web.Configuration



Class UsingOutputCacheSettingsSection
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim webConfig _
          As System.Configuration.Configuration = _
          WebConfigurationManager.OpenWebConfiguration( _
          "/aspnetTest")

        ' Get the section.
        Dim configPath As String = _
       "system.web/caching/outputCacheSettings"
        Dim outputCacheSettings _
        As System.Web.Configuration.OutputCacheSettingsSection = _
        CType(webConfig.GetSection(configPath), _
        System.Web.Configuration.OutputCacheSettingsSection)
      
      ' </Snippet1>

    ' <Snippet2>
      ' Create a OutputCacheSettingsSection object.
        Dim outCacheSettings _
        As New System.Web.Configuration.OutputCacheSettingsSection()
      ' </Snippet2>

    ' <Snippet3>
      ' Get the current OutputCacheProfiles property value.
        Dim outputCacheProfilesValue _
        As OutputCacheProfileCollection = _
        outputCacheSettings.OutputCacheProfiles

    ' </Snippet3>

   End Sub 'Main
End Class 'UsingOutputCacheSettingsSection 

' UsingOutputCacheSettingsSection class end.
' Samples.Aspnet.SystemWebConfiguration namespace end.