using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Math_Quiz

{
    public partial class Form1 : Form

    {
        public Form1()

        {
            InitializeComponent();
        }

        // These ints will store the numbers
        // for the addition problem.
        int addend1;
        int addend2;

    // <snippet8>
    /// <summary>
    /// Check the answer to see if the user got everything right.
    /// </summary>
    /// <returns>True if the answer's correct, false otherwise.</returns>
    private bool CheckTheAnswer()
    {
        if (addend1 + addend2 == sum.Value)
            return true;
        else
            return false;
    }
    // </snippet8>

void PlaceHolder() {

    // <snippet9>
    if (CheckTheAnswer())
    {
          // statements that will get executed
          // if the answer is correct 
    }
    else if (timeLeft > 0)
    {
          // statements that will get executed
          // if there's still time left on the timer
    }
    else
    {
          // statements that will get executed if the timer ran out
    }  
    // </snippet9>

}

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

    // <snippet10>
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (CheckTheAnswer())
        {
            // If CheckTheAnswer() returns true, then the user 
            // got the answer right. Stop the timer  
            // and show a MessageBox.
            timer1.Stop();
            MessageBox.Show("You got all the answers right!",
                            "Congratulations!");
            startButton.Enabled = true;
        }
        else if (timeLeft > 0)
        {
           // If CheckTheAnswer() return false, keep counting
           // down. Decrease the time left by one second and 
           // display the new time left by updating the 
           // Time Left label.
           timeLeft--;
            timeLabel.Text = timeLeft + " seconds";
        }
        else
        {
            // If the user ran out of time, stop the timer, show 
            // a MessageBox, and fill in the answers.
            timer1.Stop();
            timeLabel.Text = "Time's up!";
            MessageBox.Show("You didn't finish in time.", "Sorry!");
            sum.Value = addend1 + addend2;
            startButton.Enabled = true;
        }
    }
    // </snippet10>

    }

}
