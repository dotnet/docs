namespace LinqSamples;

public static class InnerJoins
{
    public static void Basic()
    {
        // <inner_joins_1>
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");
        Person rui = new("Rui", "Raposo");

        List<Person> people = new() { magnus, terry, charlotte, arlene, rui };

        List<Pet> pets = new()
        {
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", rui),
            new("Daisy", magnus),
        };

        // Create a collection of person-pet pairs. Each element in the collection
        // is an anonymous type containing both the person's name and their pet's name.
        var query =
            from person in people
            join pet in pets on person equals pet.Owner
            select new
            {
                OwnerName = person.FirstName,
                PetName = pet.Name
            };

        foreach (var ownerAndPet in query)
        {
            Console.WriteLine($"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}");
        }

        /* Output:
             "Daisy" is owned by Magnus
             "Barley" is owned by Terry
             "Boots" is owned by Terry
             "Whiskers" is owned by Charlotte
             "Blue Moon" is owned by Rui
        */
        // </inner_joins_1>
    }

    public static void BasicMethodSyntax()
    {
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");
        Person rui = new("Rui", "Raposo");

        List<Person> people = new() { magnus, terry, charlotte, arlene, rui };

        List<Pet> pets = new()
        {
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", rui),
            new("Daisy", magnus),
        };

        var query =
            people.Join(pets,
                        person => person,
                        pet => pet.Owner,
                        (person, pet) =>
                            new { OwnerName = person.FirstName, PetName = pet.Name });

        foreach (var ownerAndPet in query)
        {
            Console.WriteLine($"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}");
        }
    }

    public static void CompositeKey()
    {
        // <inner_joins_2>
        List<Employee> employees = new()
        {
            new(FirstName: "Terry", LastName: "Adams", EmployeeID: 522459),
            new("Charlotte", "Weiss", 204467),
            new("Magnus", "Hedland", 866200),
            new("Vernette", "Price", 437139)
        };

        List<Student> students = new()
        {
            new(FirstName: "Vernette", LastName: "Price", StudentID: 9562),
            new("Terry", "Earls", 9870),
            new("Terry", "Adams", 9913)
        };

        // Join the two data sources based on a composite key consisting of first and last name,
        // to determine which employees are also students.
        var query =
            from employee in employees
            join student in students on new
            {
                employee.FirstName,
                employee.LastName
            } equals new
            {
                student.FirstName,
                student.LastName
            }
            select employee.FirstName + " " + employee.LastName;

        Console.WriteLine("The following people are both employees and students:");
        foreach (string name in query)
        {
            Console.WriteLine(name);
        }

        /* Output:
            The following people are both employees and students:
            Terry Adams
            Vernette Price
         */
        // </inner_joins_2>
    }

    public static void CompositeKeyMethodSyntax()
    {
        List<Employee> employees = new()
        {
            new(FirstName: "Terry", LastName: "Adams", EmployeeID: 522459),
            new("Charlotte", "Weiss", 204467),
            new("Magnus", "Hedland", 866200),
            new("Vernette", "Price", 437139)
        };

        List<Student> students = new()
        {
            new(FirstName: "Vernette", LastName: "Price", StudentID: 9562),
            new("Terry", "Earls", 9870),
            new("Terry", "Adams", 9913)
        };

        var query = employees.Join(
             students,
             employee => new {FirstName = employee.FirstName, LastName = employee.LastName },
             student => new { FirstName = student.FirstName, student.LastName },
             (employee, student) => $"{employee.FirstName} {employee.LastName}"
         );

        Console.WriteLine("The following people are both employees and students:");
        foreach (string name in query)
        {
            Console.WriteLine(name);
        }
    }

    public static void MultipleJoin()
    {
        // <inner_joins_3>
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");
        Person rui = new("Rui", "Raposo");
        Person phyllis = new("Phyllis", "Harris");

        List<Person> people = new() { magnus, terry, charlotte, arlene, rui, phyllis };

        List<Cat> cats = new()
        {
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", rui),
            new("Daisy", magnus),
        };

        List<Dog> dogs = new()
        {
            new(Name: "Four Wheel Drive", Owner: phyllis),
            new("Duke", magnus),
            new("Denim", terry),
            new("Wiley", charlotte),
            new("Snoopy", rui),
            new("Snickers", arlene),
        };

        // The first join matches Person and Cat.Owner from the list of people and
        // cats, based on a common Person. The second join matches dogs whose names start
        // with the same letter as the cats that have the same owner.
        var query =
            from person in people
            join cat in cats on person equals cat.Owner
            join dog in dogs on new
            {
                Owner = person,
                Letter = cat.Name.Substring(0, 1)
            } equals new
            {
                dog.Owner,
                Letter = dog.Name.Substring(0, 1)
            }
            select new
            {
                CatName = cat.Name,
                DogName = dog.Name
            };

        foreach (var obj in query)
        {
            Console.WriteLine($"The cat \"{obj.CatName}\" shares a house, and the first letter of their name, with \"{obj.DogName}\".");
        }

        /* Output:
             The cat "Daisy" shares a house, and the first letter of their name, with "Duke".
             The cat "Whiskers" shares a house, and the first letter of their name, with "Wiley".
         */
        // </inner_joins_3>
    }

