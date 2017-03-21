    switch (option1) {
        case MyOption.First:
           result = 1.0;
           break;
     
        // Insert additional cases.
     
        default:
           Debug.Fail("Unknown Option " + option1, "Result set to 1.0");
           result = 1.0;
           break;
     }