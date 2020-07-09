// <Snippet102>
using System;
using System.Windows.Automation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace CSClient
{
    class CSClientProgram
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            // TODO  Change the path to the appropriate one for your CSProviderDLL.
            string fileloc = @"C:\SampleDependencies\CSProviderDLL.dll";
            Assembly a = null;
            try
            {
                a = Assembly.LoadFile(fileloc);
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            if (a != null)
            {
                try
                {
                    ClientSettings.RegisterClientSideProviderAssembly(a.GetName());
                }
                catch (ProxyAssemblyNotLoadedException e)
                {
                    Console.WriteLine(e.Message);
                }

                IntPtr hwnd = GetConsoleWindow();

                // Get an AutomationElement that represents the window.
                AutomationElement elementWindow = AutomationElement.FromHandle(hwnd);
                Console.WriteLine("Found UI Automation client-side provider for:");

                // The name property is furnished by the client-side provider.
                Console.WriteLine(elementWindow.Current.Name);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
// </Snippet102>
