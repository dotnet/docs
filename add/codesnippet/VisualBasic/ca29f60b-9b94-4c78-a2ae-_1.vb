   ' Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)

        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine("Custom Request Information:")

        formatter.IndentationLevel += 1

        ' Display the request information obtained 
        ' using the WebRequestInformation object.
        formatter.AppendLine(GetRequestPath())
        formatter.AppendLine(GetRequestUrl())
        formatter.AppendLine(GetRequestUserHostAdddress())
        formatter.AppendLine(GetRequestPrincipal())
        formatter.IndentationLevel -= 1

        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails 