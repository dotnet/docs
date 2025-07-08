// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { "a tale of two cities", "gROWL to the rescue",
                          "inside the US government", "sports and MLB baseball",
                          "The Return of Sherlock Holmes", "UNICEF and children"};

      TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
      foreach (var value in values)
         Console.WriteLine($"{value} --> {ti.ToTitleCase(value)}");
   }
}
// The example displays the following output:
//    a tale of two cities --> A Tale Of Two Cities
//    gROWL to the rescue --> Growl To The Rescue
//    inside the US government --> Inside The US Government
//    sports and MLB baseball --> Sports And MLB Baseball
//    The Return of Sherlock Holmes --> The Return Of Sherlock Holmes
//    UNICEF and children --> UNICEF And Children
// </Snippet1>
