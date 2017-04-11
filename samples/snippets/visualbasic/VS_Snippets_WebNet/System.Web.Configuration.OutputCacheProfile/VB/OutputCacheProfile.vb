
Imports System
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.OutputCacheProfile
' members selected by the user.

Class UsingOutputCacheProfile
   
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
      
      ' Get the profile at zero index.
        Dim outputCacheProfile _
        As System.Web.Configuration.OutputCacheProfile = _
        outputCacheSettings.OutputCacheProfiles(0)
      
      ' </Snippet1>

        ' <Snippet2>
        ' Get the current VaryByHeader.
        Dim varyByHeaderValue As String = _
        outputCacheProfile.VaryByHeader
      
        ' Set the VaryByHeader.
        outputCacheProfile.VaryByHeader = _
        String.Empty
      
      ' </Snippet2>
      ' <Snippet3>
        ' Get the current VaryByControl.
        Dim varyByControlValue As String = _
        outputCacheProfile.VaryByControl
      
        ' Set the VaryByControl.
        outputCacheProfile.VaryByControl = _
        String.Empty
      
      ' </Snippet3>
      ' <Snippet4>
        ' Get the current NoStore.
        Dim noStoreValue As [Boolean] = _
        outputCacheProfile.NoStore
      
        ' Set the NoStore property.
      outputCacheProfile.NoStore = False
      
      ' </Snippet4>
      ' <Snippet5>
        ' Get the current Location.
        Dim locationValue _
        As System.Web.UI.OutputCacheLocation = _
        outputCacheProfile.Location
      
      ' Set the Location property to null.
        outputCacheProfile.Location = _
        System.Web.UI.OutputCacheLocation.Server
      
      ' </Snippet5>

     
      
      ' <Snippet7>
        ' Get the current SqlDependency.
        Dim sqlDependencyValue As String = _
        outputCacheProfile.SqlDependency
      
        ' Set the SqlDependency.
        outputCacheProfile.SqlDependency = _
        String.Empty
      
      ' </Snippet7>
      ' <Snippet8>
        ' Get the current VaryByParam property.
        Dim varyByParamValue As String = _
        outputCacheProfile.VaryByParam
      
        ' Set the VaryByParam property.
        outputCacheProfile.VaryByParam = _
        String.Empty
      
      ' </Snippet8>
      ' <Snippet9>
        ' Get the current VaryByCustom.
        Dim varyByCustomValue As String = _
        outputCacheProfile.VaryByCustom
      
        ' Set the VaryByCustom property.
        outputCacheProfile.VaryByCustom = _
        String.Empty
      
      ' </Snippet9>
      ' <Snippet10>
        ' Get the current Duration.
        Dim durationValue As Int32 = _
        outputCacheProfile.Duration
      
        ' Set the Duration.
      outputCacheProfile.Duration = 0
      
      ' </Snippet10>
      ' <Snippet11>
        ' Get the current Name.
        Dim nameValue As String = _
        outputCacheProfile.Name
      
        ' Set the Name property.
        outputCacheProfile.Name = _
        String.Empty
      
      ' </Snippet11>
      ' <Snippet12>
        ' Get the current Enabled property.
        Dim enabledValue As [Boolean] = _
        outputCacheProfile.Enabled
      
        ' Set the Enabled property.
    outputCacheProfile.Enabled = False
    ' </Snippet12>

   End Sub 'Main 
End Class 'UsingOutputCacheProfile 

' UsingOutputCacheProfile class end.
' Samples.Aspnet.SystemWebConfiguration namespace end.