//<Snippet00>
using System;
using System.Windows.Forms;

public class Form1 : Form
{
    private DataGridView DataGridView1 = new DataGridView();
    private Button CopyPasteButton = new Button();
    private TextBox TextBox1 = new TextBox();

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        this.DataGridView1.AllowUserToAddRows = false;
        this.DataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(this.DataGridView1);

        this.CopyPasteButton.Text = "copy/paste selected cells";
        this.CopyPasteButton.Dock = DockStyle.Top;
        this.CopyPasteButton.Click += new EventHandler(CopyPasteButton_Click);
        this.Controls.Add(this.CopyPasteButton);

        this.TextBox1.Multiline = true;
        this.TextBox1.Height = 100;
        this.TextBox1.Dock = DockStyle.Bottom;
        this.Controls.Add(this.TextBox1);

        this.Load += new EventHandler(Form1_Load);
        this.Text = "DataGridView Clipboard demo";
    }

    //<Snippet10>
    private void Form1_Load(object sender, System.EventArgs e)
    {
        // Initialize the DataGridView control.
        this.DataGridView1.ColumnCount = 5;
        this.DataGridView1.Rows.Add(new string[] { "A", "B", "C", "D", "E" });
        this.DataGridView1.Rows.Add(new string[] { "F", "G", "H", "I", "J" });
        this.DataGridView1.Rows.Add(new string[] { "K", "L", "M", "N", "O" });
        this.DataGridView1.Rows.Add(new string[] { "P", "Q", "R", "S", "T" });
        this.DataGridView1.Rows.Add(new string[] { "U", "V", "W", "X", "Y" });
        this.DataGridView1.AutoResizeColumns();
        //<Snippet15>
        this.DataGridView1.ClipboardCopyMode = 
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        //</Snippet15>
    }

    //<Snippet16>
    private void CopyPasteButton_Click(object sender, System.EventArgs e)
    {
        if (this.DataGridView1
            .GetCellCount(DataGridViewElementStates.Selected) > 0)
        {
            try
            {
                // Add the selection to the clipboard.
                Clipboard.SetDataObject(
                    this.DataGridView1.GetClipboardContent());
                
                // Replace the text box contents with the clipboard text.
                this.TextBox1.Text = Clipboard.GetText();
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                this.TextBox1.Text = 
                    "The Clipboard could not be accessed. Please try again.";
            }
        }
    }
    //</Snippet16>
    //</Snippet10>

}
//</Snippet00>


