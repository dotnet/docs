// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      String title = "The House of the Seven Gables";
      String searchString = "the";
      StringComparison comparison = StringComparison.InvariantCulture;
      Console.WriteLine("'{0}':", title);
      Console.WriteLine("   Starts with '{0}' ({1:G} comparison): {2}",
                        searchString, comparison,
                        title.StartsWith(searchString, comparison));

      comparison = StringComparison.InvariantCultureIgnoreCase;
      Console.WriteLine("   Starts with '{0}' ({1:G} comparison): {2}",
                        searchString, comparison,
                        title.StartsWith(searchString, comparison));
   }
}
// The example displays the following output:
//       'The House of the Seven Gables':
//          Starts with 'the' (InvariantCulture comparison): False
//          Starts with 'the' (InvariantCultureIgnoreCase comparison): True
// </Snippet2>
