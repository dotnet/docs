   void AddMyScrollEventHandlers()
   {
      // Create and initialize a VScrollBar.
      VScrollBar^ vScrollBar1 = gcnew VScrollBar;

      // Add event handlers for the OnScroll and OnValueChanged events.
      vScrollBar1->Scroll += gcnew ScrollEventHandler( this, &Form1::vScrollBar1_Scroll );
      vScrollBar1->ValueChanged += gcnew EventHandler( this, &Form1::vScrollBar1_ValueChanged );
   }

   // Create the ValueChanged event handler.
   void vScrollBar1_ValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Display the new value in the label.
      label1->Text = String::Format( "vScrollBar Value:(OnValueChanged Event) {0}", vScrollBar1->Value );
   }

   // Create the Scroll event handler.
   void vScrollBar1_Scroll( Object^ /*sender*/, ScrollEventArgs^ e )
   {
      // Display the new value in the label.
      label1->Text = String::Format( "VScrollBar Value:(OnScroll Event) {0}", e->NewValue );
   }

   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Add 40 to the Value property if it will not exceed the Maximum value.
      if ( vScrollBar1->Value + 40 < vScrollBar1->Maximum )
      {
         vScrollBar1->Value = vScrollBar1->Value + 40;
      }
   }