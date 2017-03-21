    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
 _
     ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine( _
        "Custom Application Information:")
        formatter.IndentationLevel += 1

        ' Display the application information.
        formatter.AppendLine(GetApplicationDomain())
        formatter.AppendLine(GetApplicationPath())
        formatter.AppendLine(GetApplicationVirtualPath())
        formatter.AppendLine(GetApplicationMachineName())
        formatter.AppendLine(GetApplicationTrustLevel())
        formatter.IndentationLevel -= 1
        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails
End Class 'SampleWebApplicationInformation 
