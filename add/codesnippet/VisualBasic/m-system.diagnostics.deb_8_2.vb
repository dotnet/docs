        Select Case option1
            Case MyOption.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Debug.Fail("Unknown Option " & option1, "Result set to 1.0")
                result = 1.0
        End Select