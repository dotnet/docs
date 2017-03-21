      // Add a GroupBox to a form and set some of its common properties.
   private:
      void AddMyGroupBox()
      {
         // Create a GroupBox and add a TextBox to it.
         GroupBox^ groupBox1 = gcnew GroupBox;
         TextBox^ textBox1 = gcnew TextBox;
         textBox1->Location = Point(15,15);
         groupBox1->Controls->Add( textBox1 );

         // Set the Text and Dock properties of the GroupBox.
         groupBox1->Text = "MyGroupBox";
         groupBox1->Dock = DockStyle::Top;

         // Disable the GroupBox (which disables all its child controls)
         groupBox1->Enabled = false;

         // Add the Groupbox to the form.
         this->Controls->Add( groupBox1 );
      }