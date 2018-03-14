//<snippet1>
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;

class Example
{
     // Define the Windows LogonUser and CloseHandle functions.
     [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
     internal static extern bool LogonUser(String username, String domain, IntPtr password,
             int logonType, int logonProvider, ref IntPtr token);

     [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
     public extern static bool CloseHandle(IntPtr handle);

     // Define the required LogonUser enumerations.
     const int LOGON32_PROVIDER_DEFAULT = 0;
     const int LOGON32_LOGON_INTERACTIVE = 2;

     static void Main()
     {
          // Display the current user before impersonation.
          Console.WriteLine("Before impersonation: {0}",
                            WindowsIdentity.GetCurrent().Name);

          // Ask the user for a network domain.
          Console.Write("Please enter your domain: ");
          string domain = Console.ReadLine();

          // Ask the user for a user name.
          Console.Write("Please enter your user name: ");
          string username = Console.ReadLine();

          // Ask the user for a password.
          Console.Write("Please enter your password: ");
          SecureString passWord = GetPassword();

          // Impersonate the account provided by the user.
          try {
             WindowsImpersonationContext userContext =
                           ImpersonateUser(passWord, username, domain);
             // Display the current user after impersonation.
             Console.WriteLine("After impersonation: {0}",
                               WindowsIdentity.GetCurrent().Name);
          }
          catch (ArgumentException e) {
             Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
          }
          catch (Win32Exception e) {
             Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
          }
          finally {
             passWord.Dispose();
          }
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

     public static WindowsImpersonationContext ImpersonateUser(SecureString password, string userName, string domainName)
     {
         IntPtr tokenHandle = IntPtr.Zero;
         IntPtr passwordPtr = IntPtr.Zero;
         bool returnValue = false;
         int error = 0;
         
         // Marshal the SecureString to unmanaged memory.
         passwordPtr = Marshal.SecureStringToGlobalAllocUnicode(password);

         // Pass LogonUser the unmanaged (and decrypted) copy of the password.
         returnValue = LogonUser(userName, domainName, passwordPtr,
                                 LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                                 ref tokenHandle);
         if (!returnValue && tokenHandle == IntPtr.Zero)
            error = Marshal.GetLastWin32Error();

         // Perform cleanup whether or not the call succeeded.
         // Zero-out and free the unmanaged string reference.
         Marshal.ZeroFreeGlobalAllocUnicode(passwordPtr);
         // Close the token handle.
         CloseHandle(tokenHandle);

         // Throw an exception if an error occurred.
         if (error != 0) {
             throw new System.ComponentModel.Win32Exception(error);
         }
         // The token that is passed to the following constructor must 
         // be a primary token in order to use it for impersonation.
         WindowsIdentity newId = new WindowsIdentity(tokenHandle);

         return newId.Impersonate();
     }
}
//</snippet1>