   // When the mouse hovers over Button3, two reversible lines are 
   // drawn using the corner coordinates of Button3, which are first 
   // converted to screen coordinates.
   void Button3_MouseHover( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(0,0) ), Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Top) ), Button3->PointToScreen( Point(Button1->ClientRectangle.Left,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
   }

   // When the mouse moves from Button3, the reversible lines are erased by
   // using the same coordinates as are used in the Button3_MouseHover method.
   void Button3_MouseLeave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(0,0) ), Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Top) ), Button3->PointToScreen( Point(Button3->ClientRectangle.Left,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
   }