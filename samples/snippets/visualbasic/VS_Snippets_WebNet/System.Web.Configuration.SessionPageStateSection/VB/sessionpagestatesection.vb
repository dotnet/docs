Imports System
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text.RegularExpressions



Class UsingSessionPageState
   
    Public Overloads Shared Sub Main(ByVal args() As String)

        ' <Snippet1>
        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <sessionPageState> section.
        Dim sessionPageState _
        As SessionPageStateSection = _
        CType(configuration.GetSection( _
        "system.web/sessionPageState"), _
        SessionPageStateSection)

        ' </Snippet1>

        ' <Snippet2>
        ' Get the history size.
        Dim historySize As Integer = _
        sessionPageState.HistorySize

        Dim msg As String = _
        String.Format( _
        "Current history size: {0}" + _
        ControlChars.Lf, historySize.ToString())

        Console.Write(msg)


        If Not sessionPageState.IsReadOnly() Then
            ' Double current history size.
            sessionPageState.HistorySize = _
            2 * sessionPageState.HistorySize

            configuration.Save()

            historySize = sessionPageState.HistorySize

            msg = String.Format( _
            "New history size: {0}" + _
            ControlChars.Lf, historySize.ToString())

            Console.Write(msg)
        End If

        ' </Snippet2>

    End Sub 'Main 
End Class 'UsingSessionPageState 