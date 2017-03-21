private:
   void Form1_FormClosing(Object^ sender, FormClosingEventArgs^ e)
   {
	  // If the no button was pressed ...
      if ((MessageBox::Show(
         "Are you sure that you would like to close the form?", 
         "Form Closing", MessageBoxButtons::YesNo, 
         MessageBoxIcon::Question) == DialogResult::No))
      {
		 // cancel the closure of the form.
         e->Cancel = true;
      }
   }
