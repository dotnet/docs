//<Snippet1>
// The following example displays an application that provides the ability to 
// open rich text files (rtf) into the RichTextBox. The example demonstrates 
// using the FolderBrowserDialog to set the default directory for opening files.
// The OpenFileDialog class is used to open the file.
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

public class FolderBrowserDialogExampleForm : System.Windows.Forms.Form
{
    private FolderBrowserDialog folderBrowserDialog1;
    private OpenFileDialog openFileDialog1;
    
    private RichTextBox richTextBox1;

    private MainMenu mainMenu1;
    private MenuItem fileMenuItem, openMenuItem;
    private MenuItem folderMenuItem, closeMenuItem;
    
    private string openFileName, folderName;

    private bool fileOpened = false;

    // The main entry point for the application.
    [STAThreadAttribute]
    static void Main() 
    {
        Application.Run(new FolderBrowserDialogExampleForm());
    }


    // Constructor.
    public FolderBrowserDialogExampleForm()
    {
        this.mainMenu1 = new System.Windows.Forms.MainMenu();
        this.fileMenuItem = new System.Windows.Forms.MenuItem();
        this.openMenuItem = new System.Windows.Forms.MenuItem();
        this.folderMenuItem = new System.Windows.Forms.MenuItem();
        this.closeMenuItem = new System.Windows.Forms.MenuItem();

        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        this.richTextBox1 = new System.Windows.Forms.RichTextBox();

        this.mainMenu1.MenuItems.Add(this.fileMenuItem);
        this.fileMenuItem.MenuItems.AddRange(
                            new System.Windows.Forms.MenuItem[] {this.openMenuItem,
                                                                 this.closeMenuItem,
                                                                 this.folderMenuItem});
        this.fileMenuItem.Text = "File";

        this.openMenuItem.Text = "Open...";
        this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);

        this.folderMenuItem.Text = "Select Directory...";
        this.folderMenuItem.Click += new System.EventHandler(this.folderMenuItem_Click);

        this.closeMenuItem.Text = "Close";
        this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
        this.closeMenuItem.Enabled = false;

        this.openFileDialog1.DefaultExt = "rtf";
        this.openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf";

        // Set the help text description for the FolderBrowserDialog.
        this.folderBrowserDialog1.Description = 
            "Select the directory that you want to use as the default.";

        // Do not allow the user to create new files via the FolderBrowserDialog.
        this.folderBrowserDialog1.ShowNewFolderButton = false;

        // Default to the My Documents folder.
        this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;

        this.richTextBox1.AcceptsTab = true;
        this.richTextBox1.Location = new System.Drawing.Point(8, 8);
        this.richTextBox1.Size = new System.Drawing.Size(280, 344);
        this.richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | 
                                   AnchorStyles.Bottom | AnchorStyles.Right;

        this.ClientSize = new System.Drawing.Size(296, 360);
        this.Controls.Add(this.richTextBox1);
        this.Menu = this.mainMenu1;
        this.Text = "RTF Document Browser";
    }

    // Bring up a dialog to open a file.
    private void openMenuItem_Click(object sender, System.EventArgs e)
    {
        // If a file is not opened, then set the initial directory to the
        // FolderBrowserDialog.SelectedPath value.
        if (!fileOpened) {
            openFileDialog1.InitialDirectory = folderBrowserDialog1.SelectedPath;
            openFileDialog1.FileName = null;
        }

        // Display the openFile dialog.
        DialogResult result = openFileDialog1.ShowDialog();

        // OK button was pressed.
        if(result == DialogResult.OK) 
        {
            openFileName = openFileDialog1.FileName;
            try
            {
                // Output the requested file in richTextBox1.
                Stream s = openFileDialog1.OpenFile();
                richTextBox1.LoadFile(s, RichTextBoxStreamType.RichText);
                s.Close();    
            
                fileOpened = true;

            } 
            catch(Exception exp)
            {
                MessageBox.Show("An error occurred while attempting to load the file. The error is:" 
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                fileOpened = false;
            }
            Invalidate();

            closeMenuItem.Enabled = fileOpened;
        }

        // Cancel button was pressed.
        else if(result == DialogResult.Cancel) 
        {
            return;
        }
    }


    // Close the current file.
    private void closeMenuItem_Click(object sender, System.EventArgs e)
    {
        richTextBox1.Text = "";
        fileOpened = false;

        closeMenuItem.Enabled = false;
    }


    // Bring up a dialog to chose a folder path in which to open or save a file.
    private void folderMenuItem_Click(object sender, System.EventArgs e)
    {
        // Show the FolderBrowserDialog.
        DialogResult result = folderBrowserDialog1.ShowDialog();
        if( result == DialogResult.OK )
        {
            folderName = folderBrowserDialog1.SelectedPath;
            if(!fileOpened)
            {
                // No file is opened, bring up openFileDialog in selected path.
                openFileDialog1.InitialDirectory = folderName;
                openFileDialog1.FileName = null;
                openMenuItem.PerformClick();
            } 
        }
    }
}
//</Snippet1>