using System.Xml.Linq;

namespace LinqSamples.Joins;

// <perform-inner-joins_0>
record Person(string FirstName, string LastName);
record Pet(string Name, Person Owner);
record Employee(string FirstName, string LastName, int EmployeeID);
record Student(string FirstName, string LastName, int StudentID);
record Cat(string Name, Person Owner) : Pet(Name, Owner);
record Dog(string Name, Person Owner) : Pet(Name, Owner);
// </perform-inner-joins_0>

// <order-the-results-of-a-join-clause_0>
record Product(string Name, int CategoryID);
record Category(string Name, int ID);
// </order-the-results-of-a-join-clause_0>

public static class Samples
{
    public static void Basic()
    {
        // <perform-inner-joins_1>
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
            select new { OwnerName = person.FirstName, PetName = pet.Name };

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
        // </perform-inner-joins_1>
    }

    public static void CompositeKey()
    {
        // <perform-inner-joins_2>
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
            join student in students on new {
                employee.FirstName,
                employee.LastName
            } equals new {
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
        // </perform-inner-joins_2>
    }

    public static void MultipleJoin()
    {
        // <perform-inner-joins_3>
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
            join dog in dogs on new {
                Owner = person,
                Letter = cat.Name.Substring(0, 1)
            } equals new {
                dog.Owner,
                Letter = dog.Name.Substring(0, 1)
            }
            select new {
                CatName = cat.Name,
                DogName = dog.Name
            };

        foreach (var obj in query)
        {
            Console.WriteLine(
                $"The cat \"{obj.CatName}\" shares a house, and the first letter of their name, with \"{obj.DogName}\"."
            );
        }

        /* Output:
             The cat "Daisy" shares a house, and the first letter of their name, with "Duke".
             The cat "Whiskers" shares a house, and the first letter of their name, with "Wiley".
         */
        // </perform-inner-joins_3>
    }

    public static void InnerGroupJoin()
    {
        // <perform-inner-joins_4>
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
            select new { OwnerName = person.FirstName, PetName = subpet.Name };

        Console.WriteLine("Inner join using GroupJoin():");
        foreach (var v in query1)
        {
            Console.WriteLine($"{v.OwnerName} - {v.PetName}");
        }

        var query2 =
            from person in people
            join pet in pets on person equals pet.Owner
            select new { OwnerName = person.FirstName, PetName = pet.Name };

        Console.WriteLine("\nThe equivalent operation using Join():");
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
        // </perform-inner-joins_4>
    }

    public static void GroupedJoin()
    {
        // <perform-grouped-joins_1>
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

        // Create a list where each element is an anonymous type
        // that contains the person's first name and a collection of
        // pets that are owned by them.
        var query =
            from person in people
            join pet in pets on person equals pet.Owner into gj
            select new { OwnerName = person.FirstName, Pets = gj };

        foreach (var v in query)
        {
            // Output the owner's name.
            Console.WriteLine($"{v.OwnerName}:");
            // Output each of the owner's pet's names.
            foreach (var pet in v.Pets)
            {
                Console.WriteLine($"  {pet.Name}");
            }
        }

        /* Output:
             Magnus:
               Daisy
             Terry:
               Barley
               Boots
               Blue Moon
             Charlotte:
               Whiskers
             Arlene:
         */
        // </perform-grouped-joins_1>
    }

    public static void GroupedJoinXML()
    {
        // <perform-grouped-joins_2>
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

        XElement ownersAndPets = new("PetOwners",
            from person in people
            join pet in pets on person equals pet.Owner into gj
            select new XElement("Person",
                new XAttribute("FirstName", person.FirstName),
                new XAttribute("LastName", person.LastName),
                from subpet in gj
                select new XElement("Pet", subpet.Name)
            )
        );

        Console.WriteLine(ownersAndPets);

        /* Output:
             <PetOwners>
               <Person FirstName="Magnus" LastName="Hedlund">
                 <Pet>Daisy</Pet>
               </Person>
               <Person FirstName="Terry" LastName="Adams">
                 <Pet>Barley</Pet>
                 <Pet>Boots</Pet>
                 <Pet>Blue Moon</Pet>
               </Person>
               <Person FirstName="Charlotte" LastName="Weiss">
                 <Pet>Whiskers</Pet>
               </Person>
               <Person FirstName="Arlene" LastName="Huff" />
             </PetOwners>
        */
        // </perform-grouped-joins_2>
    }

    public static void LeftOuterJoin()
    {
        // <perform-left-outer-joins_1>
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

        var query =
            from person in people
            join pet in pets on person equals pet.Owner into gj
            from subpet in gj.DefaultIfEmpty()
            select new {
                person.FirstName,
                PetName = subpet?.Name ?? string.Empty
            };

        foreach (var v in query)
        {
            Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}");
        }

        /* Output:
            Magnus:        Daisy
            Terry:         Barley
            Terry:         Boots
            Terry:         Blue Moon
            Charlotte:     Whiskers
            Arlene:
         */
        // </perform-left-outer-joins_1>
    }

