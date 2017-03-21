public:
   void Clone_Example( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ myPen = gcnew Pen( Color::Black,5.0f );
      
      // Clone myPen.
      Pen^ clonePen = dynamic_cast<Pen^>(myPen->Clone());
      
      // Draw a line with clonePen.
      e->Graphics->DrawLine( clonePen, 0, 0, 100, 100 );
   }