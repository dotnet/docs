using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class sitemapnode2acs_aspx : System.Web.UI.Page
{
 private DataTable LoadSiteMapData() {
    return new DataTable();
 }

    private void Page_Load(object sender, System.EventArgs e)
    {

// <snippet1>
        // The LoadSiteMapData() method loads site navigation
        // data from persistent storage into a DataTable.
        DataTable siteMap = LoadSiteMapData();

        // Create a SiteMapNodeCollection.
        SiteMapNodeCollection nodes = new SiteMapNodeCollection();

        // Create a SiteMapNode and add it to the collection.
        SiteMapNode tempNode;
        DataRow row;
        int index = 0;

        while (index < siteMap.Rows.Count)
        {

            row = siteMap.Rows[index];

            // Create a node based on the data in the DataRow.
            tempNode = new SiteMapNode(SiteMap.Provider,
                                        row["Key"].ToString(),
                                        row["Url"].ToString());

            // Add the node to the collection.
            nodes.Add(tempNode);
            ++index;
        }
// </snippet1>
    }
}
