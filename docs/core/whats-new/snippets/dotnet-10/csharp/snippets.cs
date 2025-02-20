using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class Snippets
{
    public static void NumericOrdering()
    {
        #region snippet1
        StringComparer numericStringComparer = StringComparer.Create(CultureInfo.CurrentCulture, CompareOptions.NumericOrdering);

        Console.WriteLine(numericStringComparer.Equals("02", "2"));
        // Output: True

        foreach (string os in new[] { "Windows 8", "Windows 10", "Windows 11" }.Order(numericStringComparer))
        {
            Console.WriteLine(os);
        }

        // Output:
        // Windows 8
        // Windows 10
        // Windows 11

        HashSet<string> set = new HashSet<string>(numericStringComparer) { "007" };
        Console.WriteLine(set.Contains("7"));
        // Output: True 
        #endregion
    }

    public static void IncrementValue(OrderedDictionary<string, int> orderedDictionary, string key)
    {
        #region snippet2
        // Try to add a new key with value 1.
        if (!orderedDictionary.TryAdd(key, 1, out int index))
        {
            // Key was present, so increment the existing value instead.
            int value = orderedDictionary.GetAt(index).Value;
            orderedDictionary.SetAt(index, value + 1);
        }
        #endregion
    }
}

public partial class SomeClass
{
    #region snippet3
    public static void MakeSelfRef()
    {
        SelfReference selfRef = new SelfReference();
        selfRef.Me = selfRef;

        Console.WriteLine(JsonSerializer.Serialize(selfRef, ContextWithPreserveReference.Default.SelfReference));
        // Output: {"$id":"1","Me":{"$ref":"1"}}
    }

    [JsonSourceGenerationOptions(ReferenceHandler = JsonKnownReferenceHandler.Preserve)]
    [JsonSerializable(typeof(SelfReference))]
    internal partial class ContextWithPreserveReference : JsonSerializerContext
    {
    }

    internal class SelfReference
    {
        public SelfReference Me { get; set; } = null!;
    }
    #endregion
}
