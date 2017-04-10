using System;
using System.Windows;
using System.Security.Permissions;

namespace WindowsApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        // Web browser permission code attributes.

        // <SnippetWebBrowserPermissionAttribute1>
        [WebBrowserPermissionAttribute(SecurityAction.Demand, Level = WebBrowserPermissionLevel.None)]
        // </SnippetWebBrowserPermissionAttribute1>
        public void Stub01() { }

        // <SnippetWebBrowserPermissionAttribute2>
        [WebBrowserPermissionAttribute(SecurityAction.Demand, Level = WebBrowserPermissionLevel.Safe)]
        // </SnippetWebBrowserPermissionAttribute2>
        public void Stub02() { }

        // <SnippetWebBrowserPermissionAttribute3>
        [WebBrowserPermissionAttribute(SecurityAction.Demand, Level = WebBrowserPermissionLevel.Unrestricted)]
        // </SnippetWebBrowserPermissionAttribute3>
        public void Stub03() { }

        // <SnippetWebBrowserPermissionAttribute4>
        [WebBrowserPermissionAttribute(SecurityAction.Demand)]
        // </SnippetWebBrowserPermissionAttribute4>
        public void Stub03a() {}

        // Create Web browser permission via constructor.
        public void Stub04()
        {
            // <SnippetWebBrowserPermission1>
            WebBrowserPermission webBrowserPermission = new WebBrowserPermission(PermissionState.Unrestricted);
            // </SnippetWebBrowserPermission1>

            // <SnippetWebBrowserPermission5>
            bool isUnrestricted = webBrowserPermission.IsUnrestricted();
            // </SnippetWebBrowserPermission5>

            webBrowserPermission = new WebBrowserPermission(PermissionState.None);
            isUnrestricted = webBrowserPermission.IsUnrestricted();

            // <SnippetWebBrowserPermission6>
            WebBrowserPermissionLevel webBrowserPermissionLevel = webBrowserPermission.Level;
            // </SnippetWebBrowserPermission6>
        }

        public void Stub05()
        {
            // <SnippetWebBrowserPermission2>
            WebBrowserPermission webBrowserPermission = new WebBrowserPermission(WebBrowserPermissionLevel.None);
            // </SnippetWebBrowserPermission2>
        }

        public void Stub06()
        {
            // <SnippetWebBrowserPermission3>
            WebBrowserPermission webBrowserPermission = new WebBrowserPermission(WebBrowserPermissionLevel.Safe);
            // </SnippetWebBrowserPermission3>
        }

        public void Stub07()
        {
            // <SnippetWebBrowserPermission4>
            WebBrowserPermission webBrowserPermission = new WebBrowserPermission(WebBrowserPermissionLevel.Unrestricted);
            // </SnippetWebBrowserPermission4>
        }
    }
}