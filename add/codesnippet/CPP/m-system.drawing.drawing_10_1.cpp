private:
   void GetLastPointExample( PaintEventArgs^ /*e*/ )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( 20, 20, 100, 20 );
      PointF lastPoint = myPath->GetLastPoint();
      if ( lastPoint.IsEmpty == false )
      {
         String^ lastPointXString = lastPoint.X.ToString();
         String^ lastPointYString = lastPoint.Y.ToString();
         MessageBox::Show( String::Concat( lastPointXString, ", ", lastPointYString ) );
      }
      else
            MessageBox::Show( "lastPoint is empty" );
   }