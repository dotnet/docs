        Select Case myOption1
            Case MyOption.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Debug.Fail(("Unknown Option " & myOption1.ToString))
                result = 1.0
        End Select