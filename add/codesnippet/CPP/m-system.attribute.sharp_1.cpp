   // Define a custom parameter attribute that takes a single message argument.

   [AttributeUsage(AttributeTargets::Parameter)]
   public ref class ArgumentUsageAttribute: public Attribute
   {
   protected:

      // usageMsg is storage for the attribute message.
      String^ usageMsg;

   public:

      // This is the attribute constructor.
      ArgumentUsageAttribute( String^ UsageMsg )
      {
         this->usageMsg = UsageMsg;
      }


      property String^ Message 
      {
         // This is the Message property for the attribute.
         String^ get()
         {
            return usageMsg;
         }

         void set( String^ value )
         {
            this->usageMsg = value;
         }
      }
   };