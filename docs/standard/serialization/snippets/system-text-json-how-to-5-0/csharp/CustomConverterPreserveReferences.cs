// Assuming that you wrote a custom converter for `Company` and you don't want to manually serialize the `Supervisor`, which is an `Employee`. 
// you want to delegate that to the Serializer and you also want to preserve the references that you have already saved.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomConverterPreserveReferences
{
    // <EmployeeAndCompany>
    public class Employee
    {
        public string? Name { get; set; }
        public Employee? Manager { get; set; }
        public List<Employee>? DirectReports { get; set; }
        public Company? Company { get; set; }
    }

    public class Company
    {
        public string? Name { get; set; }
        public Employee? Supervisor { get; set; }
    }
    // </EmployeeAndCompany>

    // <CompanyConverter>
    class CompanyConverter : JsonConverter<Company>
    {
        public override Company Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Company value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Name", value.Name);

            writer.WritePropertyName("Supervisor");
            JsonSerializer.Serialize(writer, value.Supervisor, options);

            writer.WriteEndObject();
        }
    }
    // </CompanyConverter>

    // <MyReferenceResolver>
    class MyReferenceResolver : ReferenceResolver
    {
        private uint _referenceCount;
        private readonly Dictionary<string, object> _referenceIdToObjectMap = new ();
        private readonly Dictionary<object, string> _objectToReferenceIdMap = new (ReferenceEqualityComparer.Instance);

        public override void AddReference(string referenceId, object value)
        {
            if (!_referenceIdToObjectMap.TryAdd(referenceId, value))
            {
                throw new JsonException();
            }
        }

        public override string GetReference(object value, out bool alreadyExists)
        {
            if (_objectToReferenceIdMap.TryGetValue(value, out string? referenceId))
            {
                alreadyExists = true;
            }
            else
            {
                _referenceCount++;
                referenceId = _referenceCount.ToString();
                _objectToReferenceIdMap.Add(value, referenceId);
                alreadyExists = false;
            }

            return referenceId;
        }

        public override object ResolveReference(string referenceId)
        {
            if (!_referenceIdToObjectMap.TryGetValue(referenceId, out object? value))
            {
                throw new JsonException();
            }

            return value;
        }
    }
    // </MyReferenceResolver>

    // <MyReferenceHandler>
    class MyReferenceHandler : ReferenceHandler
    {
        public MyReferenceHandler() => Reset();

        private ReferenceResolver? _rootedResolver;
        public override ReferenceResolver CreateResolver() => _rootedResolver!;
        public void Reset() => _rootedResolver = new MyReferenceResolver();

    }
    // </MyReferenceHandler>

    public class Program
    {
        public static void Main()
        {
            Employee tyler = new()
            {
                Name = "Tyler Stein"
            };

            Employee adrian = new()
            {
                Name = "Adrian King"
            };

            Company contoso = new()
            {
                Name = "Contoso",
                Supervisor = tyler
            };

            tyler.DirectReports = new List<Employee> { adrian };
            adrian.Manager = tyler;

            tyler.Company = contoso;
            adrian.Company = contoso;

            // <CallSerializer>
            var options = new JsonSerializerOptions();

            options.Converters.Add(new CompanyConverter());
            var myReferenceHandler = new MyReferenceHandler();
            options.ReferenceHandler = myReferenceHandler;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.WriteIndented = true;

            string str = JsonSerializer.Serialize(tyler, options);

            // Reset after serializing to avoid out of bounds memory growth in the resolver.
            myReferenceHandler.Reset();
            // </CallSerializer>

            Console.WriteLine(str);
        }
    }
}

// Output:
//{
//  "$id": "1",
//  "Name": "Tyler Stein",
//  "DirectReports": {
//    "$id": "2",
//    "$values": [
//      {
//        "$id": "3",
//        "Name": "Adrian King",
//        "Manager": {
//          "$ref": "1"
//        },
//        "Company": {
//          "Name": "Contoso",
//          "Supervisor": {
//            "$ref": "1"
//          }
//        }
//      }
//    ]
//  },
//  "Company": {
//    "Name": "Contoso",
//    "Supervisor": {
//      "$ref": "1"
//    }
//  }
//}
