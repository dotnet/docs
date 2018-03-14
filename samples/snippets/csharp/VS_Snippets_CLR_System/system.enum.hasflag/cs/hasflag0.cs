// <Snippet1>
using System;

[Flags] public enum Pets {
   None = 0,
   Dog = 1,
   Cat = 2,
   Bird = 4,
   Rabbit = 8,
   Other = 16
}

public class Example
{
   public static void Main()
   {
      Pets[] petsInFamilies = { Pets.None, Pets.Dog | Pets.Cat, Pets.Dog };
      int familiesWithoutPets = 0;
      int familiesWithDog = 0;

      foreach (var petsInFamily in petsInFamilies)
      {
         // Count families that have no pets.
         if (petsInFamily.Equals(Pets.None))
            familiesWithoutPets++;
         // Of families with pets, count families that have a dog.
         else if (petsInFamily.HasFlag(Pets.Dog))
            familiesWithDog++;
      }
      Console.WriteLine("{0} of {1} families in the sample have no pets.", 
                        familiesWithoutPets, petsInFamilies.Length);   
      Console.WriteLine("{0} of {1} families in the sample have a dog.", 
                        familiesWithDog, petsInFamilies.Length);   
   }
}
// The example displays the following output:
//       1 of 3 families in the sample have no pets.
//       2 of 3 families in the sample have a dog.
// </Snippet1>
