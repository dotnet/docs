//<snippet1>
using System;

class Sample 
{
    // Define the "titleAuthor" table of the Microsoft "pubs" database. 
    public struct titleAuthor 
    {
      // Author ID; format ###-##-####
      public string au_id;
      // Title ID; format AA####
      public string title_id;
      // Author ORD is nullable.
      public short? au_ord;
      // Royalty Percent is nullable.
      public int? royaltyper;
    }

    public static void Main() 
    {
      // Declare and initialize the titleAuthor array.
      titleAuthor[] ta = new titleAuthor[3];
      ta[0].au_id = "712-32-1176";
      ta[0].title_id = "PS3333";
      ta[0].au_ord = 1;
      ta[0].royaltyper = 100;
    
      ta[1].au_id = "213-46-8915";
      ta[1].title_id = "BU1032";
      ta[1].au_ord = null;
      ta[1].royaltyper = null;
  
      ta[2].au_id = "672-71-3249";
      ta[2].title_id = "TC7777";
      ta[2].au_ord = null;
      ta[2].royaltyper = 40;
  
      // Display the values of the titleAuthor array elements, and 
      // display a legend.
      Display("Title Authors Table", ta);
      Console.WriteLine("Legend:");
      Console.WriteLine("An Author ORD of -1 means no value is defined.");
      Console.WriteLine("A Royalty % of 0 means no value is defined.");
    }

    // Display the values of the titleAuthor array elements.
    public static void Display(string dspTitle, 
                               titleAuthor[] dspAllTitleAuthors)
    {
      Console.WriteLine("*** {0} ***", dspTitle);
      foreach (titleAuthor dspTA in dspAllTitleAuthors) {
         Console.WriteLine("Author ID ... {0}", dspTA.au_id);
         Console.WriteLine("Title ID .... {0}", dspTA.title_id);
         Console.WriteLine("Author ORD .. {0}", dspTA.au_ord ?? -1);
         Console.WriteLine("Royalty % ... {0}", dspTA.royaltyper ?? 0);
         Console.WriteLine();       
      }
    }
}
// The example displays the following output:
//     *** Title Authors Table ***
//     Author ID ... 712-32-1176
//     Title ID .... PS3333
//     Author ORD .. 1
//     Royalty % ... 100
//     
//     Author ID ... 213-46-8915
//     Title ID .... BU1032
//     Author ORD .. -1
//     Royalty % ... 0
//     
//     Author ID ... 672-71-3249
//     Title ID .... TC7777
//     Author ORD .. -1
//     Royalty % ... 40
//     
//     Legend:
//     An Author ORD of -1 means no value is defined.
//     A Royalty % of 0 means no value is defined.
//</snippet1>