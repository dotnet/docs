   // Handle the Form's Paint event to draw a 3D three-dimensional 
   // raised border just inside the border of the frame.
   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      Rectangle borderRectangle = this->ClientRectangle;
      borderRectangle.Inflate(  -10, -10 );
      ControlPaint::DrawBorder3D( e->Graphics, borderRectangle, Border3DStyle::Raised );
   }