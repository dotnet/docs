                Dim query =
            From pet In pets
            Group pet.Name By Age = pet.Age Into ageGroup = Group