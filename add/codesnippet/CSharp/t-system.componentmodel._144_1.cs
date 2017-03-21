        public ResolveNameEventArgs CreateResolveNameEventArgs(object value, string name)        
        {           
            ResolveNameEventArgs e = new ResolveNameEventArgs(name);
            // The name to resolve                       e.Name       
            // Stores an object matching the name        e.Value            
            return e;
        }