        ' From textReaderText, create a continuous paragraph 
        ' with two spaces between each sentence.
        Dim aLine, aParagraph As String
        Dim strReader As New StringReader(textReaderText)
        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then
                aParagraph = aParagraph & vbCrLf
                Exit While
            Else
                aParagraph = aParagraph & aLine & " "
            End If
        End While
        Console.WriteLine("Modified text:" & vbCrLf & vbCrLf & _ 
            aParagraph)