    public static void OrderResultsOfJoin()
    {
        // <order-the-results-of-a-join-clause_1>
        List<Category> categories = new()
        {
            new(Name: "Beverages", ID: 001),
            new("Condiments", 002),
            new("Vegetables", 003),
            new("Grains", 004),
            new("Fruit", 005)
        };

        List<Product> products = new()
        {
            new(Name: "Cola", CategoryID: 001),
            new("Tea", 001),
            new("Mustard", 002),
            new("Pickles", 002),
            new("Carrots", 003),
            new("Bok Choy", 003),
            new("Peaches", 005),
            new("Melons", 005),
        };

        var groupJoinQuery2 =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID into prodGroup
            orderby category.Name
            select new {
                Category = category.Name,
                Products =
                    from prod2 in prodGroup
                    orderby prod2.Name
                    select prod2
            };

        foreach (var productGroup in groupJoinQuery2)
        {
            Console.WriteLine(productGroup.Category);
            foreach (var prodItem in productGroup.Products)
            {
                Console.WriteLine($"  {prodItem.Name,-10} {prodItem.CategoryID}");
            }
        }

        /* Output:
            Beverages
              Cola       1
              Tea        1
            Condiments
              Mustard    2
              Pickles    2
            Fruit
              Melons     5
              Peaches    5
            Grains
            Vegetables
              Bok Choy   3
              Carrots    3
         */
        // </order-the-results-of-a-join-clause_1>
    }

    public static void CustomJoins()
    {
        // <custom-join-operations_1>
        List<Category> categories = new()
        {
            new(Name: "Beverages", ID: 001),
            new("Condiments", 002),
            new("Vegetables", 003)
        };

        List<Product> products = new()
        {
            new("Tea", 001),
            new("Mustard", 002),
            new("Pickles", 002),
            new("Carrots", 003),
            new("Bok Choy", 003),
            new("Peaches", 005),
            new("Melons", 005),
            new("Ice Cream", 007),
            new("Mackerel", 012)
        };

        var crossJoinQuery =
            from c in categories
            from p in products
            select new { c.ID, p.Name };

        Console.WriteLine("Cross Join Query:");
        foreach (var v in crossJoinQuery)
        {
            Console.WriteLine($"{v.ID,-5}{v.Name}");
        }

        var nonEquijoinQuery =
            from p in products
            let catIds =
                from c in categories
                select c.ID
            where catIds.Contains(p.CategoryID) == true
            select new { Product = p.Name, p.CategoryID };

        Console.WriteLine("Non-equijoin query:");
        foreach (var v in nonEquijoinQuery)
        {
            Console.WriteLine($"{v.CategoryID,-5}{v.Product}");
        }

        /* Output:
            Cross Join Query:
            1    Tea
            1    Mustard
            1    Pickles
            1    Carrots
            1    Bok Choy
            1    Peaches
            1    Melons
            1    Ice Cream
            1    Mackerel
            2    Tea
            2    Mustard
            2    Pickles
            2    Carrots
            2    Bok Choy
            2    Peaches
            2    Melons
            2    Ice Cream
            2    Mackerel
            3    Tea
            3    Mustard
            3    Pickles
            3    Carrots
            3    Bok Choy
            3    Peaches
            3    Melons
            3    Ice Cream
            3    Mackerel
            Non-equijoin query:
            1    Tea
            2    Mustard
            2    Pickles
            3    Carrots
            3    Bok Choy
            Press any key to exit.
        */
        // </custom-join-operations_1>
    }
}
