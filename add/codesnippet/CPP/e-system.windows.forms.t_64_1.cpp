   void showColorValueLabels()
   {
      label1->Text = String::Format( "Red value is : {0}", trackBar1->Value );
      label3->Text = String::Format( "Green Value is : {0}", trackBar2->Value );
      label2->Text = String::Format( "Blue Value is : {0}", trackBar3->Value );
   }

   void trackBar_Scroll( Object^ sender, System::EventArgs^ /*e*/ )
   {
      System::Windows::Forms::TrackBar^ myTB;
      myTB = dynamic_cast<System::Windows::Forms::TrackBar^>(sender);
      panel1->BackColor = Color::FromArgb( trackBar1->Value, trackBar2->Value, trackBar3->Value );
      myTB->Text = String::Format( "Value is {0}", myTB->Value );
      showColorValueLabels();
   }
