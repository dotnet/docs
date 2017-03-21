    // Derive a class from the HyperLinkDataBindingHandler. It will 
    // resolve  data binding for the CustomHyperlink at design time.
    public class CustomHyperLinkDataBindingHandler : 
        HyperLinkDataBindingHandler
    {
        // Override the DataBindControl to set property values in  
        // the DataBindingCollection at design time.
        public override void DataBindControl(IDesignerHost designerHost, 
            Control control)
        {
            DataBindingCollection bindings = 
                ((IDataBindingsAccessor)control).DataBindings;
            DataBinding imageBinding = bindings["ImageUrl"];

               // If Text is empty, supply a default value.
            if (!(imageBinding == null))
            {
                CustomHyperLink hype = (CustomHyperLink)control;
                hype.ImageUrl = "Image URL.";
            }

            // Call the base method to bind the control.
            base.DataBindControl(designerHost, control);
        } // DataBindControl
    } // CustomHyperLinkDataBindingHandler