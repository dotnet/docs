private:
   void PopulateListBoxWithGraphicsResolution()
   {
      Graphics^ boxGraphics = listBox1->CreateGraphics();

      // Graphics* formGraphics = this->CreateGraphics();
      listBox1->Items->Add( String::Format( "ListBox horizontal resolution: {0}", boxGraphics->DpiX ) );
      listBox1->Items->Add( String::Format( "ListBox vertical resolution: {0}", boxGraphics->DpiY ) );
      delete boxGraphics;
   }