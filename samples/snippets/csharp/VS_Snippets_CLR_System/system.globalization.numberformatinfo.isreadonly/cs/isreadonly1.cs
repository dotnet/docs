// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;
      Console.WriteLine("Read-Only: {0}\n", nfi.IsReadOnly);

      NumberFormatInfo nfiw = (NumberFormatInfo) nfi.Clone();
      Console.WriteLine("Read-Only: {0}", nfiw.IsReadOnly);
   }
}
// The example displays the following output:
//       Read-Only: True
//       
//       Read-Only: False
// </Snippet1>