        public void LinkToolboxComponentsCreatingEvent(ToolboxItem item)
        {
            item.ComponentsCreating += new ToolboxComponentsCreatingEventHandler(this.OnComponentsCreating);
        }
        
        private void OnComponentsCreating(object sender, ToolboxComponentsCreatingEventArgs e)
        {
            // Displays ComponentsCreating event information on the Console.
            Console.WriteLine("Name of the class of the root component of " +
            "the designer host receiving new components: " +
            e.DesignerHost.RootComponentClassName);
        }