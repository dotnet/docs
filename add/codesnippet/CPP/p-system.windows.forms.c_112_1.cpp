   void showSelectedButton_Click( Object^ sender, System::EventArgs^ e )
   {
      int selectedIndex = comboBox1->SelectedIndex;
      Object^ selectedItem = comboBox1->SelectedItem;
      MessageBox::Show( "Selected Item Text: " + selectedItem->ToString() + "\n" +
         "Index: " + selectedIndex.ToString() );
   }