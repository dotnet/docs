using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls 
{    
    // <Snippet1>
    // This class implements a custom data source control.
    public class SomeDataBoundControl : DataBoundControl
    {
        [ IDReferencePropertyAttribute() ]        
        new public string DataSourceID {
            get {
                return base.DataSourceID;
            }
            set {
                base.DataSourceID = value;
            }
        }
    }
    // </Snippet1>
}
