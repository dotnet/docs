        // Create a template from the content string and  
        // put it in the selected view.
        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
                return;

            // Get a reference to the designer host
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                // Create a template from the content string
                ITemplate template = ControlParser.ParseTemplate(host, content);

                // Determine which region should get the template
                // Either 'Content0' or 'Content1'
                if (region.Name.EndsWith("0"))
                    myControl.View1 = template;
                else if (region.Name.EndsWith("1"))
                    myControl.View2 = template;
            }
        }