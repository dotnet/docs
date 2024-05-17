using System.Reflection;

namespace SystemTextJsonSamples
{
    public class Utilities
    {
        public static void DisplayPropertyValues(object obj)
        {
            Type objectType = obj.GetType();
            Console.WriteLine($"{objectType.Name} object");
            foreach (PropertyInfo property in objectType.GetProperties())
            {
                if (!property.PropertyType.FullName!.Contains("Collections") &&
                    !property.PropertyType.FullName.Contains("[]"))
                {
                    Console.WriteLine($"{property.Name}: {property.GetGetMethod()!.Invoke(obj, null)}");
                }
                else
                {
                    object? values = property.GetGetMethod()!.Invoke(obj, null);
                    if (values is System.Collections.IDictionary dictionary)
                    {
                        foreach (object? kvp in dictionary)
                        {
                            Console.WriteLine($"    {kvp}");
                        }
                    }
                    else if (values is System.Collections.ICollection collection)
                    {
                        foreach (object? value in collection)
                        {
                            Console.WriteLine($"    {value}");
                        }
                    } 
                    else if (values is System.Collections.IList list)
                    {
                        foreach (object? value in list)
                        {
                            Console.WriteLine($"    {value}");
                        }
                    }
                }
            }
        }
    }
}
