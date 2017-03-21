private:
   bool myVal;

public:
   [DefaultValue(false)]
   property bool MyProperty 
   {
      bool get()
      {
         return myVal;
      }

      void set( bool value )
      {
         myVal = value;
      }
   }