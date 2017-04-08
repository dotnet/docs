using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MatchingGame

{
    public partial class Form1 : Form

    {
        public Form1()

        {
            InitializeComponent();
        }

        // firstClicked points to the first Label control 
        // that the player clicks, but it will be null 
        // if the player hasn't clicked a label yet
        Label firstClicked = null;

        // secondClicked points to the second Label control 
        // that the player clicks
        Label secondClicked = null;

    // <snippet7>
    /// <summary>
    /// This timer is started when the player clicks 
    /// two icons that don't match,
    /// so it counts three quarters of a second 
    /// and then turns itself off and hides both icons
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timer1_Tick(object sender, EventArgs e)
    {
        // Stop the timer
        timer1.Stop();

        // Hide both icons
        firstClicked.ForeColor = firstClicked.BackColor;
        secondClicked.ForeColor = secondClicked.BackColor;

        // Reset firstClicked and secondClicked 
        // so the next time a label is
        // clicked, the program knows it's the first click
        firstClicked = null;
        secondClicked = null;
    }
    // </snippet7>

    // <snippet8>
    /// <summary>
    /// Every label's Click event is handled by this event handler
    /// </summary>
    /// <param name="sender">The label that was clicked</param>
    /// <param name="e"></param>
    private void label_Click(object sender, EventArgs e)
    {
        // The timer is only on after two non-matching 
        // icons have been shown to the player, 
        // so ignore any clicks if the timer is running
        if (timer1.Enabled == true)
            return;

        Label clickedLabel = sender as Label;

        if (clickedLabel != null)
        {
            // If the clicked label is black, the player clicked
            // an icon that's already been revealed --
            // ignore the click
            if (clickedLabel.ForeColor == Color.Black)
                return;

            // If firstClicked is null, this is the first icon
            // in the pair that the player clicked, 
            // so set firstClicked to the label that the player 
            // clicked, change its color to black, and return
            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            // If the player gets this far, the timer isn't
            // running and firstClicked isn't null,
            // so this must be the second icon the player clicked
            // Set its color to black
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            // If the player gets this far, the player 
            // clicked two different icons, so start the 
            // timer (which will wait three quarters of 
            // a second, and then hide the icons)
            timer1.Start();
        }
    }
    // </snippet8>

    }

}
