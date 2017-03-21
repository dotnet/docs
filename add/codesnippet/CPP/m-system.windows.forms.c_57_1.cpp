   protected:
      virtual void SetClientSizeCore( int x, int y ) override
      {
         // Keep the client size square.
         if ( x > y )
         {
            UserControl::SetClientSizeCore( x, x );
         }
         else
         {
            UserControl::SetClientSizeCore( y, y );
         }
      }