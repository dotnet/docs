using System;
using System.Windows.Forms;

// <Snippet1>
public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        // Start the application.
        Application.Run(new Form1());
    }

    private Button button1;
    private ListBox listBox1;

    public Form1()
    {
        button1 = new Button();
        button1.Left = 200;
        button1.Text = "Exit";
        button1.Click += new EventHandler(button1_Click);

        listBox1 = new ListBox();
        this.Controls.Add(button1);
        this.Controls.Add(listBox1);
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
        int count = 1;
        // Check to see whether the user wants to exit the application.
        // If not, add a number to the list box.
        while (MessageBox.Show("Exit application?", "", 
            MessageBoxButtons.YesNo)==DialogResult.No)
        {
            listBox1.Items.Add(count);
            count += 1;
        }

        // The user wants to exit the application. 
        // Close everything down.
        Application.Exit();
    }
}
// </Snippet1>