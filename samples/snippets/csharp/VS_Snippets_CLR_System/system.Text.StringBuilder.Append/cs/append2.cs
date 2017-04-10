using System;

public class Example
{
   public static void Main()
   {
      AppendBool();
      Console.WriteLine("-----");
      AppendByte();
      Console.WriteLine("-----");
      AppendChar();
      Console.WriteLine("-----");
      AppendMultipleChars();
      Console.WriteLine("-----");
      AppendCharArray();
      Console.WriteLine("-----");
      AppendPartialCharArray();
      Console.WriteLine("-----");
      AppendDecimal();
      Console.WriteLine("-----");
      AppendDouble();
      Console.WriteLine("-----");
   }

   private static void AppendBool()
   { 
      // <Snippet2>
      bool flag = false;
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append("The value of the flag is ").Append(flag).Append(".");
      Console.WriteLine(sb.ToString());
      // The example displays the following output:
      //       The value of the flag is False.
      // </Snippet2>
   }   
   
   private static void AppendByte()
   {
      // <Snippet3>
      Byte[] bytes = { 16, 132, 27, 253 };
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach (var value in bytes)
         sb.Append(value).Append(" ");         

      Console.WriteLine("The byte array: {0}", sb.ToString());
      // The example displays the following output:
      //         The byte array: 16 132 27 253      
      // </Snippet3>
   }

   private static void AppendChar()
   {
      // <Snippet4>
      string str = "Characters in a string.";
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach (var ch in str)
         sb.Append(" '").Append(ch).Append("' ");

      Console.WriteLine("Characters in the string:");
      Console.WriteLine("  {0}", sb);
      // The example displays the following output:
      //    Characters in the string:
      //       'C'  'h'  'a'  'r'  'a'  'c'  't'  'e'  'r'  's'  ' '  'i'  'n'  ' '  'a'  ' '  's'  't' 'r'  'i'  'n'  'g'  '.'      
      // </Snippet4>    
   }

   private static void AppendMultipleChars()
   {
      // <Snippet5> 
      decimal value = 1346.19m;
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append('*', 5).AppendFormat("{0:C2}", value).Append('*', 5);
      Console.WriteLine(sb);
      // The example displays the following output:
      //       *****$1,346.19*****
      // </Snippet5>
   }

   private static void AppendCharArray()
   {
      // <Snippet6>
      char[] chars = { 'a', 'e', 'i', 'o', 'u' };
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append("The characters in the array: ").Append(chars);
      Console.WriteLine(sb);
      // The example displays the following output:
      //      The characters in the array: aeiou
      // </Snippet6>
   }

   private static void AppendPartialCharArray()
   {
      // <Snippet7>
      char[] chars = { 'a', 'b', 'c', 'd', 'e'};
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      int startPosition = Array.IndexOf(chars, 'a');
      int endPosition = Array.IndexOf(chars, 'c');
      if (startPosition >= 0 && endPosition >= 0) {
         sb.Append("The array from positions ").Append(startPosition).
                   Append(" to ").Append(endPosition).Append(" contains ").
                   Append(chars, startPosition, endPosition + 1).Append(".");
         Console.WriteLine(sb);
      }             
      // The example displays the following output:
      //       The array from positions 0 to 2 contains abc.
      // </Snippet7>
   }

   private static void AppendDecimal()
   {
      // <Snippet8> 
      decimal value = 1346.19m;
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append('*', 5).Append(value).Append('*', 5);
      Console.WriteLine(sb);
      // The example displays the following output:
      //       *****1346.19*****
      // </Snippet8>
   }

   private static void AppendDouble()
   {
      // <Snippet9> 
      double value = 1034769.47;
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append('*', 5).Append(value).Append('*', 5);
      Console.WriteLine(sb);
      // The example displays the following output:
      //       *****1034769.47*****
      // </Snippet9>
   }
}
