using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml.Controls;

namespace GenericBrowsing
{
   public class Example
   {
      internal static TextBlock b;

// <Snippet3>
      public static void GetReflectionInfo()
      {
         Type t = typeof(List<>);
         b.Text += String.Format("Type information for {0}\n", t);

         // Get fields.
         b.Text += "\nFields:\n";

         var fields = t.GetTypeInfo().DeclaredFields;
         int nFields = 0;
         foreach (var field in fields)
         {
            b.Text += String.Format("   {0} ({1})", field.Name, field.FieldType.Name);
            nFields++;
         }
         if (nFields == 0) b.Text += "   None\n";

         // Get properties.
         b.Text += "\nProperties:\n";
         var props = t.GetTypeInfo().DeclaredProperties;
         int nProps = 0;
         foreach (var prop in props)
         {
            b.Text += String.Format("   {0} ({1})\n", prop.Name, prop.PropertyType.Name);
            nProps++;
         }
         if (nProps == 0) b.Text += "   None\n"; 

         // Get methods.
         b.Text += "\nMethods:\n";
         var methods = t.GetTypeInfo().DeclaredMethods;
         int nMethods = 0;
         foreach (var method in methods)
         {
            if (method.IsSpecialName) continue;
            b.Text += String.Format("   {0}({1}) ({2})\n", method.Name, 
                                    GetSignature(method), method.ReturnType.Name);
            nMethods++;
         }
         if (nMethods == 0) b.Text += "   None\n";
      }

      private static string GetSignature(MethodInfo m)
      {
         string signature = null;
         var parameters = m.GetParameters();
         for (int ctr = 0; ctr < parameters.Length; ctr++)
         {
            signature += String.Format("{0} {1}", parameters[ctr].ParameterType.Name,
                                        parameters[ctr].Name);
            if (ctr < parameters.Length - 1) signature += ", ";
         }
         return signature;
      }
// </Snippet3>
   }
}
namespace Windows.UI.Xaml.Controls
{
internal class TextBlock
{
   private String s;
   
   public String Text 
   {
      get { return s; }
      set { s = value; }
   }
}
}

public class App 
{
   public static void Main()
   {
      TextBlock t = new TextBlock();
      GenericBrowsing.Example.b = t;
      GenericBrowsing.Example.GetReflectionInfo();
   }
}
