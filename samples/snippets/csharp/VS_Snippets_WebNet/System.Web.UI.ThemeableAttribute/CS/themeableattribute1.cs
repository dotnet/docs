// <Snippet1>
namespace Samples.AspNet.CS.Controls {
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    public class SomeDataBoundControl : DataBoundControl
    {
        // Implementation of a custom data source control.
        
        [Themeable(false) ]
        [IDReferenceProperty()]
        public override string DataSourceID {
            get {
                return base.DataSourceID;
            }
            set {
                base.DataSourceID = value;
            }
        }
        
    }
}
// </Snippet1>