// <Snippet1>
using System;

delegate int Searcher(string searchString, int start, int count, 
                         StringComparison type);
                         
public class DelegateExample
{
   public static void Main()
   {
      string title = "The House of the Seven Gables";
      int position = 0;
      Searcher finder = title.IndexOf;
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
// </Snippet1>
