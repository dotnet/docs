using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected RichTextBox richTextBox1;
// <Snippet1>
public int FindMyText(string text, int start)
{
   // Initialize the return value to false by default.
   int returnValue = -1;

   // Ensure that a search string has been specified and a valid start point.
   if (text.Length > 0 && start >= 0) 
   {
      // Obtain the location of the search string in richTextBox1.
      int indexToText = richTextBox1.Find(text, start, RichTextBoxFinds.MatchCase);
      // Determine whether the text was found in richTextBox1.
      if(indexToText >= 0)
      {
         returnValue = indexToText;
      }
   }

   return returnValue;
}

// </Snippet1>
}
