using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class sitemapresolve1cs_aspx : System.Web.UI.Page
{
// <Snippet1>
    private void Page_Load(object sender, EventArgs e)
    {
        // The ExpandForumPaths method is called to handle
        // the SiteMapResolve event.
        SiteMap.SiteMapResolve +=
          new SiteMapResolveEventHandler(this.ExpandForumPaths);
    }

    private SiteMapNode ExpandForumPaths(Object sender, SiteMapResolveEventArgs e)
    {
        // The current node represents a Post page in a bulletin board forum.
        // Clone the current node and all of its relevant parents. This
        // returns a site map node that a developer can then
        // walk, modifying each node.Url property in turn.
        // Since the cloned nodes are separate from the underlying
        // site navigation structure, the fixups that are made do not
        // effect the overall site navigation structure.
        SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
        SiteMapNode tempNode = currentNode;

        // Obtain the recent IDs.
        int forumGroupID = GetMostRecentForumGroupID();
        int forumID = GetMostRecentForumID(forumGroupID);
        int postID = GetMostRecentPostID(forumID);

        // The current node, and its parents, can be modified to include
        // dynamic querystring information relevant to the currently
        // executing request.
        if (0 != postID)
        {
            tempNode.Url = tempNode.Url + "?PostID=" + postID.ToString();
        }

        if ((null != (tempNode = tempNode.ParentNode)) &&
            (0 != forumID))
        {
            tempNode.Url = tempNode.Url + "?ForumID=" + forumID.ToString();
        }

        if ((null != (tempNode = tempNode.ParentNode)) &&
            (0 != forumGroupID))
        {
            tempNode.Url = tempNode.Url + "?ForumGroupID=" + forumGroupID.ToString();
        }

        return currentNode;
    }
// </Snippet1>

// <Snippet2>
    // These methods are just placeholders for the example.
    // One option is to use the HttpContext or e.Context object
    // to obtain the ID.
    private int GetMostRecentForumGroupID()
    {
        return 24;
    }

    private int GetMostRecentForumID(int forumGroupId)
    {
        return 128;
    }

    private int GetMostRecentPostID(int forumId)
    {
        return 317424;
    }
// </Snippet2>
}
