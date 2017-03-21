        // Create the regions and design-time markup. Called by the designer host.
        public override String GetDesignTimeHtml(DesignerRegionCollection regions) {
            // Create 3 regions: 2 clickable headers and an editable row
            regions.Add(new DesignerRegion(this, "Header0"));
            regions.Add(new DesignerRegion(this, "Header1"));

            // Create an editable region and add it to the regions
            EditableDesignerRegion editableRegion = 
                new EditableDesignerRegion(this, 
                    "Content" + myControl.CurrentView, false);
            regions.Add(editableRegion);

            // Set the highlight for the selected region
            regions[myControl.CurrentView].Highlight = true;

            // Use the base class to render the markup
            return base.GetDesignTimeHtml();
        }