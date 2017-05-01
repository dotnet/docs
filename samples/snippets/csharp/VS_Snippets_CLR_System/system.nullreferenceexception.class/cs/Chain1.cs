// <Snippet6>
using System;

public class Example
{
   public static void Main()
   {
      var pages = new Pages();
      if (! String.IsNullOrEmpty(pages.CurrentPage.Title)) {
         String title = pages.CurrentPage.Title;
         Console.WriteLine("Current title: '{0}'", title);
      }
   }
}

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
// The example displays the following output:
//    Unhandled Exception: 
//       System.NullReferenceException: Object reference not set to an instance of an object.
//       at Example.Main()
// </Snippet6>

