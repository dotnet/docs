      // Create an instance of ServicedComponentProxy
      public override MarshalByRefObject CreateInstance(Type serverType)
      {  
         return base.CreateInstance(serverType);
      }