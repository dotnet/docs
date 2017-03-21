        public ToolboxComponentsCreatedEventArgs CreateToolboxComponentsCreatedEventArgs(System.ComponentModel.IComponent[] components)
        {
            ToolboxComponentsCreatedEventArgs e = new ToolboxComponentsCreatedEventArgs(components);
            // The components that were just created        e.Components            
            return e;
        }