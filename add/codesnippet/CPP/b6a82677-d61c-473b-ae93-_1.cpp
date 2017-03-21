private:
   void CreateARectangleFromLTRB( PaintEventArgs^ e )
   {
      Rectangle myRectangle = Rectangle::FromLTRB( 40, 40, 140, 240 );
      e->Graphics->DrawRectangle( SystemPens::ControlText, myRectangle );
   }