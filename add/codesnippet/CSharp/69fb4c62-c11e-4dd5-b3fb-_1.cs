            // When you double-click on an AnchorGlyph, the value of 
            // the control's Anchor property is toggled.
            //
            // Note that the value of the Anchor property is not set
            // by direct assignment. Instead, the 
            // PropertyDescriptor.SetValue method is used. This 
            // enables notification of the design environment, so 
            // related events can be raised, for example, the
            // IComponentChangeService.ComponentChanged event.

            public override bool OnMouseDoubleClick(
                Glyph g, 
                MouseButtons button, 
                Point mouseLoc)
            {
                base.OnMouseDoubleClick(g, button, mouseLoc);

                if (button == MouseButtons.Left)
                {
                    AnchorGlyph ag = g as AnchorGlyph;
                    PropertyDescriptor pdAnchor = 
                        TypeDescriptor.GetProperties(ag.relatedControl)["Anchor"];

                    if (ag.IsEnabled)
                    {
                        // The glyph is enabled. 
                        // Clear the AnchorStyle flag to disable the Glyph.
                        pdAnchor.SetValue(
                            ag.relatedControl, 
                            ag.relatedControl.Anchor ^ ag.anchorStyle );
                    }
                    else
                    {
                        // The glyph is disabled. 
                        // Set the AnchorStyle flag to enable the Glyph.
                        pdAnchor.SetValue(
                            ag.relatedControl,
                            ag.relatedControl.Anchor | ag.anchorStyle);
                    }

                }

                return true;
            }