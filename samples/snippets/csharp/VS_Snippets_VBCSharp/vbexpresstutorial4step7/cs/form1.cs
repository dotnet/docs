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

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            // <snippet9>
            // If the player gets this far, the timer isn't
            // running and firstClicked isn't null,
            // so this must be the second icon the player clicked
            // Set its color to black
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            // If the player clicked two matching icons, keep them 
            // black and reset firstClicked and secondClicked 
            // so the player can click another icon
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }

            // If the player gets this far, the player 
            // clicked two different icons, so start the 
            // timer (which will wait three quarters of 
            // a second, and then hide the icons)
            timer1.Start();
        }
    }
    // </snippet9>



}
