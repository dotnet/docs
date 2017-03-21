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