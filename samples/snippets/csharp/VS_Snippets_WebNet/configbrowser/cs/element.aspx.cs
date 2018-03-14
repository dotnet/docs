using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
// <Snippet91>
using System.Web.UI.HtmlControls;
// </Snippet91>

public partial class Element : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    // <Snippet92>
    protected void ListView1_ItemDataBound(
        object sender, ListViewItemEventArgs e)
    {
        ElementItemHeaderInfo ei = e.Item.DataItem 
            as ElementItemHeaderInfo;

        ObjectDataSource ods = (ObjectDataSource)e.Item.FindControl("InnerObjectDataSource");
        ods.SelectParameters["sectionName"].DefaultValue = ei.SectionName;
        ods.SelectParameters["elementName"].DefaultValue = ei.Name;
        ods.SelectParameters["index"].DefaultValue = ei.Index.ToString();
        //propertiesListView.DataBind();
    }
    // </Snippet92>

    // <Snippet93>
    protected void ListView1_PreRender(object sender, EventArgs e)
    {
        string elementName =
            OuterObjectDataSource.SelectParameters["sectionName"].DefaultValue.ToString() +
            "/" +
            OuterObjectDataSource.SelectParameters["elementName"].DefaultValue.ToString();
        if (Request.QueryString["Section"] != null)
        {
            elementName = Request.QueryString["Section"] + "/" +
                Request.QueryString["Element"];
        }

        HeadingLabel.Text = HeadingLabel.Text.Replace("[name]", elementName);
        
        HtmlGenericControl tableCaption =
            ListView1.FindControl("ElementTableCaption")
            as System.Web.UI.HtmlControls.HtmlGenericControl;
        if (tableCaption != null)
        {
            tableCaption.InnerText = tableCaption.InnerText.Replace(
                    "[name]", elementName);
        }

        Label noElementsLabel = 
            ListView1.Controls[0].FindControl("NoElementsLabel") as Label;
        if (noElementsLabel != null)
        {
            noElementsLabel.Text = noElementsLabel.Text.Replace(
                "[name]", elementName);
        }
    }
    // </Snippet93>

    // <Snippet94>
    protected string GetElementHeaderID(ListViewItem item)
    {
        return "hdrElement" + item.DataItemIndex.ToString();
    }
    protected string GetPropertyHeaderID(ListViewItem item)
    {
        return "hdrProperty" +
            ((ElementItemInfo)item.DataItem).UniqueID;
    }
    // </Snippet94>

    // <Snippet95>
    protected string GetColumnHeaderIDs
        (ListViewDataItem item, string columnHeader)
    {
        string elementHeaderID =
            GetElementHeaderID
                ((ListViewItem)item.NamingContainer.NamingContainer);

        string propertyHeaderID = GetPropertyHeaderID(item);

        return string.Format("{0} {1} {2}",
            elementHeaderID, propertyHeaderID, columnHeader);
    }
    // </Snippet95>

}