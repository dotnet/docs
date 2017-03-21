            private void myButton1_Click(object sender,EventArgs e)
            {
               //Set the 'AlternatingBackColor'.
               myDataGridTableStyle.AlternatingBackColor=Color.Blue;
            }
            private void myButton2_Click(object sender,EventArgs e)
            {
               // Reset the 'AlternatingBackColor'.
               myDataGridTableStyle.ResetAlternatingBackColor();
            }