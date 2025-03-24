// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      // Show hash code in current domain.
      DisplayString display = new DisplayString();
      display.ShowStringHashCode();

      // Create a new app domain and show string hash code.
      AppDomain domain = AppDomain.CreateDomain("NewDomain");
      var display2 = (DisplayString) domain.CreateInstanceAndUnwrap(typeof(Example).Assembly.FullName,
                                                          "DisplayString");
      display2.ShowStringHashCode();
   }
}

public class DisplayString : MarshalByRefObject
{
   private String s = "This is a string.";

   public override bool Equals(Object obj)
   {
      String s2 = obj as String;
      if (s2 == null)
         return false;
      else
         return s == s2;
   }

   public bool Equals(String str)
   {
      return s == str;
   }

   public override int GetHashCode()
   {
      return s.GetHashCode();
   }

   public override String ToString()
   {
      return s;
   }

   public void ShowStringHashCode()
   {
      Console.WriteLine($"String '{s}' in domain '{AppDomain.CurrentDomain.FriendlyName}': {s.GetHashCode():X8}");
   }
}
// </Snippet2>
