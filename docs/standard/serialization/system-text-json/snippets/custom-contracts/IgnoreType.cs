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
        private readonly Type[] _ignoredTypes;

        public IgnorePropertiesWithType(params Type[] ignoredTypes)
            => _ignoredTypes = ignoredTypes;

        public void ModifyTypeInfo(JsonTypeInfo ti)
        {
            if (ti.Kind != JsonTypeInfoKind.Object)
                return;

            ti.Properties.RemoveAll(prop => _ignoredTypes.Contains(prop.PropertyType));
        }
    }

    public class IgnoreTypeExample
    {
        public static void RunIt()
        {
            var modifier = new IgnorePropertiesWithType(typeof(SecretHolder));

            JsonSerializerOptions options = new()
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { modifier.ModifyTypeInfo }
                }
            };

            ExampleClass obj = new()
            {
                Name = "Password",
                Secret = new SecretHolder { Value = "MySecret" }
            };

            string output = JsonSerializer.Serialize(obj, options);
            Console.WriteLine(output);
            // {"Name":"Password"}
        }
    }

    public static class ListHelpers
    {
        // IList<T> implementation of List<T>.RemoveAll method.
        public static void RemoveAll<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    list.RemoveAt(i--);
                }
            }
        }
    }
}
