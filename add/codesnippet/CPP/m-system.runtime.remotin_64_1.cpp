   // Create an instance of ServicedComponentProxy
   virtual MarshalByRefObject^ CreateInstance( Type^ serverType ) override
   {
      return ProxyAttribute::CreateInstance( serverType );
   }