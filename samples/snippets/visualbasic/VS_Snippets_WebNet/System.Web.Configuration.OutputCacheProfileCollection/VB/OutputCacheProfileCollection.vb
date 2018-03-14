Imports System
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the
' System.Web.Configuration.OutputCacheSettingsSection members
' selected by the user.

Class UsingOutputCacheSettingsSection
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   
   Overloads Public Shared Sub Main(args() As String)
      
      ' <Snippet1>
        '  ' Get the Web application configuration.
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
      
      ' Get the profile collection.
        Dim outputCacheProfiles _
        As System.Web.Configuration.OutputCacheProfileCollection = _
        outputCacheSettings.OutputCacheProfiles
      
      ' </Snippet1>
      
      ' <Snippet2>
      ' Execute the Add method.
        Dim outputCacheProfile0 _
        As New System.Web.Configuration.OutputCacheProfile( _
        "MyCacheProfile")
        outputCacheProfile0.Location = _
        System.Web.UI.OutputCacheLocation.Any
        outputCacheProfile0.NoStore = _
        False
      
        outputCacheProfiles.Add(outputCacheProfile0)
      
      ' Update if not locked.
        If Not outputCacheSettings.IsReadOnly() Then
            webConfig.Save()
        End If
      ' </Snippet2>
      
      ' <Snippet3>
      ' Execute the Clear method.
        outputCacheProfiles.Clear()
      ' </Snippet3>
        '
        '<Snippet4>
      ' Get the profile with the specified index.
        Dim outputCacheProfile2 _
        As System.Web.Configuration.OutputCacheProfile = _
        outputCacheProfiles(0)
      
      ' </Snippet4>

        ' <Snippet5>
      ' Get the profile with the specified name.
        Dim outputCacheProfile3 _
        As System.Web.Configuration.OutputCacheProfile = _
        outputCacheProfiles("MyCacheProfile")
      
      ' </Snippet5>
      
      ' <Snippet6>
      ' Get the key with the specified index.
        Dim theKey As String = _
        outputCacheProfiles.GetKey(0)
      
      ' </Snippet6>

        ' <Snippet7>
      ' Remove the output profile with the specified index.
        outputCacheProfiles.RemoveAt(0)
      ' </Snippet7>
      
      ' <Snippet8>
      ' Remove the output profile with the specified name.
        outputCacheProfiles.Remove("MyCacheProfile")
        ' </Snippet8>

      ' <Snippet9>
      ' Get the keys.
        Dim keys As String() = _
        outputCacheProfiles.AllKeys
      
      ' </Snippet9>

        ' <Snippet10>
      ' Execute the Set method.
        Dim outputCacheProfile _
        As New System.Web.Configuration.OutputCacheProfile( _
        "MyCacheProfile")
        outputCacheProfile.Location = _
        System.Web.UI.OutputCacheLocation.Any
        outputCacheProfile.NoStore = _
        False
      
        outputCacheProfiles.Set(outputCacheProfile)
      
      ' Update if not locked.
        If Not outputCacheSettings.IsReadOnly() Then
            webConfig.Save()
        End If
    ' </Snippet10>

        '<Snippet11>
        'Get the profile with the specified name.
        Dim outputCacheProfile4 _
        As System.Web.Configuration.OutputCacheProfile = _
        outputCacheProfiles.Get("MyCacheProfile")

        '</Snippet11>

        '<Snippet12>
        'Get the profile with the specified index.
        Dim outputCacheProfile5 _
        As System.Web.Configuration.OutputCacheProfile = _
        outputCacheProfiles.Get("MyCacheProfile")

        '</Snippet12>

  End Sub 'Main 
End Class 'UsingOutputCacheSettingsSection


' UsingOutputCacheSettingsSection class end.
' Samples.Aspnet.SystemWebConfiguration namespace end.