// <Snippet1>
using System;
using System.Configuration.Provider;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Security.Permissions;
using System.Web;

namespace Samples.AspNet.CS
{

  [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
  public class SimpleTextSiteMapProvider : SiteMapProvider
  {
    private SiteMapProvider parentSiteMapProvider = null;
    private string simpleTextProviderName = null;
    private string sourceFilename = null;
    private SiteMapNode rootNode = null;
    private ArrayList siteMapNodes = null;
    private ArrayList childParentRelationship = null;


    // A default constructor. The Name property is initialized in the
    // Initialize method.
    public SimpleTextSiteMapProvider()
    {
    }
    // <Snippet2>
    // Implement the CurrentNode property.
    public override SiteMapNode CurrentNode
    {
      get
      {
        string currentUrl = FindCurrentUrl();
        // Find the SiteMapNode that represents the current page.
        SiteMapNode currentNode = FindSiteMapNode(currentUrl);
        return currentNode;
      }
    }

    // Implement the RootNode property.
    public override SiteMapNode RootNode
    {
      get
      {
        return rootNode;
      }
    }
    // </Snippet2>
    // <Snippet4>
    // Implement the ParentProvider property.
    public override SiteMapProvider ParentProvider
    {
      get
      {
        return parentSiteMapProvider;
      }
      set
      {
        parentSiteMapProvider = value;
      }
    }

    // Implement the RootProvider property.
    public override SiteMapProvider RootProvider
    {
      get
      {
        // If the current instance belongs to a provider hierarchy, it
        // cannot be the RootProvider. Rely on the ParentProvider.
        if (this.ParentProvider != null)
        {
          return ParentProvider.RootProvider;
        }
        // If the current instance does not have a ParentProvider, it is
        // not a child in a hierarchy, and can be the RootProvider.
        else
        {
          return this;
        }
      }
    }
    // </Snippet4>
    // <Snippet5>
    // Implement the FindSiteMapNode method.
    public override SiteMapNode FindSiteMapNode(string rawUrl)
    {

      // Does the root node match the URL?
      if (RootNode.Url == rawUrl)
      {
        return RootNode;
      }
      else
      {
        SiteMapNode candidate = null;
        // Retrieve the SiteMapNode that matches the URL.
        lock (this)
        {
          candidate = GetNode(siteMapNodes, rawUrl);
        }
        return candidate;
      }
    }
    // </Snippet5>
    // <Snippet6>
    // Implement the GetChildNodes method.
    public override SiteMapNodeCollection GetChildNodes(SiteMapNode node)
    {
      SiteMapNodeCollection children = new SiteMapNodeCollection();
      // Iterate through the ArrayList and find all nodes that have the specified node as a parent.
      lock (this)
      {
        for (int i = 0; i < childParentRelationship.Count; i++)
        {

          string nodeUrl = ((DictionaryEntry)childParentRelationship[i]).Key as string;

          SiteMapNode parent = GetNode(childParentRelationship, nodeUrl);

          if (parent != null && node.Url == parent.Url)
          {
            // The SiteMapNode with the Url that corresponds to nodeUrl
            // is a child of the specified node. Get the SiteMapNode for
            // the nodeUrl.
            SiteMapNode child = FindSiteMapNode(nodeUrl);
            if (child != null)
            {
              children.Add(child as SiteMapNode);
            }
            else
            {
              throw new Exception("ArrayLists not in sync.");
            }
          }
        }
      }
      return children;
    }
    // <Snippet3>
    protected override SiteMapNode GetRootNodeCore()
    {
      return RootNode;
    }
    // </Snippet3>
    // Implement the GetParentNode method.
    public override SiteMapNode GetParentNode(SiteMapNode node)
    {
      // Check the childParentRelationship table and find the parent of the current node.
      // If there is no parent, the current node is the RootNode.
      SiteMapNode parent = null;
      lock (this)
      {
        // Get the Value of the node in childParentRelationship
        parent = GetNode(childParentRelationship, node.Url);
      }
      return parent;
    }
    // </Snippet6>
    // <Snippet7>

    // Implement the ProviderBase.Initialize property.
    // Initialize is used to initialize the state that the Provider holds, but
    // not actually build the site map.
    public override void Initialize(string name, NameValueCollection attributes)
    {

      lock (this)
      {

        base.Initialize(name, attributes);

        simpleTextProviderName = name;
        sourceFilename = attributes["siteMapFile"];
        siteMapNodes = new ArrayList();
        childParentRelationship = new ArrayList();

        // Build the site map in memory.
        LoadSiteMapFromStore();
      }
    }
    // </Snippet7>
    // Private helper methods

    // <Snippet8>
    private SiteMapNode GetNode(ArrayList list, string url)
    {
      for (int i = 0; i < list.Count; i++)
      {
        DictionaryEntry item = (DictionaryEntry)list[i];
        if ((string)item.Key == url)
          return item.Value as SiteMapNode;
      }
      return null;
    }

    // Get the URL of the currently displayed page.
    private string FindCurrentUrl()
    {
      try
      {
        // The current HttpContext.
        HttpContext currentContext = HttpContext.Current;
        if (currentContext != null)
        {
          return currentContext.Request.RawUrl;
        }
        else
        {
          throw new Exception("HttpContext.Current is Invalid");
        }
      }
      catch (Exception e)
      {
        throw new NotSupportedException("This provider requires a valid context.",e);
      }
    }
    // </Snippet8>
    // <Snippet9>
    protected virtual void LoadSiteMapFromStore()
    {
      string pathToOpen;

      lock (this)
      {
        // If a root node exists, LoadSiteMapFromStore has already
        // been called, and the method can return.
        if (rootNode != null)
        {
          return;
        }
        else
        {
          pathToOpen = HttpContext.Current.Server.MapPath("~" + "\\" + sourceFilename);

          if (File.Exists(pathToOpen))
          {
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(pathToOpen))
            {

              // Clear the state of the collections and rootNode
              rootNode = null;
              siteMapNodes.Clear();
              childParentRelationship.Clear();

              // Parse the file and build the site map
              string s = "";
              string[] nodeValues = null;
              SiteMapNode temp = null;

              while ((s = sr.ReadLine()) != null)
              {

                // Build the various SiteMapNode objects and add
                // them to the ArrayList collections. The format used
                // is: URL,TITLE,DESCRIPTION,PARENTURL

                nodeValues = s.Split(',');

                temp = new SiteMapNode(this,
                    HttpRuntime.AppDomainAppVirtualPath + "/" + nodeValues[0],
                    HttpRuntime.AppDomainAppVirtualPath + "/" + nodeValues[0],
                    nodeValues[1],
                    nodeValues[2]);

                // Is this a root node yet?
                if (null == rootNode &&
                    (null == nodeValues[3] || nodeValues[3] == String.Empty))
                {
                  rootNode = temp;
                }

              // If not the root node, add the node to the various collections.
                else
                {
                  siteMapNodes.Add(new DictionaryEntry(temp.Url, temp));
                  // The parent node has already been added to the collection.
                  SiteMapNode parentNode =
                           FindSiteMapNode(HttpRuntime.AppDomainAppVirtualPath + "/" + nodeValues[3]);
                  if (parentNode != null)
                  {
                    childParentRelationship.Add(new DictionaryEntry(temp.Url, parentNode));
                  }
                  else
                  {
                    throw new Exception("Parent node not found for current node.");
                  }
                }
              }
            }
          }
          else
          {
            throw new Exception("File not found");
          }
        }
      }
      return;
    }
    // </Snippet9>
  }

}
// </Snippet1>