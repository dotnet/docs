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
    // <snippet1>
    public partial class Form1 : Form
    {
        // Use this Random object to choose random icons for the squares
        Random random = new Random();

        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>() 
        { 
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        // </snippet1>

        // <snippet13>
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }
        // </snippet13>

        // <snippet2>
        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // <snippet16>
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    // iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
                // </snippet16>
            }
        } 
        // </snippet2>

       private void PlaceHolder2()
       {
           // <snippet14>
           foreach (Control control in tableLayoutPanel1.Controls)
           {
               // The statements you want to execute 
               // for each label go here
               // The statements use iconLabel to access 
               // each label's properties and methods
           }
           // </snippet14>

           foreach (Control control in tableLayoutPanel1.Controls)
           {
               Label iconLabel = control as Label;
               if (iconLabel != null)
               {
                   int randomNumber = random.Next(icons.Count);
                   iconLabel.Text = icons[randomNumber];
                   // <snippet15>
                   iconLabel.ForeColor = iconLabel.BackColor;
                   // </snippet15>
                   icons.RemoveAt(randomNumber);
               }
           }
       }

        // <snippet4>
        /// <summary>
        /// Every label's Click event is handled by this event handler
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                clickedLabel.ForeColor = Color.Black;
            }
         }
         // </snippet4>

    }

}
