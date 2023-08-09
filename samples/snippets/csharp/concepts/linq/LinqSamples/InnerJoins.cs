namespace LinqSamples;

public static class InnerJoins
{
    public static string Basic()
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

        string result = "";
        foreach (var ownerAndPet in query)
        {
            result += $"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}\r\n";
        }
        Console.Write(result);
        return result;

        /* Output:
             "Daisy" is owned by Magnus
             "Barley" is owned by Terry
             "Boots" is owned by Terry
             "Whiskers" is owned by Charlotte
             "Blue Moon" is owned by Rui
        */
        // </inner_joins_1>
    }

    public static string BasicMethodSyntax()
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

        // <inner_joins_method_syntax_1>
        var query =
            people.Join(pets,
                        person => person,
                        pet => pet.Owner,
                        (person, pet) =>
                            new { OwnerName = person.FirstName, PetName = pet.Name });
        // </inner_joins_method_syntax_1>

        string result = "";
        foreach (var ownerAndPet in query)
        {
            result += $"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}\r\n";
        }
        Console.Write(result);
        return result;
    }

    public static string CompositeKey()
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

        string result = "";
        result += "The following people are both employees and students:\r\n";
        foreach (string name in query)
        {
            result += $"{name}\r\n";
        }
        Console.Write(result);
        return result;

        /* Output:
            The following people are both employees and students:
            Terry Adams
            Vernette Price
         */
        // </inner_joins_2>
    }

    public static string CompositeKeyMethodSyntax()
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

        // <inner_joins_method_syntax_2>
        var query = employees.Join(
             students,
             employee => new {FirstName = employee.FirstName, LastName = employee.LastName },
             student => new { FirstName = student.FirstName, student.LastName },
             (employee, student) => $"{employee.FirstName} {employee.LastName}"
         );
        // </inner_joins_method_syntax_2>

        string result = "";
        result += "The following people are both employees and students:\r\n";
        foreach (string name in query)
        {
            result += $"{name}\r\n";
        }
        Console.Write(result);
        return result;
    }

    public static string MultipleJoin()
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

        string result = "";
        foreach (var obj in query)
        {
            result += $"The cat \"{obj.CatName}\" shares a house, and the first letter of their name, with \"{obj.DogName}\".\r\n";
        }
        Console.Write(result);
        return result;

        /* Output:
             The cat "Daisy" shares a house, and the first letter of their name, with "Duke".
             The cat "Whiskers" shares a house, and the first letter of their name, with "Wiley".
         */
        // </inner_joins_3>
    }

    public static string MultipleJoinMethodSyntax()
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

        // <inner_joins_method_syntax_3>
        var query = people.Join(cats,
                person => person,
                cat => cat.Owner,
                (person, cat) => new { person, cat })
            .Join(dogs,
                commonOwner => new { Owner = commonOwner.person, Letter = commonOwner.cat.Name.Substring(0, 1) },
                dog => new { dog.Owner, Letter = dog.Name.Substring(0, 1) },
                (commonOwner, dog) => new { CatName = commonOwner.cat.Name, DogName = dog.Name });
        // </inner_joins_method_syntax_3>

        string result = "";
        foreach (var obj in query)
        {
            result += $"The cat \"{obj.CatName}\" shares a house, and the first letter of their name, with \"{obj.DogName}\".\r\n";
        }
        Console.Write(result);
        return result;
    }

    public static string InnerGroupJoin()
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

        string result = "";
        result += "Inner join using GroupJoin():\r\n";
        foreach (var v in query1)
        {
            result += $"{v.OwnerName} - {v.PetName}\r\n";
        }

        var query2 =
            from person in people
            join pet in pets on person equals pet.Owner
            select new
            {
                OwnerName = person.FirstName,
                PetName = pet.Name
            };

        result += "\r\nThe equivalent operation using Join():\r\n";
        foreach (var v in query2)
        {
            result += $"{v.OwnerName} - {v.PetName}\r\n";
        }
        Console.Write(result);
        return result;

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

    public static string InnerGroupJoinMethodSyntax()
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

        // <inner_joins_method_syntax_4>
        var query1 = people.GroupJoin(pets,
                person => person,
                pet => pet.Owner,
                (person, gj) => new { person, gj })
            .SelectMany(pet => pet.gj,
                (groupJoinPet, subpet) => new { OwnerName = groupJoinPet.person.FirstName, PetName = subpet.Name });
        // </inner_joins_method_syntax_4>

        string result = "";
        result += "Inner join using GroupJoin():\r\n";
        foreach (var v in query1)
        {
            result += $"{v.OwnerName} - {v.PetName}\r\n";
        }

        // <inner_joins_method_syntax_5>
        var query2 = people.Join(pets,
            person => person,
            pet => pet.Owner,
            (person, pet) => new { OwnerName = person.FirstName, PetName = pet.Name });
        // </inner_joins_method_syntax_5>

        result += "\r\nThe equivalent operation using Join():\r\n";
        foreach (var v in query2)
        {
            result += $"{v.OwnerName} - {v.PetName}\r\n";
        }
        Console.Write(result);
        return result;
    }
}
