   private:
      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Sets the ShowApply property, then displays the dialog.
         fontDialog1->ShowApply = true;
         fontDialog1->ShowDialog();
      }

      void fontDialog1_Apply( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Applies the selected font to the selected text.
         richTextBox1->Font = fontDialog1->Font;
      }