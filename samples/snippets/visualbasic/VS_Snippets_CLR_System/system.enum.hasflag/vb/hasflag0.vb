' Visual Basic .NET Document
Option Strict On

' <Snippet1>
<Flags> Public Enum Pets
   None = 0
   Dog = 1
   Cat = 2
   Bird = 4
   Rabbit = 8
   Other = 16
End Enum

Module Example
   Public Sub Main()
      Dim petsInFamilies() As Pets = { Pets.None, Pets.Dog Or Pets.Cat, Pets.Dog }
      Dim familiesWithoutPets As Integer
      Dim familiesWithDog As Integer
      
      For Each petsInFamily In petsInFamilies
         ' Count the number of families that have no pets.
         If petsInFamily.Equals(Pets.None) Then
            familiesWithoutPets += 1 
        ' Of families that have pets, count the number of families with a dog.
         Else If petsInFamily.HasFlag(Pets.Dog) Then
            familiesWithDog += 1
         End If
      Next
      Console.WriteLine("{0} of {1} families in the sample have no pets.", 
                        familiesWithoutPets, petsInFamilies.Length)   
      Console.WriteLine("{0} of {1} families in the sample have a dog.", 
                        familiesWithDog, petsInFamilies.Length)   
   End Sub
End Module
' The example displays the following output:
'       1 of 3 families in the sample have no pets.
'       2 of 3 families in the sample have a dog.
' </Snippet1>

