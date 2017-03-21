   ' Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)

        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine( _
        "Custom Thread Information:")

        formatter.IndentationLevel += 1

        ' Display the thread information obtained 
        formatter.AppendLine(GetThreadImpersonation())
        formatter.AppendLine(GetThreadStackTrace())
        formatter.AppendLine(GetThreadAccountName())
        formatter.AppendLine(GetThreadId())
        formatter.IndentationLevel -= 1

        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails 