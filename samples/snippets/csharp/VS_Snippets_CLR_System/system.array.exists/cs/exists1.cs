// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String[] names = { "Adam", "Adel", "Bridgette", "Carla",
                         "Charles", "Daniel", "Elaine", "Frances",
                         "George", "Gillian", "Henry", "Irving",
                         "James", "Janae", "Lawrence", "Miguel",
                         "Nicole", "Oliver", "Paula", "Robert",
                         "Stephen", "Thomas", "Vanessa",
                         "Veronica", "Wilberforce" };
      Char[] charsToFind = { 'A', 'K', 'W', 'Z' };

      foreach (var charToFind in charsToFind)
         Console.WriteLine("One or more names begin with '{0}': {1}",
                           charToFind,
                           Array.Exists(names, (new StringSearcher(charToFind)).StartsWith));
   }
}

public class StringSearcher
{
   Char firstChar;

   public StringSearcher(Char firstChar)
   {
      this.firstChar = Char.ToUpper(firstChar);
   }

   public bool StartsWith(String s)
   {
      if (String.IsNullOrEmpty(s)) return false;

      if(s.Substring(0, 1).ToUpper() == firstChar.ToString())
         return true;
      else
         return false;
   }
}
// The example displays the following output:
//       One or more names begin with 'A': True
//       One or more names begin with 'K': False
//       One or more names begin with 'W': True
//       One or more names begin with 'Z': False
// </Snippet1>
