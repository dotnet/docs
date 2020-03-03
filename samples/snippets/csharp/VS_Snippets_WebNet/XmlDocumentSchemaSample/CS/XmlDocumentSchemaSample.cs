using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

/// <summary>
/// Summary description for XmlDocumentSchemaSample
/// </summary>
public class XmlDocumentSchemaSample
{
    //<Snippet1>
    // This method fills a TreeView Web control from an XML file.
    public void FillTreeView(TreeView treeVw, string fileName)
    {
        // Get a reference to the current HttpContext
        HttpContext currentContext = HttpContext.Current;
        int i, j, k;
        TreeNode CurNode, NewNode;

        // Create and load an XML document
        XmlDocument XDoc = new XmlDocument();
        XDoc.Load(currentContext.Server.MapPath(fileName));

        // Get a map of the XML Document
        XmlDocumentSchema xSchema = new XmlDocumentSchema(XDoc, "");

        // Get a list of the root child views
        IDataSourceViewSchema[] RootViews = xSchema.GetViews();

        // Add each child to the TreeView
        for (i = 0; i < RootViews.Length; i++)
        {
            NewNode = new TreeNode(RootViews[i].Name);
            treeVw.Nodes.Add(NewNode);
            CurNode = treeVw.Nodes[i];

            // Get a list of children of this child
            IDataSourceViewSchema[] ChildViews = RootViews[i].GetChildren();
            // Add each child to the child node of the TreeView
            for (j = 0; j < ChildViews.Length; j++)
            {
                NewNode = new TreeNode(ChildViews[j].Name);
                CurNode.ChildNodes.Add(NewNode);
                CurNode = CurNode.ChildNodes[j];

                // Get a list of children of this child
                IDataSourceViewSchema[] ChildVws = ChildViews[j].GetChildren();
                // Add each child to the child node
                for (k = 0; k < ChildVws.Length; k++)
                {
                    NewNode = new TreeNode(ChildVws[k].Name);
                    CurNode.ChildNodes.Add(NewNode);
                }
                // Select the parent of the current child
                CurNode = CurNode.Parent;
            }
            // Select the parent of the current child
            CurNode = CurNode.Parent;
        }
    }
    //</Snippet1>
}
