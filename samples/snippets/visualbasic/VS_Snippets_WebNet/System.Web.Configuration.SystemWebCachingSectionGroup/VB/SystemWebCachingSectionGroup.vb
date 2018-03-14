
Imports System
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text.RegularExpressions



Class UsingSystemWebCachingSectionGroup
   Private Shared msg As String
   

    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim inputStr As String = String.Empty

        ' Define a regular expression to allow only 
        ' alphanumeric inputs that are at most 20 character 
        ' long. For instance "/iii:".
        Dim rex As New Regex("[^\/w]{1,20}")

        ' Parse the user's input.      
        If args.Length < 1 Then
            ' No option entered.
            Console.Write("Input parameters missing.")
            Return
        Else
            ' Get the user's options.
            inputStr = args(0).ToLower()

            If Not rex.Match(inputStr).Success Then
                ' Wrong option format used.
                Console.Write("Input format not allowed.")
                Return
            End If
        End If

        ' <Snippet1>
        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <caching> section group.
        Dim cachingSectionGroup _
        As SystemWebCachingSectionGroup = _
        CType(configuration.GetSectionGroup( _
        "system.web/caching"), SystemWebCachingSectionGroup)
        ' </Snippet1>

        Try

            Select Case inputStr

                Case "/cache"

                    ' <Snippet2>
                    ' Get the <cache> section.
                    Dim cache As CacheSection = _
                    cachingSectionGroup.Cache

                    ' Display one of its properties.
                    msg = String.Format( _
                    "Cache disable expiration: {0}" + _
                    ControlChars.Lf, cache.DisableExpiration)

                    Console.Write(msg)

                    ' </Snippet2>

                Case "/outcache"

                    ' <Snippet3>
                    ' Get the .<outputCache> section
                    Dim outputCache _
                    As OutputCacheSection = _
                    cachingSectionGroup.OutputCache

                    ' Display one of its properties.
                    msg = String.Format( _
                    "Enable output cache: {0}" + _
                    ControlChars.Lf, _
                    outputCache.EnableOutputCache.ToString())

                    Console.Write(msg)

                    ' </Snippet3>

                Case "/outcacheset"

                    ' <Snippet4>
                    ' Get the .<outputCacheSettings> section
                    Dim outputCacheSettings _
                    As OutputCacheSettingsSection = _
                    cachingSectionGroup.OutputCacheSettings

                    ' Display the number of existing 
                    ' profiles.
                    Dim profilesCount As Integer = _
                    outputCacheSettings.OutputCacheProfiles.Count
                    msg = String.Format( _
                    "Number of profiles: {0}" + _
                    ControlChars.Lf, profilesCount.ToString())

                    Console.Write(msg)

                    ' </Snippet4>

                Case "/sql"

                    ' <Snippet5>
                    ' Get the .<sqlCacheDependency> section
                    Dim sqlCacheDependency _
                    As SqlCacheDependencySection = _
                    cachingSectionGroup.SqlCacheDependency

                    ' Display one of its attributes.
                    msg = String.Format( _
                    "Sql cache dependency enabled: {0}" + _
                    ControlChars.Lf, _
                    sqlCacheDependency.Enabled.ToString())

                    Console.Write(msg)

                    ' </Snippet5>

                ' Case "/all"

                    ' <Snippet6>
		      'Not in use anymore.
                    'Dim allSections As New StringBuilder()

                    ' Get the section collection.
                    'Dim sections _
                    'As ConfigurationSectionCollection = _
                    'cachingSectionGroup.Sections

                    ' Get the number of sections.
                    'Dim sectionsNumber As Integer = _
                    'sections.Count

                    'Dim ienum _
                    'As System.Collections.IEnumerator = _
                    'sections.AllKeys.GetEnumerator()

                    'Dim i As Integer = 0
                    'allSections.AppendLine()
                    'Dim section As [Object]
                    'For Each section In sections
                     '   msg = String.Format( _
                      '  "Section{0}:  {1}" + _
                     '   ControlChars.Lf, i, section.ToString())
                      '  allSections.AppendLine(msg)
                     '   i += 1
                    ' Next section

                    ' Console.Write(allSections.ToString())

                    ' </Snippet6>

                Case Else
                    ' Option is not allowed..
                    Console.Write("Input not allowed.")
            End Select
        Catch e As ArgumentException
            ' Never display this. Use it for 
            ' debugging purposes.
            msg = e.ToString()
        End Try
    End Sub 'Main
End Class 'UsingSystemWebCachingSectionGroup