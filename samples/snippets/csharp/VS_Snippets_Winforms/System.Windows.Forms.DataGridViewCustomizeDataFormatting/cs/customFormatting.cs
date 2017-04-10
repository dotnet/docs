//<Snippet00>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private Bitmap highPriImage;
    private Bitmap mediumPriImage;
    private Bitmap lowPriImage;

    //<Snippet10>
    public Form1()
    {
        // Initialize the images. 
        try
        {
            highPriImage = new Bitmap("highPri.bmp");
            mediumPriImage = new Bitmap("mediumPri.bmp");
            lowPriImage = new Bitmap("lowPri.bmp");
        }
        catch (ArgumentException)
        {
            MessageBox.Show("The Priority column requires Bitmap images " +
                "named highPri.bmp, mediumPri.bmp, and lowPri.bmp " +
                "residing in the same directory as the executable file.");
        }

        // Initialize the DataGridView.
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.Columns.AddRange(
            new DataGridViewTextBoxColumn(),
            new DataGridViewImageColumn());
        dataGridView1.Columns[0].Name = "Balance";
        dataGridView1.Columns[1].Name = "Priority";
        dataGridView1.Rows.Add("-100", "high");
        dataGridView1.Rows.Add("0", "medium");
        dataGridView1.Rows.Add("100", "low");
        dataGridView1.CellFormatting +=
            new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
            this.dataGridView1_CellFormatting);
        this.Controls.Add(dataGridView1);
    }
    //</Snippet10>

    //<Snippet20>
    // Changes how cells are displayed depending on their columns and values.
    private void dataGridView1_CellFormatting(object sender, 
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
        //<Snippet21>
        // Set the background to red for negative values in the Balance column.
        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Balance"))
        {
            Int32 intValue;
            if (Int32.TryParse((String)e.Value, out intValue) && 
                (intValue < 0))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }
        //</Snippet21>

        //<Snippet22>
        // Replace string values in the Priority column with images.
        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Priority"))
        {
            // Ensure that the value is a string.
            String stringValue = e.Value as string;
            if (stringValue == null) return;

            // Set the cell ToolTip to the text value.
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            cell.ToolTipText = stringValue;

            // Replace the string value with the image value.
            switch (stringValue)
            {
                case "high":
                    e.Value = highPriImage;
                    break;
                case "medium":
                    e.Value = mediumPriImage;
                    break;
                case "low":
                    e.Value = lowPriImage;
                    break;
            }
        }
        //</Snippet22>
    }
    //</Snippet20>

    public static void Main()
    {
        Application.Run(new Form1());
    }

}
//</Snippet00>