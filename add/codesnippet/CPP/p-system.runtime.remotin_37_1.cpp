public:
   property IClientChannelSinkProvider^ Next 
   {
      virtual IClientChannelSinkProvider^ get()
      {
         return (nextProvider);
      }

      virtual void set( IClientChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }