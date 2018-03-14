
Imports System
Imports System.Configuration
Imports System.Web.Configuration




Class UsingSqlCacheDependencySection
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim webConfig As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      
      ' Get the section.
        Dim configPath As String = _
        "system.web/cache/sqlCacheDependency"
        Dim sqlDs _
        As System.Web.Configuration.SqlCacheDependencySection = _
        CType(webConfig.GetSection(configPath), _
        System.Web.Configuration.SqlCacheDependencySection)

      ' </Snippet1>

        ' <Snippet2>
      ' Get the current Databases collection.
        Dim databasesValue _
        As SqlCacheDependencyDatabaseCollection = _
        sqlDs.Databases
      
      ' </Snippet2>
      ' <Snippet3>
      ' Get the current PollTime property value.
      Dim pollTimeValue As Int32 = sqlDs.PollTime
      
      ' Set the PollTime property to 500 milliseconds.
      sqlDs.PollTime = 500
      
      ' </Snippet3>

        ' <Snippet4>
      ' Get the current Enabled property value.
      Dim enabledValue As [Boolean] = sqlDs.Enabled
      
      ' Set the Enabled property to false.
        sqlDs.Enabled = False
        ' </Snippet4>

   End Sub 'Main 
End Class 'UsingSqlCacheDependencySection 


