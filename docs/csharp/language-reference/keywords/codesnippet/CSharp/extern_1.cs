    //using System.Runtime.InteropServices;
    class ExternTest
    {
        [DllImport("User32.dll", CharSet=CharSet.Unicode)] 
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        static int Main()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            return MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }

    }
