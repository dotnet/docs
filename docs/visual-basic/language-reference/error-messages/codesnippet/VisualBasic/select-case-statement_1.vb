        Dim number As Integer = 8
        Select Case number
            Case 1 To 5
                Debug.WriteLine("Between 1 and 5, inclusive")
                ' The following is the only Case clause that evaluates to True.
            Case 6, 7, 8
                Debug.WriteLine("Between 6 and 8, inclusive")
            Case 9 To 10
                Debug.WriteLine("Equal to 9 or 10")
            Case Else
                Debug.WriteLine("Not between 1 and 10, inclusive")
        End Select