    public static void MultipleJoinMethodSyntax()
    {
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");
        Person rui = new("Rui", "Raposo");
        Person phyllis = new("Phyllis", "Harris");

        List<Person> people = new() { magnus, terry, charlotte, arlene, rui, phyllis };

        List<Cat> cats = new()
        {
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", rui),
            new("Daisy", magnus),
        };

        List<Dog> dogs = new()
        {
            new(Name: "Four Wheel Drive", Owner: phyllis),
            new("Duke", magnus),
            new("Denim", terry),
            new("Wiley", charlotte),
            new("Snoopy", rui),
            new("Snickers", arlene),
        };

        var query = people.Join(cats,
                person => person,
                cat => cat.Owner,
                (person, cat) => new { person, cat })
            .Join(dogs,
                commonOwner => new { Owner = commonOwner.person, Letter = commonOwner.cat.Name.Substring(0, 1) },
                dog => new { dog.Owner, Letter = dog.Name.Substring(0, 1) },
                (commonOwner, dog) => new { CatName = commonOwner.cat.Name, DogName = dog.Name });

        foreach (var obj in query)
        {
            Console.WriteLine($"The cat \"{obj.CatName}\" shares a house, and the first letter of their name, with \"{obj.DogName}\".");
        }
    }

    public static void InnerGroupJoin()
    {
        // <inner_joins_4>
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");

        List<Person> people = new() { magnus, terry, charlotte, arlene };

        List<Pet> pets = new()
        {
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", terry),
            new("Daisy", magnus),
        };

        var query1 =
            from person in people
            join pet in pets on person equals pet.Owner into gj
            from subpet in gj
            select new
            {
                OwnerName = person.FirstName,
                PetName = subpet.Name
            };

        Console.WriteLine("Inner join using GroupJoin():");
        foreach (var v in query1)
        {
            Console.WriteLine($"{v.OwnerName} - {v.PetName}");
        }

        var query2 =
            from person in people
            join pet in pets on person equals pet.Owner
            select new
            {
                OwnerName = person.FirstName,
                PetName = pet.Name
            };

        Console.WriteLine();
        Console.WriteLine("The equivalent operation using Join():");
        foreach (var v in query2)
        {
            Console.WriteLine($"{v.OwnerName} - {v.PetName}");
        }

        /* Output:
            Inner join using GroupJoin():
            Magnus - Daisy
            Terry - Barley
            Terry - Boots
            Terry - Blue Moon
            Charlotte - Whiskers
        
            The equivalent operation using Join():
            Magnus - Daisy
            Terry - Barley
            Terry - Boots
            Terry - Blue Moon
            Charlotte - Whiskers
        */
        // </inner_joins_4>
    }

    public static void InnerGroupJoinMethodSyntax()
    {
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");

        List<Person> people = new() { magnus, terry, charlotte, arlene };

        List<Pet> pets = new()
        {
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", terry),
            new("Daisy", magnus),
        };

        var query1 = people.GroupJoin(pets,
                person => person,
                pet => pet.Owner,
                (person, gj) => new { person, gj })
            .SelectMany(pet => pet.gj,
                (groupJoinPet, subpet) => new { OwnerName = groupJoinPet.person.FirstName, PetName = subpet.Name });

        Console.WriteLine("Inner join using GroupJoin():");
        foreach (var v in query1)
        {
            Console.WriteLine($"{v.OwnerName} - {v.PetName}");
        }

        var query2 = people.Join(pets,
            person => person,
            pet => pet.Owner,
            (person, pet) => new { OwnerName = person.FirstName, PetName = pet.Name });

        Console.WriteLine();
        Console.WriteLine("The equivalent operation using Join():");
        foreach (var v in query2)
        {
            Console.WriteLine($"{v.OwnerName} - {v.PetName}");
        }
    }
}
