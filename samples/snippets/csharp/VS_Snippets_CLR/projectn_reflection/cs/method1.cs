using System;
using System.Globalization;
using System.Reflection;

namespace ContosoApplication
{
    // <Snippet8>
    public sealed class Example
    {
       public void Execute()
       {
          TextBlock outputBlock = MainPage.outputBlock;

          string testString = "A Test String";
          outputBlock.Text += String.Format("'{0}'\n",
                               Stringify.ConvertToString(new object[] { testString, 0, 0 }));

          CultureInfo fr = new CultureInfo("fr-FR");
          int s = 1603;
          int b = 2;
          outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { s, b }));

           outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { s, "C2", fr }));

         string f = "D";
          outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { s, f }));

          byte byt = 214;
          b = 16;

          outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { byt, b }));

          outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { byt, "D" }));

          double pi = Math.PI;
          outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { pi, "F7" }));

          float fl = 1.603e-22f;
          outputBlock.Text += String.Format("'{0}'\n",
                              Stringify.ConvertToString(new object[] { fl, "e2" }));

           f = "C";
          long lng = Int64.MaxValue;
          outputBlock.Text += String.Format("'{0}'\n", 
                               Stringify.ConvertToString(new object[] { lng, f }));

          outputBlock.Text += String.Format("'{0}'\n", 
                               Stringify.ConvertToString(new object[] { lng, "N1", fr }));

          Person p = new Person();
          outputBlock.Text += String.Format("'{0}'\n", 
                               Stringify.ConvertToString(new object[] { p }));

          DateTime date = DateTime.Now;
          outputBlock.Text += String.Format("'{0}'\n", 
                               Stringify.ConvertToString(new object[] { date, "F" }));

          outputBlock.Text += String.Format("'{0}'\n", 
                               Stringify.ConvertToString(new object[] { date, "F", fr }));

        }
    }
    // </Snippet8>

    public class Person { }

    // <Snippet7>
    public class Stringify
    {
       public static string ConvertToString(Object[] obj)
       {
          if (obj == null)
             throw new NullReferenceException("The obj parameter cannot be null.");

          if (obj.Length == 0) return String.Empty;

          if (obj[0].GetType() == typeof(String))
             return obj[0] as string;

          if (obj.Length == 1) return obj[0].ToString();

          if (obj.Length > 3)
             throw new ArgumentOutOfRangeException("The array can have from zero to three elements.");

          string retval = "";

          // Parameters indicate either a format specifier, numeric base, or format provider, 
          // or a format specifier with an IFormatProvider.

          // A string as the first parameter indicates a format specifier.
          if (obj[1].GetType() == typeof(String)) {
             Type t = obj[0].GetType();
             if (obj.Length == 2)
             {
                MethodInfo m = t.GetRuntimeMethod("ToString", new Type[] { typeof(String) });
                retval = m.Invoke(obj[0], new object[] { obj[1] }).ToString();
             }
             else
             {
                 MethodInfo m = t.GetRuntimeMethod("ToString", new Type[] { typeof(String), obj[2].GetType() });
                 retval = m.Invoke(obj[0], new object[] { obj[1], obj[2] }).ToString();
             }
          }   
          else if (obj[1] is IFormatProvider)
          {
              Type t = obj[0].GetType();
              MethodInfo m = t.GetRuntimeMethod("ToString", new Type[] { obj[1].GetType() } );
              retval = m.Invoke(obj[0], new object[] { obj[1] }).ToString();
          }
          // The second parameter is a base, so call Convert.ToString(number, int).
          else {
              Type t = typeof(Convert);
              MethodInfo m = t.GetRuntimeMethod("ToString", new Type[] { obj[0].GetType(), obj[1].GetType() } );
              retval = m.Invoke(null, obj).ToString();
          }
          return retval;
       }
    }
    // </Snippet7>

public class Page
{ }

public class MainPage : Page
{
   static MainPage()
   {
      outputBlock = new TextBlock();
      outputBlock.Text = "";
   }

   internal static TextBlock outputBlock;
}

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
