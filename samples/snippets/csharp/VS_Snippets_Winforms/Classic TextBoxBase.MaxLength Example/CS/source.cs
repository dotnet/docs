using System;
using System.Windows.Forms;

public class Form1 : Form {

// <Snippet1>
public void CreateMyPasswordTextBox()
 {
    // Create an instance of the TextBox control.
    TextBox textBox1 = new TextBox();
    // Set the maximum length of text in the control to eight.
    textBox1.MaxLength = 8;
    // Assign the asterisk to be the password character.
    textBox1.PasswordChar = '*';
    // Change all text entered to be uppercase.
    textBox1.CharacterCasing = CharacterCasing.Upper;
    // Align the text in the center of the TextBox control.
    textBox1.TextAlign = HorizontalAlignment.Center;
 }
 // </Snippet1>

}
