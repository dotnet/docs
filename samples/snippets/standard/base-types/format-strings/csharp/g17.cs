using System;

public class Example
{
   public static void Main()
   {
      // <SnippetGeneralFormatSpecifier>
      double original = 0.84551240822557006;
      var rSpecifier = original.ToString("R");
      var g17Specifier = original.ToString("G17");

      var rValue = Double.Parse(rSpecifier);
      var g17Value = Double.Parse(g17Specifier);

      Console.WriteLine($"{original:G17} = {rSpecifier} (R): {original.Equals(rValue)}");
      Console.WriteLine($"{original:G17} = {g17Specifier} (G17): {original.Equals(g17Value)}");
      // The example displays the following output:
      //     0.84551240822557006 = 0.84551240822557: False
      //     0.84551240822557006 = 0.84551240822557006: True
      // </SnippetGeneralFormatSpecifier>
   }
}
// The example displays the following output:
//     0.84551240822557006 = 0.84551240822557: False
//     0.84551240822557006 = 0.84551240822557006: True
