// <Snippet201>
using System;
using System.Windows.Automation;
using System.Windows.Automation.Provider;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace CSClientProviderImplementation
{
    class CSClientSideImplementationProgram
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {

            ClientSettings.RegisterClientSideProviders(
                UIAutomationClientSideProviders.ClientSideProviderDescriptionTable);

            IntPtr hwnd = GetConsoleWindow();

            // Get an AutomationElement that represents the window.
            AutomationElement elementWindow = AutomationElement.FromHandle(hwnd);
            Console.WriteLine("Found UI Automation client-side provider for:");

            // The name property is furnished by the client-side provider.
            Console.WriteLine(elementWindow.Current.Name);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }  // CSClientSideImplementationProgram class

    class UIAutomationClientSideProviders
    {
        /// <summary>
        /// Implementation of the static ClientSideProviderDescriptionTable field.
        /// In this case,only a single provider is listed in the table.
        /// </summary>
        public static ClientSideProviderDescription[] ClientSideProviderDescriptionTable =
            { new ClientSideProviderDescription(
                // Method that creates the provider object.
                WindowProvider.Create,
                // Class of window that will be served by the provider.
                "ConsoleWindowClass") };
    }

    class WindowProvider : IRawElementProviderSimple
    {
        IntPtr providerHwnd;

        public WindowProvider(IntPtr hwnd)
        {
            providerHwnd = hwnd;
        }

        internal static IRawElementProviderSimple Create(
            IntPtr hwnd, int idChild, int idObject)
        {
            return Create(hwnd, idChild);
        }

        private static IRawElementProviderSimple Create(
            IntPtr hwnd, int idChild)
        {
            // Something is wrong if idChild is not 0.
            if (idChild != 0) return null;
            else return new WindowProvider(hwnd);
        }

        #region IRawElementProviderSimple

        // This is a skeleton implementation. The only real functionality at this stage
        // is to return the name of the element and the host window provider, which can
        // supply other properties.

        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ClientSideProvider;
            }
        }

        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider
        {
            get
            {
                return AutomationInteropProvider.HostProviderFromHandle(providerHwnd);
            }
        }

        object IRawElementProviderSimple.GetPropertyValue(int aid)
        {
            if (AutomationProperty.LookupById(aid) ==
                AutomationElementIdentifiers.NameProperty)
            {
                return "Custom Console Window";
            }
            else
            {
                return null;
            }
        }

        object IRawElementProviderSimple.GetPatternProvider(int iid)
        {
            return null;
        }
        #endregion IRawElementProviderSimple
    }
}
// </Snippet201>
