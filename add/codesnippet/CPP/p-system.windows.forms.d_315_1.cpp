   // Updated the criteria label.
   void dataGridView_AutoSizeColumnModeChanged( Object^ /*sender*/, DataGridViewAutoSizeColumnModeEventArgs^ args )
   {
      args->Column->DataGridView->Parent->Controls[ L"flowlayoutpanel" ]->Controls[ criteriaLabel ]->Text = String::Concat( criteriaLabel, args->Column->AutoSizeMode );
   }