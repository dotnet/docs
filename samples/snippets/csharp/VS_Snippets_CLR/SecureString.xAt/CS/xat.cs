//<snippet1>
using System;
using System.Security;

class Example
{
    public static void Main() 
    {
       string msg = "The curent length of the SecureString object: {0}\n";
       Console.WriteLine("1) Instantiate the SecureString object.");
       SecureString ss = new SecureString();
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("2) Append 'a' to the value.");
       ss.AppendChar('a');
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("3) Append 'X' to the value.");
       ss.AppendChar('X');
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("4) Append 'c' to the value.");
       ss.AppendChar('c');
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("5) Insert 'd' at the end of the value.");
       ss.InsertAt(ss.Length, 'd');
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("6) Remove the last character ('d') from the value.");
       ss.RemoveAt(3);
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("7) Set the second character of the value to 'b'.");
       ss.SetAt(1, 'b');
       Console.WriteLine(msg, ss.Length);

       Console.WriteLine("8) Delete the value of the SecureString object:");
       ss.Clear();
       Console.WriteLine(msg, ss.Length);
       
       ss.Dispose();
    }
}
// The example displays the following output:
//       1) Instantiate the SecureString object.
//       The curent length of the SecureString object: 0
//
//       2) Append 'a' to the value.
//       The curent length of the SecureString object: 1
//
//       3) Append 'X' to the value.
//       The curent length of the SecureString object: 2
//
//       4) Append 'c' to the value.
//       The curent length of the SecureString object: 3
//
//       5) Insert 'd' at the end of the value.
//       The curent length of the SecureString object: 4
//
//       6) Remove the last character ('d') from the value.
//       The curent length of the SecureString object: 3
//
//       7) Set the second character of the value to 'b'.
//       The curent length of the SecureString object: 3
//
//       8) Delete the value of the SecureString object:
//       The curent length of the SecureString object: 0
//</snippet1>