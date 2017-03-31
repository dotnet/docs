// <Snippet3>
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

public partial class TextField : 
    System.Web.DynamicData.FieldTemplateUserControl {

    protected override void OnDataBinding(EventArgs e)
    {
        base.OnDataBinding(e);
        bool processed = false;
        var metadata = MetadataAttributes.OfType
            <DataTypeAttribute>().FirstOrDefault();
        if (metadata != null)
        {
            if (metadata.DataType == DataType.EmailAddress)
            {
                if (!string.IsNullOrEmpty(FieldValueString))
                {
                    processed = true;
                    HyperLink hyperlink = new HyperLink();
                    hyperlink.Text = FieldValueString;
                    hyperlink.NavigateUrl = "mailto:" + FieldValueString;
                    Controls.Add(hyperlink);
                }
            }
        }
        if (!processed)
        {
            Literal literal = new Literal();
            literal.Text = FieldValueString;
            Controls.Add(literal);
        }
    }

}
// </Snippet3>