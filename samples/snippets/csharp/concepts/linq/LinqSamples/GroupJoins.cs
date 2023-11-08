using System.Xml.Linq;

namespace LinqSamples;

public static class GroupJoins
{
    public static void GroupJoin1()
    {
        // <grouped_joins_1>
        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");

        List<Person> people = [magnus, terry, charlotte, arlene];

        List<Pet> pets =
        [
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", terry),
            new("Daisy", magnus),
        ];

        // Create a list where each element is an anonymous type
        // that contains the person's first name and a collection of
        // pets that are owned by them.
        var query =
            from person in people
            join pet in pets on person equals pet.Owner into gj
            select new
            {
                OwnerName = person.FirstName,
                Pets = gj
            };

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
        // </grouped_joins_1>
    }

    public static void GroupJoinXml()
    {
        // <grouped_joins_2>
        // using System.Xml.Linq;

        Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
        Person terry = new("Terry", "Adams");
        Person charlotte = new("Charlotte", "Weiss");
        Person arlene = new("Arlene", "Huff");

        List<Person> people = [magnus, terry, charlotte, arlene];

        List<Pet> pets =
        [
            new(Name: "Barley", Owner: terry),
            new("Boots", terry),
            new("Whiskers", charlotte),
            new("Blue Moon", terry),
            new("Daisy", magnus),
        ];

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
        // </grouped_joins_2>
    }
}
