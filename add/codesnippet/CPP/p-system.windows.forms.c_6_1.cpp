private:
   void AdjustMyCheckBoxProperties()
   {
      // Concatenate the property values together on three lines.
      label1->Text = String::Format( "ThreeState: {0}\nChecked: {1}\nCheckState: {2}",
         checkBox1->ThreeState, checkBox1->Checked, checkBox1->CheckState );
      
      // Change the ThreeState and CheckAlign properties on every other click.
      if ( !checkBox1->ThreeState )
      {
         checkBox1->ThreeState = true;
         checkBox1->CheckAlign = ContentAlignment::MiddleRight;
      }
      else
      {
         checkBox1->ThreeState = false;
         checkBox1->CheckAlign = ContentAlignment::MiddleLeft;
      }
   }