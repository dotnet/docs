   // This method initializes ColorDialog1 to allow any colors, 
   // and combination colors on systems with 256 colors or less, 
   // but will not allow the user to set custom colors.  The
   // dialog will contain the help button.
   void InitializeColorDialog()
   {
      this->ColorDialog1 = gcnew System::Windows::Forms::ColorDialog;
      this->ColorDialog1->AllowFullOpen = false;
      this->ColorDialog1->AnyColor = true;
      this->ColorDialog1->SolidColorOnly = false;
      this->ColorDialog1->ShowHelp = true;
      
      // Associate the event-handling method with
      // the HelpRequest event.
      this->ColorDialog1->HelpRequest +=
         gcnew System::EventHandler( this, &Form1::ColorDialog1_HelpRequest );
   }

   // This method opens the dialog and checks the DialogResult value. 
   // If the result is OK, the text box's background color will be changed 
   // to the user-selected color.
   void Button1_Click( System::Object^ sender, System::EventArgs^ e )
   {
      ::DialogResult result = ColorDialog1->ShowDialog();
      if ( result == ::DialogResult::OK )
      {
         TextBox1->BackColor = ColorDialog1->Color;
      }
   }

   // This method is called when the HelpRequest event is raised, 
   //which occurs when the user clicks the Help button on the ColorDialog object.
   void ColorDialog1_HelpRequest( Object^ sender, System::EventArgs^ e )
   {
      MessageBox::Show( "Please select a color by clicking it. " +
         "This will change the BackColor property of the TextBox." );
   }