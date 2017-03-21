        switch (option) {
            case Option.First:
               result = 1.0;
               break;
         
            // Insert additional cases.
         
            default:
               Trace.Fail("Unsupported option " + option, "Result set to 1.0");
               result = 1.0;
               break;
        }