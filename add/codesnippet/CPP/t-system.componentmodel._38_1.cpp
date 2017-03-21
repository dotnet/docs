private:
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      textBox1->Text = "changed";
      System::ComponentModel::TypeDescriptor::Refreshed += gcnew System::ComponentModel::RefreshEventHandler( OnRefresh );
      System::ComponentModel::TypeDescriptor::GetProperties( textBox1 );
      System::ComponentModel::TypeDescriptor::Refresh( textBox1 );
   }

protected:
   static void OnRefresh( System::ComponentModel::RefreshEventArgs^ e )
   {
      Console::WriteLine( e->ComponentChanged );
   }