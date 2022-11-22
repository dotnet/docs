using System.Text.Json;
using System.Text.Json.Serialization;

namespace PreserveReferencesMultipleCalls
{
    // <Employee>
    public class Employee
    {
        public string? Name { get; set; }
        public Employee? Manager { get; set; }
        public List<Employee>? DirectReports { get; set; }
    }
    // </Employee>

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

            tyler.DirectReports = new List<Employee> { adrian };
            adrian.Manager = tyler;

            var employees = new List<Employee> { tyler, adrian };
            SerializeEmployees(employees);
        }

        static void SerializeEmployees(List<Employee> employees)
        {
            // <CallSerializer>
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            var myReferenceHandler = new MyReferenceHandler();
            options.ReferenceHandler = myReferenceHandler;

            string json;
            foreach (Employee emp in employees)
            {
                json = JsonSerializer.Serialize(emp, options);
                DoSomething(json);
            }

            // Reset after serializing to avoid out of bounds memory growth in the resolver.
            myReferenceHandler.Reset();
            // </CallSerializer>
        }

        static void DoSomething(string json)
        {
            Console.WriteLine(json);
        }
    }
}

// Output:
//{
//    "$id": "1",
//  "Name": "Tyler Stein",
//  "Manager": null,
//  "DirectReports": {
//        "$id": "2",
//    "$values": [
//      {
//            "$id": "3",
//        "Name": "Adrian King",
//        "Manager": {
//                "$ref": "1"
//        },
//        "DirectReports": null
//      }
//    ]
//  }
//}
//{
//    "$ref": "3"
//}
