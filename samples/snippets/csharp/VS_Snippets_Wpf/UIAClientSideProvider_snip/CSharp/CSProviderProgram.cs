// <Snippet101>
using System;
using System.Windows.Automation;
using System.Windows.Automation.Provider;

namespace ClientSideProviderAssembly
{
    // The assembly must implement a UIAutomationClientSideProviders class,
    // and the namespace must be the same as the name of the DLL, so that
    // UI Automation can find the table of descriptors. In this example,
    // the DLL would be "ClientSideProviderAssembly.dll"

    static class UIAutomationClientSideProviders
    {
        /// <summary>
        /// Implementation of the static ClientSideProviderDescriptionTable field.
        /// In this case, only a single provider is listed in the table.
        /// </summary>
        public static ClientSideProviderDescription[] ClientSideProviderDescriptionTable =
            {
                new ClientSideProviderDescription(
                    // Method that creates the provider object.
                    new ClientSideProviderFactoryCallback(ConsoleProvider.Create),
                    // Class of window that will be served by the provider.
                    "ConsoleWindowClass")
            };
    }

    class ConsoleProvider : IRawElementProviderSimple
    {
        IntPtr providerHwnd;

        public ConsoleProvider(IntPtr hwnd)
        {
            providerHwnd = hwnd;
        }

        internal static IRawElementProviderSimple Create(
            IntPtr hwnd, int idChild, int idObject)
        {
            // This provider doesn't expose children, so never expects
            // nonzero values for idChild.
            if (idChild != 0)
                return null;
            else
                return new ConsoleProvider(hwnd);
        }

        private static IRawElementProviderSimple Create(
            IntPtr hwnd, int idChild)
        {
            // Something is wrong if idChild is not 0.
            if (idChild != 0) return null;
            else return new ConsoleProvider(hwnd);
        }

        #region IRawElementProviderSimple

        // This is a skeleton implementation. The only real functionality
        // at this stage is to return the name of the element and the host
        // window provider, which can supply other properties.

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

        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            if (propertyId == AutomationElementIdentifiers.NameProperty.Id)
                return "Custom Console Window";
            else
                return null;
        }

        object IRawElementProviderSimple.GetPatternProvider(int iid)
        {
            return null;
        }
        #endregion IRawElementProviderSimple
    }
}
// </Snippet101>