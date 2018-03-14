// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[,] strings = { {"ABCdef", "abc" },                    
                            {"ABCdef", "abc" },  
                            {"œil","oe" },
                            { "læring}", "lae" } };
      for (int ctr1 = strings.GetLowerBound(0); ctr1 <= strings.GetUpperBound(0); ctr1++)
      {
            foreach (string cmpName in Enum.GetNames(typeof(StringComparison)))
            { 
               StringComparison strCmp = (StringComparison) Enum.Parse(typeof(StringComparison), 
                                                      cmpName);
               string instance = strings[ctr1, 0];
               string value = strings[ctr1, 1];
               Console.WriteLine("{0} starts with {1}: {2} ({3} comparison)", 
                                 instance, value, 
                                 instance.StartsWith(value, strCmp), 
                                 strCmp); 
            }
            Console.WriteLine();   
      }   
   }
}
// The example displays the following output:
//       ABCdef starts with abc: False (CurrentCulture comparison)
//       ABCdef starts with abc: True (CurrentCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (InvariantCulture comparison)
//       ABCdef starts with abc: True (InvariantCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (Ordinal comparison)
//       ABCdef starts with abc: True (OrdinalIgnoreCase comparison)
//       
//       ABCdef starts with abc: False (CurrentCulture comparison)
//       ABCdef starts with abc: True (CurrentCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (InvariantCulture comparison)
//       ABCdef starts with abc: True (InvariantCultureIgnoreCase comparison)
//       ABCdef starts with abc: False (Ordinal comparison)
//       ABCdef starts with abc: True (OrdinalIgnoreCase comparison)
//       
//       œil starts with oe: True (CurrentCulture comparison)
//       œil starts with oe: True (CurrentCultureIgnoreCase comparison)
//       œil starts with oe: True (InvariantCulture comparison)
//       œil starts with oe: True (InvariantCultureIgnoreCase comparison)
//       œil starts with oe: False (Ordinal comparison)
//       œil starts with oe: False (OrdinalIgnoreCase comparison)
//       
//       læring} starts with lae: True (CurrentCulture comparison)
//       læring} starts with lae: True (CurrentCultureIgnoreCase comparison)
//       læring} starts with lae: True (InvariantCulture comparison)
//       læring} starts with lae: True (InvariantCultureIgnoreCase comparison)
//       læring} starts with lae: False (Ordinal comparison)
//       læring} starts with lae: False (OrdinalIgnoreCase comparison)
// </Snippet1>