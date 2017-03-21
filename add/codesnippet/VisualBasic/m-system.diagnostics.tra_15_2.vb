        Select Case option1
            Case OptionConsts.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Trace.Fail("Unsupported option " & option1, "Result set to 1.0")
                result = 1.0
        End Select