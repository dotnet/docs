using System;

class NullableExample
{
  static void Main()
  {
      int? num = null;

      // Is the HasValue property true?
      if (num.HasValue)
      {
          Console.WriteLine("num = " + num.Value);
      }
      else
      {
          Console.WriteLine("num = Null");
      }

      // y is set to zero
      int y = num.GetValueOrDefault();

      // num.Value throws an InvalidOperationException if num.HasValue is false
      try
      {
          y = num.Value;
      }
      catch (InvalidOperationException e)
      {
         Console.WriteLine(e.Message);
      }
   }
}
// The example displays the following output:
//       num = Null
//       Nullable object must have a value.
