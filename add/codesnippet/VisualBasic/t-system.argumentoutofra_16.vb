      If dimension1 < 0 OrElse dimension2 < 0 Then
         Console.WriteLine("Unable to create the array.")
         Console.WriteLine("Specify non-negative values for the two dimensions.")
      Else
         arr = Array.CreateInstance(GetType(String), 
                                    dimension1, dimension2)   
      End If