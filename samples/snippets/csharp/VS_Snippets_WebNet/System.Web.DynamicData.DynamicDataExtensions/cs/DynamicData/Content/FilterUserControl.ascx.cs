using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

public partial class FilterUserControl : System.Web.DynamicData.FilterUserControlBase {
    public event EventHandler SelectedIndexChanged {
        add {
            DropDownList1.SelectedIndexChanged += value;
        }
        remove {
            DropDownList1.SelectedIndexChanged -= value;
        }
    }

    public override string SelectedValue {
        get {
            return DropDownList1.SelectedValue;
        }
    }

    protected void Page_Init(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            PopulateListControl(DropDownList1);

           // TextBox TB = new TextBox();
            //DropDownList ddlTmp = new DropDownList();
            //TB.Text = "12345678901234567890";

          //  DropDownList1.Width = ddlTmp.Width;


            for (int i = 0; i < DropDownList1.Items.Count; i++) {
                string s = DropDownList1.Items[i].Text;

                int maxLen = 44;
                for (int j = 0; j < s.Length; j++)
                    if (s[j] > 127) {
                        maxLen /= 2;
                        break;
                    }

                if (s.Length > maxLen) {
                    s = s.Substring(0, maxLen - 2);
                    s += " ... (see Details for full)";
                    DropDownList1.Items[i].Text = s;
                }
            }

            // Set the initial value if there is one
            if (!String.IsNullOrEmpty(InitialValue))
                DropDownList1.SelectedValue = InitialValue;
        }
    }
}
