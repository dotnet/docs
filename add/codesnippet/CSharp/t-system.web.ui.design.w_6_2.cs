namespace ASPNET.Examples.CS
{
    [SecurityPermission( 
    SecurityAction.Demand, 
    Flags = SecurityPermissionFlag.UnmanagedCode)] 
    public class SimpleGridViewDesigner : GridViewDesigner
    {
        private SimpleGridView simpleGView;

        public override string GetDesignTimeHtml()
        {
            string designTimeHtml = String.Empty;

            simpleGView = (SimpleGridView)Component;

            // Check the control's BorderStyle property to  
            // conditionally render design-time HTML.
            if (simpleGView.BorderStyle == BorderStyle.NotSet)
            {
                // Save the current property settings in variables.
                int oldCellPadding = simpleGView.CellPadding;
                Unit oldBorderWidth = simpleGView.BorderWidth;
                Color oldBorderColor = simpleGView.BorderColor;

                // Set properties and generate the design-time HTML.
                try
                {
                    simpleGView.Caption = "SimpleGridView";
                    simpleGView.CellPadding = 1;
                    simpleGView.BorderWidth = Unit.Pixel(3);
                    simpleGView.BorderColor = Color.Red;

                    designTimeHtml = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    // Get HTML from the GetErrorDesignTimeHtml 
                    // method if an exception occurs.
                    designTimeHtml = GetErrorDesignTimeHtml(ex);

                    // Return the properties to their original values.
                }
                finally
                {
                    simpleGView.CellPadding = oldCellPadding;
                    simpleGView.BorderWidth = oldBorderWidth;
                    simpleGView.BorderColor = oldBorderColor;
                }
            }
            else
                designTimeHtml = base.GetDesignTimeHtml();

            return designTimeHtml;
        }

        protected override string
            GetErrorDesignTimeHtml(System.Exception exc)
        {
            return CreatePlaceHolderDesignTimeHtml(
                "ASPNET.Examples: An error occurred while rendering the GridView.");

        }

        public override void Initialize(IComponent component)
        {
            simpleGView = (SimpleGridView)component;
            base.Initialize(component);
        }
    }
}