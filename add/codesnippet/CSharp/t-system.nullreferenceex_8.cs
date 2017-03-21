using System;

public class Example
{
   public static void Main()
   {
      var pages = new Pages();
      Page current = pages.CurrentPage;
      if (current != null) {  
         String title = current.Title;
         Console.WriteLine("Current title: '{0}'", title);
      }
      else {
         Console.WriteLine("There is no page information in the cache.");
      }   
   }
}
// The example displays the following output:
//       There is no page information in the cache.