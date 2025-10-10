using System;
using System.Collections.Generic;
using System.Linq;

namespace anonymous_types
{
    // <ProductDefinition>
    class Product
    {
        public string? Color {get;set;}
        public decimal Price {get;set;}
        public string? Name {get;set;}
        public string? Category {get;set;}
        public string? Size {get;set;}
    }
    // </ProductDefinition>
    class Anonymous
    {
        static void Main()
        {
            // Don't show this unless you add a bunch more
            // properties to the type. Otherwise it obviates the
            // need for the anonymous type.
            List<Product> products = new ()
            {
                new Product() { Color="Orange", Price=2.00M},
            };

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
    }
}
