   public:
      bool DoubleBufferingEnabled()
      {
         
         // Get the value of the double-buffering style bits.
         return this->GetStyle( static_cast<ControlStyles>(ControlStyles::DoubleBuffer | ControlStyles::UserPaint | ControlStyles::AllPaintingInWmPaint) );
      }