//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// This designer provides a set of designer verb shortcut menu commands
// that call methods of the IUIService.
public class IUIServiceTestDesigner : System.Windows.Forms.Design.ControlDesigner
{
    public IUIServiceTestDesigner()
    {
    }

    // Provides a set of designer verb menu commands that call 
    // IUIService methods.
    public override System.ComponentModel.Design.DesignerVerbCollection Verbs
    {
        get
        {
            return new DesignerVerbCollection( new DesignerVerb[] 
            {
                new DesignerVerb( 
                    "Show a test message box using the IUIService", 
                     new EventHandler(this.showTestMessage)),
                new DesignerVerb( 
                    "Show a test error message using the IUIService", 
                     new EventHandler(this.showErrorMessage)),
                new DesignerVerb( 
                    "Show an example Form using the IUIService", 
                     new EventHandler(this.showDialog)),
                new DesignerVerb( 
                     "Show the Task List tool window using the IUIService", 
                     new EventHandler(this.showToolWindow)) 
            });
        }
    }

    // Displays a message box with message text, caption text 
    // and buttons of a particular MessageBoxButtons style.
    private void showTestMessage(object sender, EventArgs e)
    {
        //<Snippet2>
        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowMessage("Test message", "Test caption", 
                System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore);
        //</Snippet2>
    }

    // Displays an error message box that displays the message
    // contained in a specified exception.
    private void showErrorMessage(object sender, EventArgs e)
    {       
        //<Snippet3>
        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowError( new Exception(
                "This is a message in a test exception, " + 
                "displayed by the IUIService", 
                 new ArgumentException("Test inner exception")));
        //</Snippet3>
    }

    // Displays an example Windows Form using the 
    // IUIService.ShowDialog method.
    private void showDialog(object sender, EventArgs e)
    {
        //<Snippet4>
        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowDialog(new ExampleForm());
        //</Snippet4>
    }

    // Displays a standard tool window using the 
    // IUIService.ShowToolWindow method.
    private void showToolWindow(object sender, EventArgs e)
    {
        //<Snippet5>
        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowToolWindow(StandardToolWindows.TaskList);
        //</Snippet5>
    }
}

// Provides an example Form class used by the 
// IUIServiceTestDesigner.showDialog method.
internal class ExampleForm : System.Windows.Forms.Form
{
    public ExampleForm()
    {
        this.Text = "Example Form";
        System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();
        okButton.Location = new Point(this.Width-70, this.Height-70);
        okButton.Size = new Size(50, 20);
        okButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
        okButton.DialogResult = DialogResult.OK;
        okButton.Text = "OK";
        this.Controls.Add( okButton );
    }
}

// This control is associated with the IUIServiceTestDesigner, 
// and can be sited in design mode to use the sample.
[DesignerAttribute(typeof(IUIServiceTestDesigner), typeof(IDesigner))]
public class IUIServiceExampleControl : UserControl
{
    public IUIServiceExampleControl()
    {
        this.BackColor = Color.Beige;
        this.Width = 255;
        this.Height = 60;
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        if( this.DesignMode )
        {
            e.Graphics.DrawString(
                "Right-click this control to display a list of the", 
                 new Font("Arial", 9), Brushes.Black, 5, 6);
            e.Graphics.DrawString(
                "designer verb menu commands provided", 
                 new Font("Arial", 9), Brushes.Black, 5, 20);
            e.Graphics.DrawString( 
                "by the IUIServiceTestDesigner.", 
                 new Font("Arial", 9), Brushes.Black, 5, 34);
        }
    }
}
//</Snippet1>