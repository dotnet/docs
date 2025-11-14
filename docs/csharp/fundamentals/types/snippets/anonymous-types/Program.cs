using System;
using System.Collections.Generic;
using System.Linq;

namespace anonymous_types
{
    // <ProductDefinition>
    class Product
    {
        public string? Color { get; init; }
        public decimal Price { get; init; }
        public string? Name { get; init; }
        public string? Category { get; init; }
        public string? Size { get; init; }
    }
    // </ProductDefinition>

    class Anonymous
    {
        // <TupleDeconstructionMethod>
        static (string Name, int Age, string City) GetPersonInfo()
        {
            return ("Alice", 30, "Seattle");
        }
        // </TupleDeconstructionMethod>

        static void Main()
        {
            TupleExamples();
            TupleDeconstructionExamples();
            TupleMethodReturnExample();
            AnonymousTypeExamples();
            ProjectionInitializerExamples();
            AnonymousArrayExample();
            ToStringExample();
        }

        static void TupleExamples()
        {
            // <TupleExample>
            // Anonymous type example.
            var anonymousProduct = new { Name = "Widget", Price = 19.99M };
            Console.WriteLine($"Anonymous: {anonymousProduct.Name} costs ${anonymousProduct.Price}");

            // Equivalent using a tuple with named elements.
            var tupleProduct = (Name: "Widget", Price: 19.99M);
            Console.WriteLine($"Tuple: {tupleProduct.Name} costs ${tupleProduct.Price}");
            // </TupleExample>
        }

        static void TupleDeconstructionExamples()
        {
            // <TupleDeconstruction>
            // Deconstruct using var for all variables
            var (name, age, city) = GetPersonInfo();
            Console.WriteLine($"{name} is {age} years old and lives in {city}");
            // Output: Alice is 30 years old and lives in Seattle

            // Deconstruct with explicit types
            (string personName, int personAge, string personCity) = GetPersonInfo();
            Console.WriteLine($"{personName}, {personAge}, {personCity}");

            // Deconstruct into existing variables
            string existingName;
            int existingAge;
            string existingCity;
            (existingName, existingAge, existingCity) = GetPersonInfo();

            // Deconstruct and discard unwanted values using the discard pattern (_)
            var (name2, _, city2) = GetPersonInfo();
            Console.WriteLine($"{name2} lives in {city2}");
            // Output: Alice lives in Seattle
            // </TupleDeconstruction>

            // <TupleDeconstructionLoop>
            var people = new List<(string Name, int Age)>
            {
                ("Bob", 25),
                ("Carol", 35),
                ("Dave", 40)
            };

            foreach (var (personName2, personAge2) in people)
            {
                Console.WriteLine($"{personName2} is {personAge2} years old");
            }
            // </TupleDeconstructionLoop>
        }

        static void TupleMethodReturnExample()
        {
            // <DictionaryTupleExample>
            var configLookup = new Dictionary<int, (int Min, int Max)>()
            {
                [2] = (4, 10),
                [4] = (10, 20),
                [6] = (0, 23)
            };

            if (configLookup.TryGetValue(4, out (int Min, int Max) range))
            {
                Console.WriteLine($"Found range: min is {range.Min}, max is {range.Max}");
            }
            // Output: Found range: min is 10, max is 20
            // </DictionaryTupleExample>
        }

        static void AnonymousTypeExamples()
        {
            List<Product> products =
            [
                new Product { Color = "Orange", Price = 2.00M }
            ];

            //<snippet81>
            var productQuery =
                from prod in products
                select new { prod.Color, prod.Price };

            foreach (var v in productQuery)
            {
                Console.WriteLine("Color={0}, Price={1}", v.Color, v.Price);
            }
            //</snippet81>

            // <Snippet02>
            var apple = new { Item = "apples", Price = 1.35 };
            var onSale = apple with { Price = 0.79 };
            Console.WriteLine(apple);
            Console.WriteLine(onSale);
            // </Snippet02>

            // <Snippet03>
            var product = new Product();
            var bonus = new { note = "You won!" };
            var shipment = new { address = "Nowhere St.", product };
            var shipmentWithBonus = new { address = "Somewhere St.", product, bonus };
            // </Snippet03>
        }

        static void ProjectionInitializerExamples()
        {
            // <ProjectionInitializers>
            // Explicit member names.
            var personExplicit = new { FirstName = "Kyle", LastName = "Mit" };

            // Projection initializers (inferred member names).
            var firstName = "Kyle";
            var lastName = "Mit";
            var personInferred = new { firstName, lastName };

            // Both create equivalent anonymous types with the same property names.
            Console.WriteLine($"Explicit: {personExplicit.FirstName} {personExplicit.LastName}");
            Console.WriteLine($"Inferred: {personInferred.firstName} {personInferred.lastName}");
            // </ProjectionInitializers>

            // <ProjectionExample>
            var title = "Software Engineer";
            var department = "Engineering";
            var salary = 75000;

            // Using projection initializers.
            var employee = new { title, department, salary };

            // Equivalent to explicit syntax:
            // var employee = new { title = title, department = department, salary = salary };

            Console.WriteLine($"Title: {employee.title}, Department: {employee.department}, Salary: {employee.salary}");
            // </ProjectionExample>
        }

        static void AnonymousArrayExample()
        {
            // <AnonymousArray>
            var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 }};
            // </AnonymousArray>
        }

        static void ToStringExample()
        {
            // <ToStringExample>
            var v = new { Title = "Hello", Age = 24 };

            Console.WriteLine(v.ToString()); // "{ Title = Hello, Age = 24 }"
            // </ToStringExample>
        }
    }
}
