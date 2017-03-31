// <Snippet7>
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
// </Snippet7>

public class Pages 
{
   Page[] page = new Page[10];
   int ctr = 0;
   
   public Page CurrentPage
   {
      get { return page[ctr]; }
      set {
         // Move all the page objects down to accommodate the new one.
         if (ctr > page.GetUpperBound(0)) {
            for (int ndx = 1; ndx <= page.GetUpperBound(0); ndx++)
               page[ndx - 1] = page[ndx];
         }    
         page[ctr] = value;
         if (ctr < page.GetUpperBound(0))
            ctr++; 
      }
   }
   
   public Page PreviousPage
   {
      get {
         if (ctr == 0) { 
            if (page[0] == null)
               return null;
            else
               return page[0];
         }
         else {
            ctr--;
            return page[ctr + 1];
         }
      }
   }         
}

public class Page
{
   public Uri URL;
   public String Title;
}

