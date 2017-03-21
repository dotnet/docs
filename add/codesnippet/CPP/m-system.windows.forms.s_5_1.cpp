   private:
      void Form1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         Point p = Point(e->X,e->Y);
         Screen^ s = Screen::FromPoint( p );
         if ( s->Primary )
         {
            MessageBox::Show( "You clicked the primary screen" );
         }
         else
         {
            MessageBox::Show( "This isn't the primary screen" );
         }