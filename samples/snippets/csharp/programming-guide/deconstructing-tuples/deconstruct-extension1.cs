using System;
using System.Collections.Generic;
using System.Reflection;

public static class ReflectionExtensions
{
   public static void Deconstruct(this PropertyInfo p, out string access, 
                                  out string instOrStatic, out Type propType,
                                  out string index)
   {
      bool readOnly = ! p.CanWrite;
      // Determine the property's accessibility.
      MethodInfo getter = p.GetGetMethod();
      MethodInfo setter = null;
      if (! readOnly)
         setter = p.GetSetMethod();

      if (getter.IsPublic && (readOnly || setter.IsPublic))
         access = "public ";
      else if (getter.IsPrivate && (readOnly || setter.IsPrivate))
         access = "private ";
      else if (getter.IsFamily && (readOnly || setter.IsFamily))
         access = "protected ";
      else if (getter.IsAssembly && (readOnly || setter.IsAssembly))
         access = "internal ";
      else if (getter.IsFamilyOrAssembly && (readOnly || setter.IsFamilyOrAssembly))   
         access = "protected internal ";
      else
         access = "";
      
      // Is the property instance or static?
      instOrStatic = getter.IsStatic ? "static " : "";
      
      // Get the property type.
      propType = p.PropertyType;
      
      // Are the property indexed?
      var parameters = p.GetIndexParameters();
      index = "";
      if (parameters.Length > 0) {
         index += "[";
         for (int ctr = 0; ctr < parameters.Length; ctr++) {
            index += parameters[ctr].ParameterType.Name;
            if (ctr != parameters.Length - 1)
               index += ", ";   
         }
         index += "]";   
      }
   }   
}

public class Example
{
   public static void Main()
   {
      Type dateType = typeof(DateTime);
      PropertyInfo prop = dateType.GetProperty("Now");
      var (access, scope, retval, indexes) = prop;
      Console.WriteLine($"{access}{scope}{retval} {dateType.Name}.{prop.Name}{indexes}");
      
      Type listType = typeof(List<>);
      prop = listType.GetProperty("Item");
      (access, scope, retval, indexes) = prop;
      Console.WriteLine($"{access}{scope}{retval} {dateType.Name}.{prop.Name}{indexes}");
   }
}
// The example displays the following output:
//       public static System.DateTime DateTime.Now
//       public T DateTime.Item[Int32]


