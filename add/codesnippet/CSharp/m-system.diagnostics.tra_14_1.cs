        catch (Exception) {
            Trace.Fail("Invalid value: " + value.ToString(), 
               "Resetting value to newValue.");
            value = newValue;
        }