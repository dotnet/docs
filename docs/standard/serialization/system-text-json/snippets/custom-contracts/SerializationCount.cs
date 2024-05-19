using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Serialization
{
    // Custom attribute to annotate the property
    // we want to be incremented.
    [AttributeUsage(AttributeTargets.Property)]
    class SerializationCountAttribute : Attribute
    {
    }

    // Example type to serialize and deserialize.
    class Product
    {
        public string Name { get; set; } = "";
        [SerializationCount]
        public int RoundTrips { get; set; }
    }

    public class SerializationCountExample
    {
        // Custom modifier that increments the value
        // of a specific property on deserialization.
        static void IncrementCounterModifier(JsonTypeInfo typeInfo)
        {
            foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
            {
                if (propertyInfo.PropertyType != typeof(int))
                    continue;

                object[] serializationCountAttributes = propertyInfo.AttributeProvider?.GetCustomAttributes(typeof(SerializationCountAttribute), true) ?? Array.Empty<object>();
                SerializationCountAttribute? attribute = serializationCountAttributes.Length == 1 ? (SerializationCountAttribute)serializationCountAttributes[0] : null;

                if (attribute != null)
                {
                    Action<object, object?>? setProperty = propertyInfo.Set;
                    if (setProperty is not null)
                    {
                        propertyInfo.Set = (obj, value) =>
                        {
                            if (value != null)
                            {
                                // Increment the value by 1.
                                value = (int)value + 1;
                            }

                            setProperty (obj, value);
                        };
                    }
                }
            }
        }

        public static void RunIt()
        {
            var product = new Product
            {
                Name = "Aquafresh"
            };

            JsonSerializerOptions options = new()
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { IncrementCounterModifier }
                }
            };

            // First serialization and deserialization.
            string serialized = JsonSerializer.Serialize(product, options);
            Console.WriteLine(serialized);
            // {"Name":"Aquafresh","RoundTrips":0}

            Product deserialized = JsonSerializer.Deserialize<Product>(serialized, options)!;
            Console.WriteLine($"{deserialized.RoundTrips}");
            // 1

            // Second serialization and deserialization.
            serialized = JsonSerializer.Serialize(deserialized, options);
            Console.WriteLine(serialized);
            // { "Name":"Aquafresh","RoundTrips":1}

            deserialized = JsonSerializer.Deserialize<Product>(serialized, options)!;
            Console.WriteLine($"{deserialized.RoundTrips}");
            // 2
        }
    }
}
