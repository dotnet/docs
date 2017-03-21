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