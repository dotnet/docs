    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter _
    As System.Web.Management.WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)
   
        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine( _
        "Custom Process Information:")
        formatter.IndentationLevel += 1

        ' Display the process information.
        formatter.AppendLine(GetAccountName())
        formatter.AppendLine(GetProcessId())
        formatter.AppendLine(GetProcessName())
        formatter.IndentationLevel -= 1
        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatToString