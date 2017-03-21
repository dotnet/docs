public:
   void IsOutlineVisibleExample( PaintEventArgs^ e )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Rectangle rect = Rectangle(20,20,100,100);
      myPath->AddRectangle( rect );
      Pen^ testPen = gcnew Pen( Color::Black,20.0f );
      myPath->Widen( testPen );
      e->Graphics->FillPath( Brushes::Black, myPath );
      bool visible = myPath->IsOutlineVisible( 100, 50, testPen, e->Graphics );
      MessageBox::Show( String::Format( "visible = {0}", visible ) );
   }