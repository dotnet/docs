      // Create two RadioButtons to add to the Panel.
   private:
      RadioButton^ radioAddButton;
      RadioButton^ radioRemoveButton;

      // Add controls to the Panel using the AddRange method.
      void addRangeButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         radioAddButton = gcnew RadioButton;
         radioRemoveButton = gcnew RadioButton;
         
         // Set the Text the RadioButtons will display.
         radioAddButton->Text = "radioAddButton";
         radioRemoveButton->Text = "radioRemoveButton";
         
         // Set the appropriate location of radioRemoveButton.
         radioRemoveButton->Location = System::Drawing::Point( radioAddButton->Location.X, radioAddButton->Location.Y + radioAddButton->Height );
         
         //Add the controls to the Panel.
         array<Control^>^controlArray = {radioAddButton,radioRemoveButton};
         panel1->Controls->AddRange( controlArray );
      }