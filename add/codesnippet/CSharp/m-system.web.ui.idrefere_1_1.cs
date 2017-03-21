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