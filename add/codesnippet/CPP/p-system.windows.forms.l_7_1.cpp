   void ListBox1_SelectedValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      textBox1->Text="";
      if ( ListBox1->SelectedIndex != -1 )
            textBox1->Text = ListBox1->SelectedValue->ToString();
   }