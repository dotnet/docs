using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WhatsNew
{
    internal class Serialization
    {
        // <InterfaceHierarchies>
        public static void InterfaceHierarchies()
        {
            IDerived value = new DerivedImplement { Base = 0, Derived = 1 };
            string json = JsonSerializer.Serialize(value);
            Console.WriteLine(json); // {"Derived":1,"Base":0}
        }

        public interface IBase
        {
            public int Base { get; set; }
        }

        public interface IDerived : IBase
        {
            public int Derived { get; set; }
        }

        public class DerivedImplement : IDerived
        {
            public int Base { get; set; }
            public int Derived { get; set; }
        }
        // </InterfaceHierarchies>

        // <ReadOnlyProperties>
        public static void ReadOnlyProperties()
        {
            CustomerInfo customer = JsonSerializer.Deserialize<CustomerInfo>("""
                { "Names":["John Doe"], "Company":{"Name":"Contoso"} }
                """)!;

            Console.WriteLine(JsonSerializer.Serialize(customer));
        }

        class CompanyInfo
        {
            public required string Name { get; set; }
            public string? PhoneNumber { get; set; }
        }

        [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
        class CustomerInfo
        {
            // Both of these properties are read-only.
            public List<string> Names { get; } = new();
            public CompanyInfo Company { get; } = new()
            {
                Name = "N/A",
                PhoneNumber = "N/A"
            };
        }
        // </ReadOnlyProperties>

        // <NonPublicMembers>
        public static void NonPublicMembers()
        {
            string json = JsonSerializer.Serialize(new MyPoco(42));
            Console.WriteLine(json);
            // {"X":42}

            JsonSerializer.Deserialize<MyPoco>(json);
        }

        public class MyPoco
        {
            [JsonConstructor]
            internal MyPoco(int x) => X = x;

            [JsonInclude]
            internal int X { get; }
        }
        // </NonPublicMembers>

        // <StreamingDeserialization>
        public async static void StreamingDeserialization()
        {
            const string RequestUri = "https://api.contoso.com/books";
            using var client = new HttpClient();
            IAsyncEnumerable<Book?> books = client.GetFromJsonAsAsyncEnumerable<Book>(RequestUri);

            await foreach (Book? book in books)
            {
                Console.WriteLine($"Read book '{book?.title}'");
            }
        }

        public record Book(int id, string title, string author, int publishedYear);
        // </StreamingDeserialization>
    }
}
