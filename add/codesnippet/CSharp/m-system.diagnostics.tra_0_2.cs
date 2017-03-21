        switch (option) {
            case Option.First:
               result = 1.0;
               break;
         
            // Insert additional cases.
            default:
               Trace.Fail("Unknown Option " + option);
               result = 1.0;
               break;
        }