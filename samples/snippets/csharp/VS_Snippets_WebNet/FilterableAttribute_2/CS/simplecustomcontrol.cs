// <Snippet1>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{
    public class SimpleCustomControl : WebControl
    {
        private string _productID;

        // Set Filterable attribute to specify that this
        // property does not support device filtering.
        [Bindable(true)]
        [Filterable(false)]
        public string ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }
    }
}

// </Snippet1>
