private:
   void MenuSelected( Object^ sender, System::EventArgs^ /*e*/ )
   {
      if ( sender == menuOpen )
            statusBar1->Panels[ 0 ]->Text = "Opens a file to edit";
      else
      if ( sender == menuSave )
            statusBar1->Panels[ 0 ]->Text = "Saves the current file";
      else
      if ( sender == menuExit )
            statusBar1->Panels[ 0 ]->Text = "Exits the application";
      else
            statusBar1->Panels[ 0 ]->Text = "Ready";
   }