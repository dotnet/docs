
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text.RegularExpressions



Class UsingClientTarget
   
    Private Shared aliasStr, userAgent, msg As String
   Private Shared clientTarget As ClientTarget
   
   
    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim inputStr As String = String.Empty
        Dim [option] As String = String.Empty

        ' Define a regular expression to allow only 
        ' alphanumeric inputs that are at most 20 characters 
        ' long. For instance "/iii:".
        Dim rex As New Regex("[^\/w]{1,20}")

        ' Parse the user's input.      
        If args.Length < 1 Then
            ' No option entered.
            Console.Write("Input parameter missing.")
            Return
        Else
            ' Get the user's option.
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

        ' Get the <clientTarget> section.
        Dim clientTargetSection _
        As ClientTargetSection = _
        CType(configuration.GetSection( _
        "system.web/clientTarget"), _
        ClientTargetSection)

        ' <Snippet2>
        ' Get the client target collection.
        Dim clientTargets _
        As ClientTargetCollection = _
        clientTargetSection.ClientTargets

        ' </Snippet2>

        ' </Snippet1>

        Try

            Select Case inputStr

                Case "/alias"

                    ' <Snippet3>
                    ' Get the first client target 
                    ' in the collection.
                    clientTarget = clientTargets(0)

                    ' Get the alias.
                    aliasStr = clientTarget.Alias

                    msg = String.Format( _
                    "Alias:      {0}" + ControlChars.Lf, aliasStr)

                    ' </Snippet3>
                    Console.Write(msg)


                Case "/useragent"

                    ' <Snippet4>
                    ' Get the first client target 
                    ' in the collection.
                    clientTarget = clientTargets(0)

                    ' Get he user agent.
                    userAgent = clientTarget.UserAgent

                    msg = String.Format( _
                    "User Agent: {0}" + ControlChars.Lf, userAgent)

                    ' </Snippet4>
                    Console.Write(msg)


                Case "/add"

                    ' <Snippet5>
                    ' Create a new ClientTarget object.
                    clientTarget = New ClientTarget( _
                    "my alias", "My User Agent")

                    ' Add the clientTarget to 
                    ' the collection.
                    clientTargets.Add(clientTarget)

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet5>
                    aliasStr = clientTarget.Alias
                    userAgent = clientTarget.UserAgent

                    msg = String.Format( _
                    "Alias:      {0}" + ControlChars.Lf + _
                    "User Agent: {1}" + ControlChars.Lf, _
                    aliasStr, userAgent)


                    Console.Write(msg)


                Case "/clear"

                    ' <Snippet6>
                    ' Clear the client target collection.
                    clientTargets.Clear()

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet6>

                Case "/remove1"

                    ' <Snippet7>
                    ' Create a ClientTarget object.
                    clientTarget = New ClientTarget( _
                    "my alias", "My User Agent")

                    ' Remove it from the collection
                    ' (if exists).
                    clientTargets.Remove(clientTarget)

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet7>
                    aliasStr = clientTarget.Alias
                    userAgent = clientTarget.UserAgent

                    msg = String.Format( _
                    "Alias:      {0}" + ControlChars.Lf + _
                    "User Agent: {1}" + ControlChars.Lf, _
                    aliasStr, userAgent)

                    Console.Write(msg)


                Case "/remove2"

                    ' <Snippet8>
                    ' Remove the client target with the
                    ' specified alias from the collection
                    ' (if exists).
                    clientTargets.Remove("my alias")

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' </Snippet8>

                Case "/remove3"

                    ' <Snippet9>
                    ' Remove the client target at the 
                    ' specified index from the collection.
                    clientTargets.RemoveAt(0)

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If

                    ' </Snippet9>

                Case "/all"
                    Dim allClientTargets As New StringBuilder()

                    Dim clTarget As ClientTarget
                    For Each clTarget In clientTargets
                        aliasStr = clTarget.Alias
                        userAgent = clTarget.UserAgent

                        msg = String.Format("Alias:      {0}" + _
                        ControlChars.Lf + "User Agent: {1}" + _
                        ControlChars.Lf, aliasStr, userAgent)

                        allClientTargets.AppendLine(msg)
                    Next clTarget

                    Console.Write(allClientTargets.ToString())


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
End Class 'UsingClientTarget