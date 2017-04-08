
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the
' System.Web.Configuration.SqlCacheDependencyDatabaseCollection members
' selected by the user.

Class UsingSqlCacheDependencyDatabaseCollection


    Public Overloads Shared Sub Main(ByVal args() As String)

        ' <Snippet1>
        ' Get the Web application configuration.
        Dim webConfig As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the section.
        Dim configPath As String = "system.web/sqlCacheDependency"
        Dim sqlCacheDependencySection As SqlCacheDependencySection = _
        CType(webConfig.GetSection(configPath), SqlCacheDependencySection)

        ' Get the database element at the specified index.
        Dim sqlCdds _
        As SqlCacheDependencyDatabaseCollection = _
            sqlCacheDependencySection.Databases

        ' </Snippet1>

        ' <Snippet2>
        Dim collectionKeys As String() = sqlCdds.AllKeys

        ' </Snippet2>

        ' <Snippet3>
        Dim dbElement As SqlCacheDependencyDatabase = _
        New SqlCacheDependencyDatabase( _
        "dataBase", "dataBaseElement", 500)
        sqlCdds.Add(dbElement)
        ' </Snippet3>

        ' <Snippet4>
        sqlCdds.Clear()

        ' </Snippet4>

        ' <Snippet5>
        Dim dbElement1 _
        As SqlCacheDependencyDatabase = _
            sqlCdds.Get(0)

        ' </Snippet5>
        ' <Snippet6>
        Dim dbElement3 _
        As SqlCacheDependencyDatabase = _
          sqlCdds.Get("dataBaseElement")

        ' </Snippet6>

        ' <Snippet7>
        Dim thisKey As String = sqlCdds.GetKey(0)

        ' </Snippet7>

        ' <Snippet8>
        sqlCdds.Remove("dataBaseElement")

        ' </Snippet8>

        ' <Snippet9>
        sqlCdds.RemoveAt(0)

        ' </Snippet9>

        ' <Snippet10>
        Dim dbElement2 As SqlCacheDependencyDatabase = _
        New SqlCacheDependencyDatabase( _
        "dataBase2", "dataBaseElement2", 500)
        sqlCdds.Set(dbElement2)

        ' </Snippet10>

    End Sub 'Main 
End Class 'UsingSqlCacheDependencySection 

