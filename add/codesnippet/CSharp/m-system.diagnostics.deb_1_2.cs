switch (option) {
    case Option.First:
       result = 1.0;
       break;
 
    // Insert additional cases.
 
    default:
       Debug.Fail("Unknown Option " + option);
       result = 1.0;
       break;
 }