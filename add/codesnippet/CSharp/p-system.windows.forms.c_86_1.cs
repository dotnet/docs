private void button1_Click(object sender, System.EventArgs e)
 {
    ColorDialog MyDialog = new ColorDialog();
    // Keeps the user from selecting a custom color.
    MyDialog.AllowFullOpen = false ;
    // Allows the user to get help. (The default is false.)
    MyDialog.ShowHelp = true ;
    // Sets the initial color select to the current text color.
    MyDialog.Color = textBox1.ForeColor ;
    
    // Update the text box color if the user clicks OK 
    if (MyDialog.ShowDialog() == DialogResult.OK)
        textBox1.ForeColor =  MyDialog.Color;
 }
    