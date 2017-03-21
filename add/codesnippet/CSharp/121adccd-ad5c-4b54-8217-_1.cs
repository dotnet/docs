        // Handler for the Click event, which provides the region in the arguments.
        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            if (e.Region == null)
                return;

            // If the clicked region is not a header, return
            if (e.Region.Name.IndexOf("Header") != 0)
                return;

            // Switch the current view if required
            if (e.Region.Name.Substring(6, 1) != myControl.CurrentView.ToString())
            {
                myControl.CurrentView = int.Parse(e.Region.Name.Substring(6, 1));
                base.UpdateDesignTimeHtml();
            }
        }