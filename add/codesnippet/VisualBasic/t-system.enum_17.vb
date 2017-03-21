      Dim familyPets As Pets = Pets.Dog Or Pets.Cat
      If familyPets = Pets.None Then
         Console.WriteLine("The family has no pets.")
      Else
         Console.WriteLine("The family has pets.")   
      End If
      ' The example displays the following output:
      '       The family has pets.      