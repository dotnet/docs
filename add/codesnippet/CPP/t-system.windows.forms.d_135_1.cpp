   void WatchRowsModeChanges( Object^ /*sender*/, DataGridViewAutoSizeModeEventArgs^ modeEvent )
   {
      Label^ label = dynamic_cast<Label^>(flowLayoutPanel1->Controls[ currentLayoutName ]);
      if ( modeEvent->PreviousModeAutoSized )
      {
         label->Text = String::Format( "changed to a different {0}{1}", label->Name, dataGridView1->AutoSizeRowsMode );
      }
      else
      {
         label->Text = String::Concat( label->Name, dataGridView1->AutoSizeRowsMode );
      }
   }

