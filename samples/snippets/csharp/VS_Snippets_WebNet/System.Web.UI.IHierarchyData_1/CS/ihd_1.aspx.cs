using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ihd_1_aspx : System.Web.UI.Page
{
    // <Snippet3>
    private void Page_Load(object sender, System.EventArgs e)
    {
        IHierarchicalEnumerable ihe = (IHierarchicalEnumerable)SiteMap.RootNode.ChildNodes;
        IEnumerator enumeration = ihe.GetEnumerator();

        while (enumeration.MoveNext())
        {
            // Print out SiteMapNode Titles.
            IHierarchyData hierarchicalNode = ihe.GetHierarchyData(enumeration.Current);
            PrintFullChildNodeInfo(hierarchicalNode);
        }
    }
    // </Snippet3>
    // <Snippet2>
    // Print out the the current data node, then iterate through its
    // children and do the same.
    private void PrintFullChildNodeInfo(IHierarchyData node)
    {
        string whitespace = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string br = "<BR>";

        Response.Write(node.ToString() + br);
        Response.Write(whitespace + node.Path + br);

        // Check for specific types and perform extended functions.
        if (node.Type == "SiteMapNode")
        {
            // Because SiteMapNode implements the IHierarchyData interface,
            // the IHierarchyData object can be cast directly as a SiteMapNode,
            // rather than accessing the Item property for the object that
            // the Type property identifies.
            SiteMapNode siteNode = node.Item as SiteMapNode;
            Response.Write(whitespace + siteNode.Url + br);
            Response.Write(whitespace + siteNode.Description + br);
        }
        else if (node.Type == "SomeBusinessObject")
        {
            // If the IHierarchyData instance is a wrapper class on a business
            // object of some kind, you can retrieve the business object by using
            // the IHierarchyData.Item property.
            //          SomeBusinessObject busObj = node.Item as SomeBusinessObject;
        }

        if (node.HasChildren)
        {
            IEnumerator children = ((IHierarchicalEnumerable)node.GetChildren()).GetEnumerator();

            while (children.MoveNext())
            {
                // Print out SiteMapNode Titles recursively.
                IHierarchyData hierarchicalNode = node.GetChildren().GetHierarchyData(children.Current);
                PrintFullChildNodeInfo(hierarchicalNode);
            }
        }
    }
    // </Snippet2>
}
