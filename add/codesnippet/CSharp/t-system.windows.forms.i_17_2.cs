        // The ReplaceFlowDirectionMapping method replaces the  
        // default mapping for the FlowDirection property.
        private void ReplaceFlowDirectionMapping()
        {
            wfHost.PropertyMap.Remove("FlowDirection");

            wfHost.PropertyMap.Add(
                "FlowDirection",
                new PropertyTranslator(OnFlowDirectionChange));
        }

        // The OnFlowDirectionChange method translates a 
        // Windows Presentation Foundation FlowDirection value 
        // to a Windows Forms RightToLeft value and assigns
        // the result to the hosted control's RightToLeft property.
        private void OnFlowDirectionChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.FlowDirection fd = (System.Windows.FlowDirection)value;
            System.Windows.Forms.CheckBox cb = host.Child as System.Windows.Forms.CheckBox;

            cb.RightToLeft = (fd == System.Windows.FlowDirection.RightToLeft ) ? 
                RightToLeft.Yes : RightToLeft.No;
        }

        // The cb_CheckedChanged method handles the hosted control's
        // CheckedChanged event. If the Checked property is true,
        // the flow direction is set to RightToLeft, otherwise it is
        // set to LeftToRight.
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;

            wfHost.FlowDirection = ( cb.CheckState == CheckState.Checked ) ? 
                    System.Windows.FlowDirection.RightToLeft : 
                    System.Windows.FlowDirection.LeftToRight;
        }