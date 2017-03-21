        // Get the content string for the selected region. Called by the designer host?
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region) 
        {
            // Get a reference to the designer host
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                ITemplate template = myControl.View1;
                if (region.Name == "Content1")
                    template = myControl.View2;

                // Persist the template in the design host
                if (template != null)
                    return ControlPersister.PersistTemplate(template, host);
            }

            return String.Empty;
        }