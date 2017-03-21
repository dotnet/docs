public:
   property Image^ MyImage 
   {
      [Description("The image associated with the control"),Category("Appearance")]
      Image^ get()
      {
         // Insert code here.
         return image1;
      }

      void set( Image^ value )
      {
         // Insert code here.
      }
   }