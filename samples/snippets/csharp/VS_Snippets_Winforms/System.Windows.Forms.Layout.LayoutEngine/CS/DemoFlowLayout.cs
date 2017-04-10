// <snippet1>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

// <snippet2>
// This class demonstrates a simple custom layout panel.
// It overrides the LayoutEngine property of the Panel
// control to provide a custom layout engine. 
public class DemoFlowPanel : Panel
{
    private DemoFlowLayout layoutEngine;

    public DemoFlowPanel()
    {
    }

    public override LayoutEngine LayoutEngine
    {
        get
        {
            if (layoutEngine == null)
            {
                layoutEngine = new DemoFlowLayout();
            }

            return layoutEngine;
        }
    }
}
// </snippet2>

// <snippet3>
// This class demonstrates a simple custom layout engine.
public class DemoFlowLayout : LayoutEngine
{
    // <snippet4>
    public override bool Layout(
        object container,
        LayoutEventArgs layoutEventArgs)
    {
        Control parent = container as Control;

        // Use DisplayRectangle so that parent.Padding is honored.
        Rectangle parentDisplayRectangle = parent.DisplayRectangle;
        Point nextControlLocation = parentDisplayRectangle.Location;

        foreach (Control c in parent.Controls)
        {
            // Only apply layout to visible controls.
            if (!c.Visible)
            {
                continue;
            }

            // Respect the margin of the control:
            // shift over the left and the top.
            nextControlLocation.Offset(c.Margin.Left, c.Margin.Top);

            // Set the location of the control.
            c.Location = nextControlLocation;

            // Set the autosized controls to their 
            // autosized heights.
            if (c.AutoSize)
            {
                c.Size = c.GetPreferredSize(parentDisplayRectangle.Size);
            }

            // Move X back to the display rectangle origin.
            nextControlLocation.X = parentDisplayRectangle.X;

            // Increment Y by the height of the control 
            // and the bottom margin.
            nextControlLocation.Y += c.Height + c.Margin.Bottom;
        }

        // Optional: Return whether or not the container's 
        // parent should perform layout as a result of this 
        // layout. Some layout engines return the value of 
        // the container's AutoSize property.

        return false;
    }
    // </snippet4>
}
// </snippet3>
// </snippet1>