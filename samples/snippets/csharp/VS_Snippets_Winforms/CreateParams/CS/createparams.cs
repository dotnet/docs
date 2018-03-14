// <snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
public class MyIconButton : Button
{

    private Icon icon;

    public MyIconButton()
    {
        // Set the button's FlatStyle property.
        FlatStyle = FlatStyle.System;
    }

    public MyIconButton(Icon ButtonIcon)
        : this()
    {
        // Assign the icon to the private field.   
        this.icon = ButtonIcon;


        // Size the button to 4 pixels larger than the icon.
        this.Height = icon.Height + 4;
        this.Width = icon.Width + 4;
    }

    //<snippet3>
    protected override CreateParams CreateParams
    {
        get
        {
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

            // Extend the CreateParams property of the Button class.
            CreateParams cp = base.CreateParams;
            // Update the button Style.
            cp.Style |= 0x00000040; // BS_ICON value

            return cp;
        }
    }
    //</snippet3>     

    public Icon Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
            UpdateIcon();
            // Size the button to 4 pixels larger than the icon.
            this.Height = icon.Height + 4;
            this.Width = icon.Width + 4;
        }
    }

    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        // Update the icon on the button if there is currently an icon assigned to the icon field.
        if (icon != null)
        {
            UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        IntPtr iconHandle = IntPtr.Zero;

        // Get the icon's handle.
        if (icon != null)
        {
            iconHandle = icon.Handle;
        }

        // Send Windows the message to update the button. 
        SendMessage(Handle, 0x00F7 /*BM_SETIMAGE value*/, 1 /*IMAGE_ICON value*/, (int)iconHandle);
    }


    // Import the SendMessage method of the User32 DLL.   
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

}
// </snippet1>


/////////////////////////////////////////////////////////////////////////////////////////////////////////////

// <snippet2>
public class MyApplication : Form
{
    private MyIconButton myIconButton;
    private Button stdButton;
    private OpenFileDialog openDlg;

    static void Main()
    {
        Application.Run(new MyApplication());
    }

    public MyApplication()
    {
        try
        {
            // Create the button with the default icon.
            myIconButton = new MyIconButton(new Icon(Application.StartupPath + "\\Default.ico"));
        }
        catch (Exception ex)
        {
            // If the default icon does not exist, create the button without an icon.
            myIconButton = new MyIconButton();
            Debug.WriteLine(ex.ToString());
        }
        finally
        {
            stdButton = new Button();

            // Add the Click event handlers.
            myIconButton.Click += new EventHandler(this.myIconButton_Click);
            stdButton.Click += new EventHandler(this.stdButton_Click);

            // Set the location, text and width of the standard button.
            stdButton.Location = new Point(myIconButton.Location.X, myIconButton.Location.Y + myIconButton.Height + 20);
            stdButton.Text = "Change Icon";
            stdButton.Width = 100;

            // Add the buttons to the Form.
            this.Controls.Add(stdButton);
            this.Controls.Add(myIconButton);
        }

    }

    private void myIconButton_Click(object Sender, EventArgs e)
    {
        // Make sure MyIconButton works.
        MessageBox.Show("MyIconButton was clicked!");
    }

    private void stdButton_Click(object Sender, EventArgs e)
    {
        // Use an OpenFileDialog to allow the user to assign a new image to the derived button.
        openDlg = new OpenFileDialog();
        openDlg.InitialDirectory = Application.StartupPath;
        openDlg.Filter = "Icon files (*.ico)|*.ico";
        openDlg.Multiselect = false;
        openDlg.ShowDialog();

        if (openDlg.FileName != "")
        {
            myIconButton.Icon = new Icon(openDlg.FileName);
        }
    }

}
// </snippet2>