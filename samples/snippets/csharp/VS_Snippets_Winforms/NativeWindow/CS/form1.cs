//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NativeWindowApplication
{

    // Summary description for Form1.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class Form1 : System.Windows.Forms.Form
    {
        private MyNativeWindowListener nwl;
        private MyNativeWindow nw;

        internal void ApplicationActivated(bool ApplicationActivated)
        {
            // The application has been activated or deactivated
            System.Diagnostics.Debug.WriteLine("Application Active = " + ApplicationActivated.ToString());
        }

        private Form1()
        {
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "Form1";

            nwl = new MyNativeWindowListener(this);
            nw = new MyNativeWindow(this);

        }

        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }

    //<Snippet2>
    // NativeWindow class to listen to operating system messages.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class MyNativeWindowListener : NativeWindow
    {

        // Constant value was found in the "windows.h" header file.
        private const int WM_ACTIVATEAPP = 0x001C;

        private Form1 parent;

        public MyNativeWindowListener(Form1 parent)
        {

            parent.HandleCreated += new EventHandler(this.OnHandleCreated);
            parent.HandleDestroyed += new EventHandler(this.OnHandleDestroyed);
            this.parent = parent;
        }

        // Listen for the control's window creation and then hook into it.
        internal void OnHandleCreated(object sender, EventArgs e)
        {
            // Window is now created, assign handle to NativeWindow.
            AssignHandle(((Form1)sender).Handle);
        }
        internal void OnHandleDestroyed(object sender, EventArgs e)
        {
            // Window was destroyed, release hook.
            ReleaseHandle();
        }
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages

            switch (m.Msg)
            {
                case WM_ACTIVATEAPP:

                    // Notify the form that this message was received.
                    // Application is activated or deactivated, 
                    // based upon the WParam parameter.
                    parent.ApplicationActivated(((int)m.WParam != 0));

                    break;
            }
            base.WndProc(ref m);
        }
    }
    //</Snippet2>

    //<Snippet3>
    // MyNativeWindow class to create a window given a class name.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class MyNativeWindow : NativeWindow
    {

        // Constant values were found in the "windows.h" header file.
        private const int WS_CHILD = 0x40000000,
                          WS_VISIBLE = 0x10000000,
                          WM_ACTIVATEAPP = 0x001C;

        private int windowHandle;

        public MyNativeWindow(Form parent)
        {

            CreateParams cp = new CreateParams();

            // Fill in the CreateParams details.
            cp.Caption = "Click here";
            cp.ClassName = "Button";

            // Set the position on the form
            cp.X = 100;
            cp.Y = 100;
            cp.Height = 100;
            cp.Width = 100;

            // Specify the form as the parent.
            cp.Parent = parent.Handle;

            // Create as a child of the specified parent
            cp.Style = WS_CHILD | WS_VISIBLE;

            // Create the actual window
            this.CreateHandle(cp);
        }

        // Listen to when the handle changes to keep the variable in sync
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void OnHandleChange()
        {
            windowHandle = (int)this.Handle;
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for messages that are sent to the button window. Some messages are sent
            // to the parent window instead of the button's window.

            switch (m.Msg)
            {
                case WM_ACTIVATEAPP:
                    // Do something here in response to messages
                    break;
            }
            base.WndProc(ref m);
        }
    }
    //</Snippet3>
}
//</Snippet1>
