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
            }
        }
    }
}
