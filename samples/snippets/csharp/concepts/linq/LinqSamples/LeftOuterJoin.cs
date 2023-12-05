namespace LinqSamples;

public static class LeftOuterJoin
{
    public static void LeftOuterJoin1()
    {
        // <left_outer_join_1>
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

        var query =
            from person in people
            join pet in pets on person equals pet.Owner into gj
            from subpet in gj.DefaultIfEmpty()
            select new
            {
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
        // </left_outer_join_1>
    }
}
