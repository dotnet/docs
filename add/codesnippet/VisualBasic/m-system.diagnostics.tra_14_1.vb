        Catch
            Trace.Fail("Invalid value: " & value.ToString(), _
                "Resetting value to newValue.")
            value = newValue
        End Try