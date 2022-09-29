using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Serialization
{
    class ExampleClass
    {
        public string Name { get; set; } = "";
        public SecretHolder? Secret { get; set; }
    }

    class SecretHolder
    {
        public string Value { get; set; } = "";
    }

    class IgnorePropertiesWithType
    {
        private List<Type> _ignoredTypes = new List<Type>();

        public void IgnorePropertyWithType(Type type)
        {
            _ignoredTypes.Add(type);
        }

        public void ModifyTypeInfo(JsonTypeInfo ti)
        {
            if (ti.Kind != JsonTypeInfoKind.Object)
                return;

            JsonPropertyInfo[] props = ti.Properties.Where((pi) => !_ignoredTypes.Contains(pi.PropertyType)).ToArray();
            ti.Properties.Clear();

            foreach (var pi in props)
            {
                ti.Properties.Add(pi);
            }
        }
    }

    public class IgnoreTypeExample
    {
        public static void RunIt()
        {
            var modifier = new IgnorePropertiesWithType();
            modifier.IgnorePropertyWithType(typeof(SecretHolder));

            JsonSerializerOptions options = new()
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                {
                    Modifiers = { modifier.ModifyTypeInfo }
                }
            };

            ExampleClass obj = new()
            {
                Name = "Password",
                Secret = new SecretHolder() { Value = "MySecret" }
            };

            string output = JsonSerializer.Serialize(obj, options);
            Console.WriteLine(output);
            // {"Name":"Password"}
        }
    }
}
