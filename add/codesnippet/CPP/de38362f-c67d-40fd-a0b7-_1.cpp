      // Create a TextBox to add to the Panel.
   private:
      TextBox^ textBox1;

      // Add controls to the Panel using the Add method.
      void addButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         textBox1 = gcnew TextBox;
         panel1->Controls->Add( textBox1 );
      }