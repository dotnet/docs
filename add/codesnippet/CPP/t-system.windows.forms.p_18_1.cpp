   // This example creates a PictureBox control on the form and draws to it.
   // This example assumes that the Form_Load event handler method is
   // connected to the Load event of the form.
private:
   PictureBox^ pictureBox1;
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      pictureBox1 = gcnew PictureBox;

      // Dock the PictureBox to the form and set its background to white.
      pictureBox1->Dock = DockStyle::Fill;
      pictureBox1->BackColor = Color::White;

      // Connect the Paint event of the PictureBox to the event handler method.
      pictureBox1->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::pictureBox1_Paint );

      // Add the PictureBox control to the Form.
      this->Controls->Add( pictureBox1 );
   }

   void pictureBox1_Paint( Object^ /*sender*/, System::Windows::Forms::PaintEventArgs^ e )
   {
      // Create a local version of the graphics object for the PictureBox.
      Graphics^ g = e->Graphics;

      // Draw a string on the PictureBox.
      g->DrawString( "This is a diagonal line drawn on the control",
         gcnew System::Drawing::Font( "Arial",10 ), System::Drawing::Brushes::Blue, Point(30,30) );

      // Draw a line in the PictureBox.
      g->DrawLine( System::Drawing::Pens::Red, pictureBox1->Left, pictureBox1->Top,
         pictureBox1->Right, pictureBox1->Bottom );
   }