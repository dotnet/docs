      Dim familyPets As Pets = Pets.Dog Or Pets.Cat
      If familyPets.HasFlag(Pets.Dog) Then
         Console.WriteLine("The family has a dog.")
      End If
      ' The example displays the following output:
      '       The family has a dog.      