using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Serialization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class JsonIncludePrivateFieldsAttribute : Attribute { }

    [JsonIncludePrivateFields]
    public class Human
    {
        private string _name;
        private int _age;

        public Human()
        {
            // This constructor should be used only by deserializers.
            _name = null!;
            _age = 0;
        }

        public static Human Create(string name, int age)
        {
            Human h = new()
            {
                _name = name,
                _age = age
            };

            return h;
        }

        [JsonIgnore]
        public string Name
        {
            get => _name;
            set => throw new NotSupportedException();
        }

        [JsonIgnore]
        public int Age
        {
            get => _age;
            set => throw new NotSupportedException();
        }
    }

    public class PrivateFieldsExample
    {
        static void AddPrivateFieldsModifier(JsonTypeInfo jsonTypeInfo)
        {
            if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
                return;

            if (!jsonTypeInfo.Type.IsDefined(typeof(JsonIncludePrivateFieldsAttribute), inherit: false))
                return;

            foreach (FieldInfo field in jsonTypeInfo.Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                JsonPropertyInfo jsonPropertyInfo = jsonTypeInfo.CreateJsonPropertyInfo(field.FieldType, field.Name);
                jsonPropertyInfo.Get = field.GetValue;
                jsonPropertyInfo.Set = field.SetValue;

                jsonTypeInfo.Properties.Add(jsonPropertyInfo);
            }
        }

        public static void RunIt()
        {
            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { AddPrivateFieldsModifier }
                }
            };

            var human = Human.Create("Julius", 37);
            string json = JsonSerializer.Serialize(human, options);
            Console.WriteLine(json);
            // {"_name":"Julius","_age":37}

            Human deserializedHuman = JsonSerializer.Deserialize<Human>(json, options)!;
            Console.WriteLine($"[Name={deserializedHuman.Name}; Age={deserializedHuman.Age}]");
            // [Name=Julius; Age=37]
        }
    }
}
