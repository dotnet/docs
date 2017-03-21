        Select Case option1
            Case OptionConsts.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Trace.Fail(("Unknown Option " & option1))
                result = 1.0
        End Select