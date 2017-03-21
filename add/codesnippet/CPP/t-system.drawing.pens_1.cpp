private:
   void UsePensClass( PaintEventArgs^ e )
   {
      e->Graphics->DrawEllipse( Pens::SlateBlue, Rectangle(40,40,140,140) );
   }