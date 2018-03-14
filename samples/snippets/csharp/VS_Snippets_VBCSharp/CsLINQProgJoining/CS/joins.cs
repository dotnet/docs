using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Joins
{
    class Joins
    {
        static void Main(string[] args)
        {
            //LeftOuterJoin.LeftOuterJoinExample();
            //GroupJoinXML.GroupJoinXMLExample();
            //GroupJoins.GroupJoinExample();
            //InnerGroupJoin.InnerGroupJoinExample();
            //MultipleJoin.MultipleJoinExample();
            //CompositeKeyJoin.CompositeKeyJoinExample();
            InnerJoin.InnerJoinExample();
        }
    }

    class InnerJoin
    {
        // <Snippet1>
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        /// <summary>
        /// Simple inner join.
        /// </summary>
        public static void InnerJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a collection of person-pet pairs. Each element in the collection
            // is an anonymous type containing both the person's name and their pet's name.
            var query = from person in people
                        join pet in pets on person equals pet.Owner
                        select new { OwnerName = person.FirstName, PetName = pet.Name };

            foreach (var ownerAndPet in query)
            {
                Console.WriteLine("\"{0}\" is owned by {1}", ownerAndPet.PetName, ownerAndPet.OwnerName);
            }
        }

        // This code produces the following output:
        //
        // "Daisy" is owned by Magnus
        // "Barley" is owned by Terry
        // "Boots" is owned by Terry
        // "Whiskers" is owned by Charlotte
        // "Blue Moon" is owned by Rui

        // </Snippet1>
    }

    class CompositeKeyJoin
    {
        // <Snippet2>
        class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int EmployeeID { get; set; }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int StudentID { get; set; }
        }

        /// <summary>
        /// Performs a join operation using a composite key.
        /// </summary>
        public static void CompositeKeyJoinExample()
        {
            // Create a list of employees.
            List<Employee> employees = new List<Employee> {
                new Employee { FirstName = "Terry", LastName = "Adams", EmployeeID = 522459 },
                 new Employee { FirstName = "Charlotte", LastName = "Weiss", EmployeeID = 204467 },
                 new Employee { FirstName = "Magnus", LastName = "Hedland", EmployeeID = 866200 },
                 new Employee { FirstName = "Vernette", LastName = "Price", EmployeeID = 437139 } };

            // Create a list of students.
            List<Student> students = new List<Student> {
                new Student { FirstName = "Vernette", LastName = "Price", StudentID = 9562 },
                new Student { FirstName = "Terry", LastName = "Earls", StudentID = 9870 },
                new Student { FirstName = "Terry", LastName = "Adams", StudentID = 9913 } };

            // Join the two data sources based on a composite key consisting of first and last name,
            // to determine which employees are also students.
            IEnumerable<string> query = from employee in employees
                                        join student in students
                                        on new { employee.FirstName, employee.LastName }
                                        equals new { student.FirstName, student.LastName }
                                        select employee.FirstName + " " + employee.LastName;

            Console.WriteLine("The following people are both employees and students:");
            foreach (string name in query)
                Console.WriteLine(name);
        }

        // This code produces the following output:
        //
        // The following people are both employees and students:
        // Terry Adams
        // Vernette Price

        // </Snippet2>
    }

    class MultipleJoin
    {
        // <Snippet3>
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        class Cat : Pet
        { }

        class Dog : Pet
        { }

        public static void MultipleJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };
            Person phyllis = new Person { FirstName = "Phyllis", LastName = "Harris" };

            Cat barley = new Cat { Name = "Barley", Owner = terry };
            Cat boots = new Cat { Name = "Boots", Owner = terry };
            Cat whiskers = new Cat { Name = "Whiskers", Owner = charlotte };
            Cat bluemoon = new Cat { Name = "Blue Moon", Owner = rui };
            Cat daisy = new Cat { Name = "Daisy", Owner = magnus };

            Dog fourwheeldrive = new Dog { Name = "Four Wheel Drive", Owner = phyllis };
            Dog duke = new Dog { Name = "Duke", Owner = magnus };
            Dog denim = new Dog { Name = "Denim", Owner = terry };
            Dog wiley = new Dog { Name = "Wiley", Owner = charlotte };
            Dog snoopy = new Dog { Name = "Snoopy", Owner = rui };
            Dog snickers = new Dog { Name = "Snickers", Owner = arlene };

            // Create three lists.
            List<Person> people =
                new List<Person> { magnus, terry, charlotte, arlene, rui, phyllis };
            List<Cat> cats =
                new List<Cat> { barley, boots, whiskers, bluemoon, daisy };
            List<Dog> dogs =
                new List<Dog> { fourwheeldrive, duke, denim, wiley, snoopy, snickers };

            // The first join matches Person and Cat.Owner from the list of people and
            // cats, based on a common Person. The second join matches dogs whose names start
            // with the same letter as the cats that have the same owner.
            var query = from person in people
                        join cat in cats on person equals cat.Owner
                        join dog in dogs on 
                        new { Owner = person, Letter = cat.Name.Substring(0, 1) }
                        equals new { dog.Owner, Letter = dog.Name.Substring(0, 1) }
                        select new { CatName = cat.Name, DogName = dog.Name };

            foreach (var obj in query)
            {
                Console.WriteLine(
                    "The cat \"{0}\" shares a house, and the first letter of their name, with \"{1}\".", 
                    obj.CatName, obj.DogName);
            }
        }

        // This code produces the following output:
        //
        // The cat "Daisy" shares a house, and the first letter of their name, with "Duke".
        // The cat "Whiskers" shares a house, and the first letter of their name, with "Wiley".

        // </Snippet3>
    }

    class InnerGroupJoin
    {
        // <Snippet4>
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        /// <summary>
        /// Performs an inner join by using GroupJoin().
        /// </summary>
        public static void InnerGroupJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query1 = from person in people
                         join pet in pets on person equals pet.Owner into gj
                         from subpet in gj
                         select new { OwnerName = person.FirstName, PetName = subpet.Name };

            Console.WriteLine("Inner join using GroupJoin():");
            foreach (var v in query1)
            {
                Console.WriteLine("{0} - {1}", v.OwnerName, v.PetName);
            }

            var query2 = from person in people
                         join pet in pets on person equals pet.Owner
                         select new { OwnerName = person.FirstName, PetName = pet.Name };
                
            Console.WriteLine("\nThe equivalent operation using Join():");
            foreach (var v in query2)
                Console.WriteLine("{0} - {1}", v.OwnerName, v.PetName);
        }

        // This code produces the following output:
        //
        // Inner join using GroupJoin():
        // Magnus - Daisy
        // Terry - Barley
        // Terry - Boots
        // Terry - Blue Moon
        // Charlotte - Whiskers
        //
        // The equivalent operation using Join():
        // Magnus - Daisy
        // Terry - Barley
        // Terry - Boots
        // Terry - Blue Moon
        // Charlotte - Whiskers

        // </Snippet4>
    }

    class GroupJoins
    {
        // <Snippet5>
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        /// <summary>
        /// This example performs a grouped join.
        /// </summary>
        public static void GroupJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a list where each element is an anonymous type
            // that contains the person's first name and a collection of 
            // pets that are owned by them.
            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        select new { OwnerName = person.FirstName, Pets = gj };

            foreach (var v in query)
            {
                // Output the owner's name.
                Console.WriteLine("{0}:", v.OwnerName);
                // Output each of the owner's pet's names.
                foreach (Pet pet in v.Pets)
                    Console.WriteLine("  {0}", pet.Name);
            }
        }

        // This code produces the following output:
        //
        // Magnus:
        //   Daisy
        // Terry:
        //   Barley
        //   Boots
        //   Blue Moon
        // Charlotte:
        //   Whiskers
        // Arlene:

        // </Snippet5>
    }

    class GroupJoinXML
    {
        // <Snippet6>

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        /// <summary>
        /// This example creates XML output from a grouped join.
        /// </summary>
        public static void GroupJoinXMLExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create XML to display the hierarchical organization of people and their pets.
            XElement ownersAndPets = new XElement("PetOwners",
                from person in people
                join pet in pets on person equals pet.Owner into gj
                select new XElement("Person",
                    new XAttribute("FirstName", person.FirstName),
                    new XAttribute("LastName", person.LastName),
                    from subpet in gj
                    select new XElement("Pet", subpet.Name)));

            Console.WriteLine(ownersAndPets);
        }

        // This code produces the following output:
        //
        // <PetOwners>
        //   <Person FirstName="Magnus" LastName="Hedlund">
        //     <Pet>Daisy</Pet>
        //   </Person>
        //   <Person FirstName="Terry" LastName="Adams">
        //     <Pet>Barley</Pet>
        //     <Pet>Boots</Pet>
        //     <Pet>Blue Moon</Pet>
        //   </Person>
        //   <Person FirstName="Charlotte" LastName="Weiss">
        //     <Pet>Whiskers</Pet>
        //   </Person>
        //   <Person FirstName="Arlene" LastName="Huff" />
        // </PetOwners>

        // </Snippet6>
    }

    class LeftOuterJoin
    {
        // <Snippet7>
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        public static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.FirstName, PetName = (subpet == null ? String.Empty : subpet.Name) };

            foreach (var v in query)
            {
                Console.WriteLine("{0,-15}{1}", v.FirstName + ":", v.PetName);
            }
        }

        // This code produces the following output:
        //
        // Magnus:         Daisy
        // Terry:          Barley
        // Terry:          Boots
        // Terry:          Blue Moon
        // Charlotte:      Whiskers
        // Arlene:

        // </Snippet7>
    }
}
