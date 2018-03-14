using System;
using System.Reflection;

class PropertyInfo_GetValue
{
   private TextBlock b;

   public PropertyInfo_GetValue()
   {
      this.b = new TextBlock();
   }

   public static void Main()
   {
      PropertyInfo_GetValue p = new PropertyInfo_GetValue();
      p.Example();
      Console.WriteLine(p.Show());
   }

   // <Snippet1>
   public void Example()
   {
     string test = "abcdefghijklmnopqrstuvwxyz";

     // Get a PropertyInfo object.
     TypeInfo ti = typeof(string).GetTypeInfo();
     PropertyInfo pinfo = ti.GetDeclaredProperty("Chars");

     // Show the seventh letter ('g')
     object[] indexArgs = { 6 };
     object value = pinfo.GetValue(test, indexArgs);
     b.Text += String.Format("Character at position {0}: {1}\n", indexArgs[0], value);

     // Show the complete string.
     b.Text += "\nThe complete string:\n";
     for (int x = 0; x < test.Length; x++)
     {
         b.Text += pinfo.GetValue(test, new Object[] {x}).ToString() + " ";
     }
   }
   // The example displays the following output:
   //       Character at position 6: g
   //       
   //       The complete string:
   //       a b c d e f g h i j k l m n o p q r s t u v w x y z
   // </Snippet1>   
   
   public string Show()
   {
      return b.Text;
   }
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


