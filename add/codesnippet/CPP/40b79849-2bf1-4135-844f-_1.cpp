public:
   void SetLineCap_Example( PaintEventArgs^ e )
   {
      
      // Create a Pen object with a dash pattern.
      Pen^ capPen = gcnew Pen( Color::Black,5.0f );
      capPen->DashStyle = DashStyle::Dash;
      
      // Set the start and end caps for capPen.
      capPen->SetLineCap( LineCap::ArrowAnchor, LineCap::Flat, DashCap::Flat );
      
      // Draw a line with capPen.
      e->Graphics->DrawLine( capPen, 10, 10, 200, 10 );
   }