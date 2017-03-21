public:
   property IClientChannelSink^ NextChannelSink 
   {
      virtual IClientChannelSink^ get()
      {
         return (nextSink);
      }
   }