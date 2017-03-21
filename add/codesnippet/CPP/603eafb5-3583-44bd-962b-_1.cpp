   protected:
      virtual void SetBoundsCore( int x, int y, int width, int height, BoundsSpecified specified ) override
      {
         // Set a fixed height and width for the control.
         UserControl::SetBoundsCore( x, y, 150, 75, specified );
      }