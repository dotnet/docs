public:
   void ConstructAdjArrowCap1( PaintEventArgs^ e )
   {
      AdjustableArrowCap^ myArrow = gcnew AdjustableArrowCap( 6,6 );
      Pen^ capPen = gcnew Pen( Color::Black );
      capPen->CustomStartCap = myArrow;
      capPen->CustomEndCap = myArrow;
      e->Graphics->DrawLine( capPen, 50, 50, 200, 50 );
   }