using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected TextBox textBox1;
 
//<Snippet1>
    private void button1_Click(object sender, System.EventArgs e)
    {
        Stream myStream = null;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
 
        openFileDialog1.InitialDirectory = "c:\\" ;
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
        openFileDialog1.FilterIndex = 2 ;
        openFileDialog1.RestoreDirectory = true ;

        if(openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        // Insert code to read the stream here.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
        
//</Snippet1>
}
