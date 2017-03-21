private:
   void button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      monthCalendar1->RemoveAllBoldedDates();
      monthCalendar1->UpdateBoldedDates();
      listBox1->Items->Clear();
      button3->Enabled = false;
   }