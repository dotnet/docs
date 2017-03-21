      if (dimension1 < 0 || dimension2 < 0) {
         Console.WriteLine("Unable to create the array.");
         Console.WriteLine("Specify non-negative values for the two dimensions.");
      }   
      else {
         arr = Array.CreateInstance(typeof(String), 
                                    dimension1, dimension2);   
      }