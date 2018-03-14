//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.TextBox textBox1;

    [STAThread]
    static void Main() 
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.trackBar1 = new System.Windows.Forms.TrackBar();

        // TextBox for TrackBar.Value update.
        this.textBox1.Location = new System.Drawing.Point(240, 16);
        this.textBox1.Size = new System.Drawing.Size(48, 20);

        // Set up how the form should be displayed and add the controls to the form.
        this.ClientSize = new System.Drawing.Size(296, 62);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.textBox1,this.trackBar1});
        this.Text = "TrackBar Example";

        // Set up the TrackBar.
        this.trackBar1.Location = new System.Drawing.Point(8, 8);
        this.trackBar1.Size = new System.Drawing.Size(224, 45);
        this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);

        // The Maximum property sets the value of the track bar when
        // the slider is all the way to the right.
        trackBar1.Maximum = 30;
        
        // The TickFrequency property establishes how many positions
        // are between each tick-mark.
        trackBar1.TickFrequency = 5;

        // The LargeChange property sets how many positions to move
        // if the bar is clicked on either side of the slider.
        trackBar1.LargeChange = 3;

        // The SmallChange property sets how many positions to move
        // if the keyboard arrows are used to move the slider.
        trackBar1.SmallChange = 2;
    }


    private void trackBar1_Scroll(object sender, System.EventArgs e)
    {
        // Display the trackbar value in the text box.
        textBox1.Text = "" + trackBar1.Value;
    }
}
//</Snippet1>

