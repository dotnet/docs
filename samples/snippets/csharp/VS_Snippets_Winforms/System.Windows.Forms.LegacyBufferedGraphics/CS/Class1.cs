using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;

public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
    // 4c2a90ee-bbbe-4ff6-9170-1b06c195c918
    // How to: Manually Manage Buffered Graphics

    public void Method11()
    {
        // <snippet11>
        BufferedGraphicsContext myContext;
        myContext = BufferedGraphicsManager.Current;
        // </snippet11>
    }
    public void Method12()
    {
        // <snippet12>
        BufferedGraphicsContext myContext;
        myContext = new BufferedGraphicsContext();
        // Insert code to create graphics here.
        // On a non-default BufferedGraphicsContext instance, you should always 
        // call Dispose when finished.
        myContext.Dispose();
        // </snippet12>
    }
    // 5192295e-bd8e-45f7-8bd6-5c4f6bd21e61
    // How to: Manually Render Buffered Graphics

    public void Method21()
    {
        // <snippet21>
        // This example assumes the existence of a form called Form1.
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        // Gets a reference to the current BufferedGraphicsContext
        currentContext = BufferedGraphicsManager.Current;
        // Creates a BufferedGraphics instance associated with Form1, and with 
        // dimensions the same size as the drawing surface of Form1.
        myBuffer = currentContext.Allocate(this.CreateGraphics(),
           this.DisplayRectangle);
	// </snippet21>
    
        // <snippet22>
        // Draws an ellipse to the graphics buffer.
        myBuffer.Graphics.DrawEllipse(Pens.Blue, this.DisplayRectangle);
        // </snippet22>
    
        // <snippet23>
        // This example assumes the existence of a BufferedGraphics instance
        // called myBuffer.
        // Renders the contents of the buffer to the drawing surface associated 
        // with the buffer.
        myBuffer.Render();
        // Renders the contents of the buffer to the specified drawing surface.
        myBuffer.Render(this.CreateGraphics());
        // </snippet23>
    
        // <snippet24>
        myBuffer.Dispose();
        // </snippet24>
    }
    // 91083d3a-653f-4f15-a467-0f37b2aa39d6
    // How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls

    public void Method31()
    {
        // <snippet31>
        DoubleBuffered = true;
        // </snippet31>
    }
    public void Method32()
    {
        // <snippet32>
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        // </snippet32>
    }
}

