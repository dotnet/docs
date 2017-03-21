        protected override IComponent[] CreateComponentsCore(
            System.ComponentModel.Design.IDesignerHost host, 
            System.Collections.IDictionary defaultValues)
        {
            // Get the string we want to fill in the custom
            // user control.  If the user cancels out of the dialog,
            // return null or an empty array to signify that the 
            // tool creation was canceled.
            using (ToolboxItemDialog d = new ToolboxItemDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    string text = d.CreationText;

                    IComponent[] comps =
                        base.CreateComponentsCore(host, defaultValues);
                    // comps will have a single component: our data type.
                    ((UserControl1)comps[0]).LabelText = text;
                    return comps;
                }
                else
                {
                    return null;
                }
            }
        }