using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace object_collection_initializers
{
    // <SnippetHowToDictionaryInitializer>
    public class HowToDictionaryInitializer
    {
        class StudentName
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public int ID { get; set; }
        }

        public static void Main()
        {
            var students = new Dictionary<int, StudentName>()
            {
                { 111, new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 } },
                { 112, new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } },
                { 113, new StudentName { FirstName="Andy", LastName="Ruth", ID=198 } }
            };

            foreach(var index in Enumerable.Range(111, 3))
            {
                Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].LastName}");
            }
            Console.WriteLine();		

            var students2 = new Dictionary<int, StudentName>()
            {
                [111] = new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 },
                [112] = new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } ,
                [113] = new StudentName { FirstName="Andy", LastName="Ruth", ID=198 }
            };

            foreach (var index in Enumerable.Range(111, 3))
            {
                Console.WriteLine($"Student {index} is {students2[index].FirstName} {students2[index].LastName}");
            }
        }
    }
    // </SnippetHowToDictionaryInitializer>
}
