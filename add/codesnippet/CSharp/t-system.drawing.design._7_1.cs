        public void LinkToolboxComponentsCreatedEvent(ToolboxItem item)
        {
            item.ComponentsCreated += new ToolboxComponentsCreatedEventHandler(this.OnComponentsCreated);
        }

        private void OnComponentsCreated(object sender, ToolboxComponentsCreatedEventArgs e)
        {
            // Lists created components on the Console.
            for( int i=0; i< e.Components.Length; i++ )
                Console.WriteLine("Component #"+i.ToString()+": "+e.Components[i].Site.Name.ToString());            
        }