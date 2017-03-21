   [DefaultProperty("MyProperty")]
   ref class MyControl: public Control
   {
   public:

      property int MyProperty 
      {
         int get()
         {
            // Insert code here.
            return 0;
         }

         void set( int value )
         {
            // Insert code here.
         }
      }
      // Insert any additional code.
   };