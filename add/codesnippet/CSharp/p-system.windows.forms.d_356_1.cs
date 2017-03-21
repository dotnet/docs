        // The AnchorGlyph objects should mimic the resize glyphs;
        // they should only be visible when the control is the 
        // primary selection. The adorner is enabled when the 
        // control is the primary selection and disabled when 
        // it is not.

        void selectionService_SelectionChanged(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(
                this.selectionService.PrimarySelection,
                this.relatedControl))
            {
                this.ComputeBounds();
                this.anchorAdorner.Enabled = true;
            }
            else
            {
                this.anchorAdorner.Enabled = false;
            }
        }