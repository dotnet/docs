
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text.RegularExpressions



Class UsingUrlMapping
   
   Private Shared shownUrl, mappedUrl, msg As String
   Private Shared urlMapping As UrlMapping

   
    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim inputStr As String = String.Empty
        Dim optionStr As String = String.Empty
        Dim parm1 As String = String.Empty
        Dim parm2 As String = String.Empty

        ' Define a regular expression to allow only 
        ' alphanumeric inputs that are at most 20 character 
        ' long. For instance "/iii:".
        Dim rex As New Regex("[^\/w]{1,20}")
        parm1 = "none"
        parm2 = "false"

        ' Parse the user's input.      
        If args.Length < 1 Then
            ' No option entered.
            Console.Write("Input parameters missing.")
            Return
        Else
            ' Get the user's options.
            inputStr = args(0).ToLower()


            If args.Length = 3 Then
                ' These to be used when serializing 
                ' (writing) to the configuration file.
                parm1 = args(1).ToLower()
                parm2 = args(2).ToLower()

                If Not rex.Match(parm1).Success _
                AndAlso Not rex.Match(parm2).Success Then
                    ' Wrong option format used.
                    Console.Write("Input format not allowed.")
                    Return
                End If
            End If

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

        ' Get the <urlMapping> section.
        Dim urlMappingSection _
        As UrlMappingsSection = _
        CType(configuration.GetSection( _
        "system.web/urlMappings"), UrlMappingsSection)

        ' <Snippet2>
        ' Get the url mapping collection.
        Dim urlMappings _
        As UrlMappingCollection = _
        urlMappingSection.UrlMappings

        ' </Snippet2>
        ' </Snippet1>
        Try

            Select Case inputStr

                Case "/add"

                    ' <Snippet3>
                    ' Create a new UrlMapping object.
                    urlMapping = New UrlMapping( _
                    "~/home.aspx", "~/default.aspx?parm1=1")

                    ' Add the urlMapping to 
                    ' the collection.
                    urlMappings.Add(urlMapping)

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet3>
                    shownUrl = urlMapping.Url
                    mappedUrl = urlMapping.MappedUrl

                    msg = String.Format( _
                    "Shown URL: {0}" + ControlChars.Lf _
                    + "Mapped URL:  {1}" + ControlChars.Lf, _
                    shownUrl, mappedUrl)


                    Console.Write(msg)


                Case "/clear"

                    ' <Snippet4>
                    ' Clear the url mapping collection.
                    urlMappings.Clear()

                    ' Update the configuration file.
                    ' Define the save modality.
                    Dim saveMode _
                    As ConfigurationSaveMode = _
                    ConfigurationSaveMode.Minimal

                    urlMappings.EmitClear = _
                    Convert.ToBoolean(parm2)

                    If parm1 = "none" Then
                        If Not urlMappingSection.IsReadOnly() Then
                            configuration.Save()
                        End If
                        msg = String.Format( _
                        "Default modality, EmitClear:      {0}", _
                        urlMappings.EmitClear.ToString())
                    Else
                        If parm1 = "full" Then
                            saveMode = ConfigurationSaveMode.Full
                        ElseIf parm1 = "modified" Then
                            saveMode = ConfigurationSaveMode.Modified
                        End If
                        If Not urlMappingSection.IsReadOnly() Then
                            configuration.Save(saveMode)
                        End If
                        msg = String.Format( _
                        "Save modality:      {0}", _
                        saveMode.ToString())
                    End If

                    ' </Snippet4>
                    Console.Write(msg)


                Case "/removeobject"

                    ' <Snippet5>
                    ' Create a UrlMapping object.
                    urlMapping = New UrlMapping( _
                    "~/home.aspx", "~/default.aspx?parm1=1")

                    ' Remove it from the collection
                    ' (if exists).
                    urlMappings.Remove(urlMapping)

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet5>
                    shownUrl = urlMapping.Url
                    mappedUrl = urlMapping.MappedUrl

                    msg = String.Format( _
                    "Shown URL:      {0}" + ControlChars.Lf _
                    + "Mapped URL: {1}" + ControlChars.Lf, _
                    shownUrl, mappedUrl)

                    Console.Write(msg)


                Case "/removeurl"

                    ' <Snippet6>
                    ' Remove the URL with the
                    ' specified name from the collection
                    ' (if exists).
                    urlMappings.Remove("~/home.aspx")

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet6>

                Case "/removeindex"

                    ' <Snippet7>
                    ' Remove the URL at the 
                    ' specified index from the collection.
                    urlMappings.RemoveAt(0)

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet7>

                Case "/all"

                    ' <Snippet8>
                    Dim allUrlMappings As New StringBuilder()

                    Dim url_Mapping As UrlMapping
                    For Each url_Mapping In urlMappings

                        ' <Snippet9>
                        shownUrl = url_Mapping.Url
                        ' </Snippet9>

                        ' <Snippet10>
                        mappedUrl = url_Mapping.MappedUrl
                        ' </Snippet10>

                        msg = String.Format( _
                        "Shown URL:  {0}" + ControlChars.Lf + _
                        "Mapped URL: {1}" + ControlChars.Lf, _
                        shownUrl, mappedUrl)

                        allUrlMappings.AppendLine(msg)
                    Next url_Mapping

                    ' </Snippet8>
                    Console.Write(allUrlMappings.ToString())


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
End Class 'UsingUrlMapping