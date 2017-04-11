//<snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.Controls.CS {

    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    public class TextBoxSet : DataBoundControl {

        private IList alBoxSet;
        public IList BoxSet {
            get {
                if (null == alBoxSet) {
                     alBoxSet = new ArrayList();
                }
                return alBoxSet;                
            }                    
        }
//<snippet7>                
        public string DataTextField {
            get {
                object o = ViewState["DataTextField"];
                return((o == null) ? string.Empty : (string)o);
            }
            set {
                ViewState["DataTextField"] = value;
                if (Initialized) {
                    OnDataPropertyChanged();
                }
            }
        }
//</snippet7>
//<snippet3>        
        protected override void PerformSelect() {            

           // Call OnDataBinding here if bound to a data source using the
           // DataSource property (instead of a DataSourceID), because the
           // databinding statement is evaluated before the call to GetData.       
            if (! IsBoundUsingDataSourceID) {
                OnDataBinding(EventArgs.Empty);
            }            
            
            // The GetData method retrieves the DataSourceView object from  
            // the IDataSource associated with the data-bound control.            
            GetData().Select(CreateDataSourceSelectArguments(), 
                OnDataSourceViewSelectCallback);
            
            // The PerformDataBinding method has completed.
            RequiresDataBinding = false;
            MarkAsDataBound();
            
            // Raise the DataBound event.
            OnDataBound(EventArgs.Empty);
        }
//</snippet3>
//<snippet4>
        private void OnDataSourceViewSelectCallback(IEnumerable retrievedData) {
        
           // Call OnDataBinding only if it has not already been 
           // called in the PerformSelect method.
            if (IsBoundUsingDataSourceID) {
                OnDataBinding(EventArgs.Empty);
            }
            // The PerformDataBinding method binds the data in the  
            // retrievedData collection to elements of the data-bound control.
            PerformDataBinding(retrievedData);                                    
        }
//</snippet4>        
//<snippet5>
        protected override void PerformDataBinding(IEnumerable retrievedData) {
            base.PerformDataBinding(retrievedData);

            // If the data is retrieved from an IDataSource as an 
            // IEnumerable collection, attempt to bind its values to a 
            // set of TextBox controls.
            if (retrievedData != null) {

                foreach (object dataItem in retrievedData) {
                    
                    TextBox box = new TextBox();
                    
                    // The dataItem is not just a string, but potentially
                    // a System.Data.DataRowView or some other container. 
                    // If DataTextField is set, use it to determine which 
                    // field to render. Otherwise, use the first field.                    
                    if (DataTextField.Length > 0) {
                        box.Text = DataBinder.GetPropertyValue(dataItem, 
                            DataTextField, null);
                    }
                    else {
                        PropertyDescriptorCollection props = 
                            TypeDescriptor.GetProperties(dataItem);

                        // Set the "default" value of the TextBox.
                        box.Text = String.Empty;
                        
                        // Set the true data-bound value of the TextBox,
                        // if possible.
                        if (props.Count >= 1) {                        
                            if (null != props[0].GetValue(dataItem)) {
                                box.Text = props[0].GetValue(dataItem).ToString();
                            }
                        }
                    }                                        
                    
                    BoxSet.Add(box);
                }
            }
        }
//</snippet5>                
//<snippet6>
        protected override void Render(HtmlTextWriter writer) {

            // Render nothing if the control is empty.            
            if (BoxSet.Count <= 0) {
                return;
            }

            // Make sure the control is declared in a form tag 
            // with runat=server.
            if (Page != null) {
                Page.VerifyRenderingInServerForm(this);
            }
            
            // For this example, render the BoxSet as 
            // an unordered list of TextBox controls.            
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            foreach (object item in BoxSet) {
                 
                TextBox box = (TextBox) item;
                
                // Write each element as 
                // <li><input type="text" value="string"><input/></li>
                
                writer.WriteBeginTag("li");
                writer.Write(">");
                writer.WriteBeginTag("input");
                writer.WriteAttribute("type", "text");
                writer.WriteAttribute("value", box.Text);
                writer.Write(">");
                writer.WriteEndTag("input");
                writer.WriteEndTag("li");
            }            

            writer.RenderEndTag();                       
        }
//</snippet6>       
    }
}
//</snippet2>