      // Display a message box. The Help button opens 
      // the Mspaint.chm Help file and shows the Help contents 
      // on the Index tab.
      System::Windows::Forms::DialogResult r3 = MessageBox::Show( "Message with Help file and Help navigator.", "Help Caption", MessageBoxButtons::OK, MessageBoxIcon::Question, MessageBoxDefaultButton::Button1, (MessageBoxOptions)0, "mspaint.chm", HelpNavigator::Index );