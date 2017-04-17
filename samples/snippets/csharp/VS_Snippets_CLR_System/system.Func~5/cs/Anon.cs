// <Snippet3>
using System;

public class DelegateExample
{
   public static void Main()
   {
      string title = "The House of the Seven Gables";
      int position = 0;
      Func<string, int, int, StringComparison, int> finder = 
           delegate(string s, int pos, int chars, StringComparison type) 
           { return title.IndexOf(s, pos, chars, type); };
      do
      {
         int characters = title.Length - position;
         position = finder("the", position, characters, 
                         StringComparison.InvariantCultureIgnoreCase);
         if (position >= 0)
         {
            position++;
            Console.WriteLine("'The' found at position {0} in {1}.", 
                              position, title);
         }
      } while (position > 0);
   }
}
// </Snippet3>
