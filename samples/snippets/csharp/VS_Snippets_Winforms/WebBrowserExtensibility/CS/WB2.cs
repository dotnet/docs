//<snippet00>
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace WebBrowserExtensibility
{
    [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
    public class Form1 : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new Form1());
        }

        private WebBrowser2 wb = new WebBrowser2();
        public Form1()
        {
            wb.Dock = DockStyle.Fill;
            wb.NavigateError += new 
                WebBrowserNavigateErrorEventHandler(wb_NavigateError);
            Controls.Add(wb);

            // Attempt to navigate to an invalid address.
            wb.Navigate("www.widgets.microsoft.com");
        }

        private void wb_NavigateError(
            object sender, WebBrowserNavigateErrorEventArgs e)
        {
            // Display an error message to the user.
            MessageBox.Show("Cannot navigate to " + e.Url);
        }
    }

    public class WebBrowser2 : WebBrowser
    {
        //<snippet10>
        AxHost.ConnectionPointCookie cookie;
        WebBrowser2EventHelper helper;

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void CreateSink()
        {
            base.CreateSink();

            // Create an instance of the client that will handle the event
            // and associate it with the underlying ActiveX control.
            helper = new WebBrowser2EventHelper(this);
            cookie = new AxHost.ConnectionPointCookie(
                this.ActiveXInstance, helper, typeof(DWebBrowserEvents2));
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void DetachSink()
        {
            // Disconnect the client that handles the event
            // from the underlying ActiveX control.
            if (cookie != null)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }
        //</snippet10>

        public event WebBrowserNavigateErrorEventHandler NavigateError;

        // Raises the NavigateError event.
        protected virtual void OnNavigateError(
            WebBrowserNavigateErrorEventArgs e)
        {
            if (this.NavigateError != null)
            {
                this.NavigateError(this, e);
            }
        }

        // Handles the NavigateError event from the underlying ActiveX 
        // control by raising the NavigateError event defined in this class.
        private class WebBrowser2EventHelper : 
            StandardOleMarshalObject, DWebBrowserEvents2
        {
            private WebBrowser2 parent;

            public WebBrowser2EventHelper(WebBrowser2 parent)
            {
                this.parent = parent;
            }

            public void NavigateError(object pDisp, ref object url, 
                ref object frame, ref object statusCode, ref bool cancel)
            {
                // Raise the NavigateError event.
                this.parent.OnNavigateError(
                    new WebBrowserNavigateErrorEventArgs(
                    (String)url, (String)frame, (Int32)statusCode, cancel));
            }
        }
    }

    // Represents the method that will handle the WebBrowser2.NavigateError event.
    public delegate void WebBrowserNavigateErrorEventHandler(object sender, 
        WebBrowserNavigateErrorEventArgs e);

    // Provides data for the WebBrowser2.NavigateError event.
    public class WebBrowserNavigateErrorEventArgs : EventArgs
    {
        private String urlValue;
        private String frameValue;
        private Int32 statusCodeValue;
        private Boolean cancelValue;

        public WebBrowserNavigateErrorEventArgs(
            String url, String frame, Int32 statusCode, Boolean cancel)
        {
            urlValue = url;
            frameValue = frame;
            statusCodeValue = statusCode;
            cancelValue = cancel;
        }

        public String Url
        {
            get { return urlValue; }
            set { urlValue = value; }
        }

        public String Frame
        {
            get { return frameValue; }
            set { frameValue = value; }
        }

        public Int32 StatusCode
        {
            get { return statusCodeValue; }
            set { statusCodeValue = value; }
        }

        public Boolean Cancel
        {
            get { return cancelValue; }
            set { cancelValue = value; }
        }
    }

    // Imports the NavigateError method from the OLE DWebBrowserEvents2 
    // interface. 
    [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DWebBrowserEvents2
    {
        [DispId(271)]
        void NavigateError(
            [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
            [In] ref object URL, [In] ref object frame, 
            [In] ref object statusCode, [In, Out] ref bool cancel);
    }
}
//</snippet00>