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

        // <snippet10>
        /// <summary>
        /// Check every icon to see if it is matched, by 
        /// comparing its foreground color to its background color. 
        /// If all of the icons are matched, the player wins
        /// </summary>
        private void CheckForWinner()
        {
            // Go through all of the labels in the TableLayoutPanel, 
            // checking each one to see if its icon is matched
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null) 
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }
        // </snippet10>

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

            // <snippet11>
            // If the player gets this far, the timer isn't
            // running and firstClicked isn't null, 
            // so this must be the second icon the player clicked
            // Set its color to black
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            // Check to see if the player won
            CheckForWinner();

            // If the player clicked two matching icons, keep them 
            // black and reset firstClicked and secondClicked 
            // so the player can click another icon
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }
            // </snippet11>
        }
        

    }

}
