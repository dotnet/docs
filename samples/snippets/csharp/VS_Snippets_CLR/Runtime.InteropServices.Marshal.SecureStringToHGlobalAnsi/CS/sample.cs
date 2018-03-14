//<snippet1>
using System;
using System.Runtime.InteropServices;
using System.Security;

class Example
{
    static void Main()
    {
        IntPtr unmanagedRef = IntPtr.Zero;

        // Ask the user for a password.
        Console.Write("Please enter your password: ");
        SecureString passWord = GetPassword();

        Console.WriteLine("Copying and decrypting the string to unmanaged memory...");
        // Copy the Secure string to unmanaged memory (and decrypt it).
        unmanagedRef = Marshal.SecureStringToGlobalAllocAnsi(passWord);
        passWord.Dispose();
        
        if (unmanagedRef != IntPtr.Zero) {
            Console.WriteLine("Zeroing out unmanaged memory...");
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedRef);
        }
        Console.WriteLine("Done.");
    }

    public static SecureString GetPassword()
    {
        SecureString password = new SecureString();

        // get the first character of the password
        ConsoleKeyInfo nextKey = Console.ReadKey(true);

        while (nextKey.Key != ConsoleKey.Enter) {
            if (nextKey.Key == ConsoleKey.Backspace) {
                if (password.Length > 0) {
                    password.RemoveAt(password.Length - 1);

                    // erase the last * as well
                    Console.Write(nextKey.KeyChar);
                    Console.Write(" ");
                    Console.Write(nextKey.KeyChar);
                }
            }
            else {
                password.AppendChar(nextKey.KeyChar);
                Console.Write("*");
            }

            nextKey = Console.ReadKey(true);
        }
        Console.WriteLine();

        // lock the password down
        password.MakeReadOnly();
        return password;
    }
}
// The example displays output like the following:
//       Please enter your password: ********
//       Copying and decrypting the string to unmanaged memory...
//       Zeroing out unmanaged memory...
//       Done.
//</snippet1>

// 86 lines
