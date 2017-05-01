//C:\_ricka08\code\DD\Walk\DataType\DynamicData\FieldTemplates\Text.ascx.cs
// C:\sdtree\Orcas\Web.NET\System.ComponentModel.DataAnnotations2
// <snippet2>
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
using System.ComponentModel.DataAnnotations;

public partial class TextField : System.Web.DynamicData.FieldTemplateUserControl {

    string getNavUrl() {

        var metadata = MetadataAttributes.OfType<DataTypeAttribute>().FirstOrDefault();
        if (metadata == null)
            return FieldValueString; 

        switch (metadata.DataType) {

            case DataType.Url:
                string url = FieldValueString;
                if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    return url;

                return "http://" + FieldValueString;


            case DataType.EmailAddress:
                return "mailto:" + FieldValueString;

            default:
                throw new Exception("Unknown DataType");
        }
    }

    protected override void OnDataBinding(EventArgs e) {
        base.OnDataBinding(e);

        if (string.IsNullOrEmpty(FieldValueString))
            return;

        var metadata = MetadataAttributes.OfType<DataTypeAttribute>().FirstOrDefault();

        if (metadata == null || string.IsNullOrEmpty(FieldValueString)) {
            Literal literal = new Literal();
            literal.Text = FieldValueString;
            Controls.Add(literal);
            return;
        }

        if (metadata.DataType == DataType.Url ||
            metadata.DataType == DataType.EmailAddress) {

            HyperLink hyperlink = new HyperLink();
            hyperlink.Text = FieldValueString;
            hyperlink.NavigateUrl = getNavUrl();
            hyperlink.Target = "_blank";
            Controls.Add(hyperlink);
            return;
        }

        if (metadata.DataType == DataType.Custom &&
           string.Compare(metadata.CustomDataType, "BoldRed", true) == 0) {
            Label lbl = new Label();
            lbl.Text = FieldValueString;
            lbl.Font.Bold = true;
            lbl.ForeColor = System.Drawing.Color.Red;
            Controls.Add(lbl);
        }

    }

}
// </snippet2>
