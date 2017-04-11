// <Snippet4>
using System;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace CustAttrs4CS
{

    // Define an enumeration of Win32 unmanaged types
    public enum UnmanagedType
    {
        User,
        GDI,
        Kernel,
        Shell,
        Networking,
        Multimedia
    }

    // Define the Unmanaged attribute.
    public class UnmanagedAttribute : Attribute
    {
        // Storage for the UnmanagedType value.
        protected UnmanagedType thisType;

        // Set the unmanaged type in the constructor.
        public UnmanagedAttribute(UnmanagedType type)
        {
            thisType = type;
        }

        // Define a property to get and set the UnmanagedType value.
        public UnmanagedType Win32Type
        {
            get { return thisType; }
            set { thisType = Win32Type; }
        }
    }

    // Create a class for an imported Win32 unmanaged function.
    public class Win32 {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(int hWnd, String text,
            String caption, uint type);
    }

    public class AClass {
        // Add some attributes to Win32CallMethod.
        [Obsolete("This method is obsolete. Use managed MsgBox instead.")]
        [Unmanaged(UnmanagedType.User)]
        public void Win32CallMethod()
        {
            Win32.MessageBox(0, "This is an unmanaged call.", "Caution!", 0);
        }
    }

    class DemoClass {
        static void Main(string[] args)
            {
            // Get the AClass type to access its metadata.
            Type clsType = typeof(AClass);
            // Get the type information for Win32CallMethod.
            MethodInfo mInfo = clsType.GetMethod("Win32CallMethod");
            if (mInfo != null)
            {
                // Iterate through all the attributes of the method.
                foreach(Attribute attr in
                    Attribute.GetCustomAttributes(mInfo)) {
                    // Check for the Obsolete attribute.
                    if (attr.GetType() == typeof(ObsoleteAttribute))
                    {
                        Console.WriteLine("Method {0} is obsolete. " +
                            "The message is:",
                            mInfo.Name);
                        Console.WriteLine("  \"{0}\"",
                            ((ObsoleteAttribute)attr).Message);
                    }

                    // Check for the Unmanaged attribute.
                    else if (attr.GetType() == typeof(UnmanagedAttribute))
                    {
                        Console.WriteLine(
                            "This method calls unmanaged code.");
                        Console.WriteLine(
                            String.Format("The Unmanaged attribute type is {0}.",
                                          ((UnmanagedAttribute)attr).Win32Type));
                        AClass myCls = new AClass();
                        myCls.Win32CallMethod();
                    }
                }
            }
        }
    }
}

/*

This code example produces the following results.

First, the compilation yields the warning, "...This method is
obsolete. Use managed MsgBox instead."
Second, execution yields a message box with a title of "Caution!"
and message text of "This is an unmanaged call."
Third, the following text is displayed in the console window:

Method Win32CallMethod is obsolete. The message is:
  "This method is obsolete. Use managed MsgBox instead."
This method calls unmanaged code.
The Unmanaged attribute type is User.

*/

// </Snippet4>
