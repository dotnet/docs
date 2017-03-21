public:
   virtual Stream^ ChainStream( Stream^ stream ) override
   {
      oldStream = stream;
      newStream = gcnew MemoryStream;
      return newStream;
   }