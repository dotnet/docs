// <Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using System.IO;

namespace ControlDesignerSamples.CS
{
    // <Snippet2>
    // Define a simple text control, derived from the 
    // System.Web.UI.WebControls.Label class.
    [
        Designer(typeof(TextControlDesigner))
    ]
    public class SimpleTextControl : Label
    {
        // Define a private member to store the file name value in the control.
        private string _filename = "";
        private string _internalText = "";

        // Define the public XML schema file property.  Indicate that the
        // property can be edited at design-time with the XsdSchemaFileEditor class.
        [EditorAttribute(typeof(System.Web.UI.Design.XsdSchemaFileEditor), 
                         typeof(System.Drawing.Design.UITypeEditor))]
        public string SchemaFileName
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        // Define a property that returns the timestamp
        // for the selected file.
        public string LastChanged
        {
            get
            {
                if ((_filename != null) && (_filename.Length > 0))
                {
                    if (File.Exists(_filename))
                    {
                        DateTime lastChangedStamp = File.GetLastWriteTime(_filename);
                        return lastChangedStamp.ToLongDateString();
                    }
                }
                return "";
            }
            
        }

        // Override the control Text property, setting the default
        // text to the LastChanged string value for the selected
        // file name.  If the file name has not been set in the
        // design view, then default to an empty string.
        public override string Text
        {
            get
            {
                if ((_internalText == "") && (LastChanged.Length > 0))
                {
                    // If the internally stored value hasn't been set,
                    // and the file name property has been set,
                    // return the last changed timestamp for the file.
                    _internalText = LastChanged;
                } 
                return _internalText;
            }

            set
            {
                if ((value != null) && (value.Length > 0))
                {
                    _internalText = value;
                }
                else {
                    _internalText = "";
                }
            }
        }
    }
    // </Snippet2>

}
// </Snippet1>