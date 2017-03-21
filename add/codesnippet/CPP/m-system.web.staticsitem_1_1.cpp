   // Clean up any collections or other state that an instance of this may hold.
   virtual void Clear() override
   {
      System::Threading::Monitor::Enter( this );
      try
      {
         rootNode = nullptr;
         StaticSiteMapProvider::Clear();
      }
      finally
      {
         System::Threading::Monitor::Exit( this );
      }

   }


public:
