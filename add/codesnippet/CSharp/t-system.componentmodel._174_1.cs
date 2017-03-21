        public void LinkResolveNameEvent(
                IDesignerSerializationManager serializationManager)
        {
            // Registers an event handler for the ResolveName event.
            serializationManager.ResolveName += 
                new ResolveNameEventHandler(this.OnResolveName);
        }

        private void OnResolveName(object sender, ResolveNameEventArgs e)
        {                        
            // Displays ResolveName event information on the console. 
            Console.WriteLine("Name of the name to resolve: "+e.Name);
            Console.WriteLine("ToString output of the object that no name was resolved for: "+e.Value.ToString());            
        }