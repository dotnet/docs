//<snippet00>
//<snippet10>
using System;
using System.Drawing;
using System.Windows.Forms;

public class ToolStripSpringTextBox : ToolStripTextBox
{
    public override Size GetPreferredSize(Size constrainingSize)
    {        
        // Use the default size if the text box is on the overflow menu
        // or is on a vertical ToolStrip.
        if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
        {
            return DefaultSize;
        }

        // Declare a variable to store the total available width as 
        // it is calculated, starting with the display width of the 
        // owning ToolStrip.
        Int32 width = Owner.DisplayRectangle.Width;

        // Subtract the width of the overflow button if it is displayed. 
        if (Owner.OverflowButton.Visible)
        {
            width = width - Owner.OverflowButton.Width -
                Owner.OverflowButton.Margin.Horizontal;
        }

        // Declare a variable to maintain a count of ToolStripSpringTextBox 
        // items currently displayed in the owning ToolStrip. 
        Int32 springBoxCount = 0;

        foreach (ToolStripItem item in Owner.Items)
        {
            // Ignore items on the overflow menu.
            if (item.IsOnOverflow) continue;

            if (item is ToolStripSpringTextBox)
            {
                // For ToolStripSpringTextBox items, increment the count and 
                // subtract the margin width from the total available width.
                springBoxCount++;
                width -= item.Margin.Horizontal;
            }
            else
            {
                // For all other items, subtract the full width from the total
                // available width.
                width = width - item.Width - item.Margin.Horizontal;
            }
        }

        // If there are multiple ToolStripSpringTextBox items in the owning
        // ToolStrip, divide the total available width between them. 
        if (springBoxCount > 1) width /= springBoxCount;

        // If the available width is less than the default width, use the
        // default width, forcing one or more items onto the overflow menu.
        if (width < DefaultSize.Width) width = DefaultSize.Width;

        // Retrieve the preferred size from the base class, but change the
        // width to the calculated width. 
        Size size = base.GetPreferredSize(constrainingSize);
        size.Width = width;
        return size;
    }
}
//</snippet10>

//<snippet20>
public class Form1 : Form
{
    public Form1()
    {
        ToolStrip toolStrip1 = new ToolStrip();
        toolStrip1.Dock = DockStyle.Top;
        toolStrip1.Items.Add(new ToolStripLabel("Address"));
        toolStrip1.Items.Add(new ToolStripSpringTextBox());
        toolStrip1.Items.Add(new ToolStripButton("Go"));
        Controls.Add(toolStrip1);
        Text = "ToolStripSpringTextBox demo";
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
//</snippet20>
//</snippet00>