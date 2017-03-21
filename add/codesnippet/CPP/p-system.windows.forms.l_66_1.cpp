private:
   void CreateTabStopList()
   {
      ListBox^ listBox1 = gcnew ListBox;
      listBox1->SetBounds( 20, 20, 100, 100 );
      for ( int x = 1; x < 20; x++ )
      {
         listBox1->Items->Add( String::Concat( "Item\t", x ) );
      }
      listBox1->UseTabStops = true;
      this->Controls->Add( listBox1 );
   }