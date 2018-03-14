    Sub gotoStatementDemo()
        Dim number As Integer = 1
        Dim sampleString As String
        ' Evaluate number and branch to appropriate label.
        If number = 1 Then GoTo Line1 Else GoTo Line2
Line1:
        sampleString = "Number equals 1"
        GoTo LastLine
Line2:
        ' The following statement never gets executed because number = 1.
        sampleString = "Number equals 2"
LastLine:
        ' Write "Number equals 1" in the Debug window.
        Debug.WriteLine(sampleString)
    End Sub