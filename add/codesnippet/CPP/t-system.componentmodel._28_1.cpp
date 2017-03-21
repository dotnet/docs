      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );

      // Displays each event's information in the collection in a text box.
      for each (EventDescriptor^ myEvent in events) {
          textBox1->Text += myEvent->Category + '\n';
          textBox1->Text += myEvent->Description + '\n';
          textBox1->Text += myEvent->DisplayName + '\n';
      }