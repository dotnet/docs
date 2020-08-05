using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemTextJsonSamples
{
    public class Utilities
    {
        public static void DisplayPropertyValues(object o)
        {
            var objectType = o.GetType();
            Console.WriteLine($"{objectType.Name} object");
            var properties = objectType.GetProperties();
            foreach (var property in properties)
            {
                if (!property.PropertyType.FullName.Contains("Collections") &&
                    !property.PropertyType.FullName.Contains("[]"))
                {
                    Console.WriteLine($"{property.Name}: {property.GetGetMethod().Invoke(o, null)}");
                }
            }
        }
    }
}
