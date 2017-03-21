    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        
        formatter.TabSize = 4
        
        formatter.AppendLine("*SampleWebBaseEvent Start *")
        formatter.AppendLine("Custom information goes here")
        formatter.AppendLine("* SampleWebBaseEvent End *")
        ' Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)
        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails