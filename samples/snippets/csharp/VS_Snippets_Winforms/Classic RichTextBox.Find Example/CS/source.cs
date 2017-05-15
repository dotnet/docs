using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected RichTextBox richTextBox1;
// <Snippet1>
public bool FindMyText(string text)
{
   // Initialize the return value to false by default.
   bool returnValue = false;

   // Ensure a search string has been specified.
   if (text.Length > 0) 
   {
      // Obtain the location of the search string in richTextBox1.
      int indexToText = richTextBox1.Find(text);
      // Determine whether the text was found in richTextBox1.
      if(indexToText >= 0)
      {
         returnValue = true;
      }
   }

   return returnValue;
}

// </Snippet1>
}
