private:
   void ClickMyRadioButton()
   {
      // If Item1 is selected and radioButton2 
      // is checked, click radioButton1.
      if ( listBox1->Text == "Item1" && radioButton2->Checked )
      {
         radioButton1->PerformClick();
      }
   }