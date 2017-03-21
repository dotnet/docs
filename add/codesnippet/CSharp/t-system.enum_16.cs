      Pets familyPets = Pets.Dog | Pets.Cat;
      if ((familyPets & Pets.Dog) == Pets.Dog)
         Console.WriteLine("The family has a dog.");
      // The example displays the following output:
      //       The family has a dog.      