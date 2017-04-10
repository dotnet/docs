// <Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;

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

        // Define the public file name property.  Indicate that the
        // property can be edited at design-time with the MailFileEditor class.
        [EditorAttribute(typeof(System.Web.UI.Design.MailFileEditor), 
                         typeof(System.Drawing.Design.UITypeEditor))]
        public string MailFileName
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
                    if (System.IO.File.Exists(_filename))
                    {
                        DateTime lastChangedStamp = System.IO.File.GetLastWriteTime(_filename);
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