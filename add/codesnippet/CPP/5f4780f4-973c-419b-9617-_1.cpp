   void showHelp_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display Help using the Help navigator enumeration
      // that is selected in the combo box. Some enumeration
      // values make use of an extra parameter, which can
      // be passed in through the Parameter text box.
      HelpNavigator navigator = HelpNavigator::TableOfContents;
      if ( navigatorCombo->SelectedItem != nullptr )
      {
         navigator =  *safe_cast<HelpNavigator^>(navigatorCombo->SelectedItem);
      }

      Help::ShowHelp( this, helpfile, navigator, parameterTextBox->Text );
   }