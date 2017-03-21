private:
   // The following three methods will draw a rectangle and allow 
   // the user to use the mouse to resize the rectangle.  If the 
   // rectangle intersects a control's client rectangle, the 
   // control's color will change.
   bool isDrag;
   Rectangle theRectangle;
   Point startPoint;
   void Form1_MouseDown( Object^ sender, System::Windows::Forms::MouseEventArgs^ e )
   {
      
      // Set the isDrag variable to true and get the starting point 
      // by using the PointToScreen method to convert form 
      // coordinates to screen coordinates.
      if ( e->Button == ::MouseButtons::Left )
      {
         isDrag = true;
      }

      Control^ control = dynamic_cast<Control^>(sender);
      
      // Calculate the startPoint by using the PointToScreen 
      // method.
      startPoint = control->PointToScreen( Point(e->X,e->Y) );
   }

   void Form1_MouseMove( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      
      // If the mouse is being dragged, 
      // undraw and redraw the rectangle as the mouse moves.
      if ( isDrag )
      {
         ControlPaint::DrawReversibleFrame( theRectangle, this->BackColor, FrameStyle::Dashed );
         
         // Calculate the endpoint and dimensions for the new 
         // rectangle, again using the PointToScreen method.
         Point endPoint = this->PointToScreen( Point(e->X,e->Y) );
         int width = endPoint.X - startPoint.X;
         int height = endPoint.Y - startPoint.Y;
         theRectangle = Rectangle(startPoint.X,startPoint.Y,width,height);
         
         // Draw the new rectangle by calling DrawReversibleFrame
         // again.  
         ControlPaint::DrawReversibleFrame( theRectangle, this->BackColor, FrameStyle::Dashed );
      }
   }

   void Form1_MouseUp( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ /*e*/ )
   {
      
      // If the MouseUp event occurs, the user is not dragging.
      isDrag = false;
      
      // Draw the rectangle to be evaluated. Set a dashed frame style 
      // using the FrameStyle enumeration.
      ControlPaint::DrawReversibleFrame( theRectangle, this->BackColor, FrameStyle::Dashed );
      
      // Find out which controls intersect the rectangle and 
      // change their color. The method uses the RectangleToScreen  
      // method to convert the Control's client coordinates 
      // to screen coordinates.
      Rectangle controlRectangle;
      for ( int i = 0; i < Controls->Count; i++ )
      {
         controlRectangle = Controls[ i ]->RectangleToScreen( Controls[ i ]->ClientRectangle );
         if ( controlRectangle.IntersectsWith( theRectangle ) )
         {
            Controls[ i ]->BackColor = Color::BurlyWood;
         }

      }
      
      // Reset the rectangle.
      theRectangle = Rectangle(0,0,0,0);
   }