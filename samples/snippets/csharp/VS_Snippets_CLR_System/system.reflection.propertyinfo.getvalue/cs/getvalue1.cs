// <Snippet1>
using System;
using System.Reflection;

public class Planet
{
   private String planetName;
   private Double distanceFromEarth;
   
   public Planet(String name, Double distance)
   {
      planetName = name;
      distanceFromEarth = distance;
   } 

   public String Name
   { get { return planetName; } }
   
   public Double Distance 
   { get { return distanceFromEarth; }
     set { distanceFromEarth = value; } }
}

public class Example
{
   public static void Main()
   {
      Planet jupiter = new Planet("Jupiter", 3.65e08);
      GetPropertyValues(jupiter);
   }
   
   private static void GetPropertyValues(Object obj)
   {
      Type t = obj.GetType();
      Console.WriteLine("Type is: {0}", t.Name);
      PropertyInfo[] props = t.GetProperties();
      Console.WriteLine("Properties (N = {0}):", 
                        props.Length);
      foreach (var prop in props)
         if (prop.GetIndexParameters().Length == 0)
            Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                              prop.PropertyType.Name,
                              prop.GetValue(obj));
         else
            Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                              prop.PropertyType.Name);
                                        
   }
}
// The example displays the following output:
//       Type is: Planet
//       Properties (N = 2):
//          Name (String): Jupiter
//          Distance (Double): 365000000
// </Snippet1>
