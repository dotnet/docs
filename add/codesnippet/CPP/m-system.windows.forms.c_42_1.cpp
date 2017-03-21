   public:
      void EnableDoubleBuffering()
      {
         // Set the value of the double-buffering style bits to true.
         this->SetStyle( static_cast<ControlStyles>(ControlStyles::DoubleBuffer | ControlStyles::UserPaint | ControlStyles::AllPaintingInWmPaint), true );
         this->UpdateStyles();
      }