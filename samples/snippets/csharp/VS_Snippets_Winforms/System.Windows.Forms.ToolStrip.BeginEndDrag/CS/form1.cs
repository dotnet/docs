// <Snippet1>
using System;
using System.Windows.Forms;

public class Form1 : Form
{
    private ToolStripContainer toolStripContainer1;
    private ToolStrip toolStrip1;
    private RichTextBox richTextBox1;
 
    public Form1()
    {
        DragToolStrip();
    }
    [STAThread]
    static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void DragToolStrip()
        {
        // Create a ToolStripContainer.
        toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
        toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        Controls.Add(toolStripContainer1);

        // Create a ToolStrip and add items to it.
        toolStrip1 = new System.Windows.Forms.ToolStrip();
        toolStrip1.Items.Add("One");
        toolStrip1.Items.Add("Two");
        toolStrip1.Items.Add("Three");
            
        // Add the ToolStrip to the top panel of the ToolStripContainer.
        toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            
        // Create a RichTextBox and add it to the ContentPanel.
        richTextBox1 = new System.Windows.Forms.RichTextBox();
        richTextBox1.Location = new System.Drawing.Point(94, 61);
        toolStripContainer1.ContentPanel.Controls.Add(richTextBox1);

        // Attach event handlers for the BeginDrag and EndDrag events.
        toolStrip1.BeginDrag += new System.EventHandler(toolStrip1_BeginDrag);
        toolStrip1.EndDrag += new System.EventHandler(toolStrip1_EndDrag);
    }
    // Clear any text from the RichTextBox when a drag operation begins.
    private void toolStrip1_BeginDrag(object sender, EventArgs e)
    {
        richTextBox1.Text = "";
    }
    // Notify the user when the drag operation ends.
    private void toolStrip1_EndDrag(object sender, EventArgs e)
    {
        richTextBox1.Text="The drag operation is complete.";
    }
}
// </Snippet1>