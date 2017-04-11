
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the
' System.Web.Configuration.SqlCacheDependencyDatabase members
' selected by the user.

Class UsingSqlCacheDependencyDatabase
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim webConfig _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
      
      ' Get the section.
        Dim configPath As String = _
        "system.web/cache/sqlCacheDependency"
        Dim sqlDs _
        As System.Web.Configuration.SqlCacheDependencySection = _
        CType(webConfig.GetSection(configPath), System.Web.Configuration.SqlCacheDependencySection)
      
      ' Get the databases element at 0 index.
        Dim sqlCdd _
        As System.Web.Configuration.SqlCacheDependencyDatabase = _
        sqlDs.Databases(0)
      
      ' </Snippet1>
      
      ' <Snippet2>
      ' Get the current PollTime property value.
      Dim pollTimeValue As Int32 = sqlCdd.PollTime
      
      ' Set the PollTime property to 1000 milliseconds.
      sqlCdd.PollTime = 1000
      
      ' </Snippet2>
      
      ' <Snippet3>
      ' Get the current Name property value.
      Dim nameValue As String = sqlCdd.Name
      
      ' Set the Name for this configuration element.
      sqlCdd.Name = "ConfigElementName"
      
      ' </Snippet3>
      
      ' <Snippet4>
      ' Get the current ConnectionStringName property value.
      Dim connectionNameValue As String = sqlCdd.ConnectionStringName
      
      ' Set the ConnectionName property. This is the database name.
        sqlCdd.ConnectionStringName = "DataBaseName"
        ' </Snippet4>


        '<Snippet5>
        Dim dbElement0 As SqlCacheDependencyDatabase = _
        New SqlCacheDependencyDatabase( _
            "dataBase", "dataBaseElement", 500)

        '</Snippet5>

        '<Snippet6>
        Dim dbElement1 As SqlCacheDependencyDatabase = _
        New SqlCacheDependencyDatabase( _
            "dataBase1", "dataBaseElement1")

        '</Snippet6>


   End Sub 'Main 
End Class 'UsingSqlCacheDependencyDatabase 


