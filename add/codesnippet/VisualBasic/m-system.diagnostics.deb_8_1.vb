        Catch e As Exception
            Debug.Fail("Invalid value: " + value.ToString(), "Resetting value to newValue.")
            value = newValue
        End Try