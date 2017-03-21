    // Toolbox items must be serializable.
    [Serializable]
    class MyToolboxItem : ToolboxItem
    {
        // The add components dialog in Visual Studio looks for a public
        // constructor that takes a type.
        public MyToolboxItem(Type toolType)
            : base(toolType)
        {
        }

        // And you must provide this special constructor for serialization.
        // If you add additional data to MyToolboxItem that you
        // want to serialize, you may override Deserialize and
        // Serialize methods to add that data.  
        MyToolboxItem(SerializationInfo info, StreamingContext context)
        {
            Deserialize(info, context);
        }

        // Let's override the creation code and pop up a dialog.
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
    }