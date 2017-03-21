    public SampleVirtualDirectory(string virtualDir, SamplePathProvider provider)
      : base(virtualDir)
    {
      spp = provider;
      GetData();
    }

    protected void GetData()
    {
      DataSet ds = spp.GetVirtualData();

      // Clean up the path to match data in resource file.
      string path = VirtualPath.Replace(HostingEnvironment.ApplicationVirtualPath, "");
      path = path.TrimEnd('/');

      // Get the virtual directory from the resource table.
      DataTable dirs = ds.Tables["resource"];
      DataRow[] rows = dirs.Select(
        String.Format("(name = '{0}') AND (type='dir')", path));

      // If the select returned a row, the directory exists.
      if (rows.Length > 0)
      {
        exists = true;

        // Get children from the resource table.
        // This technique works for small numbers of virtual resources.
        //   Sites with moderate to large numbers of virtual
        //   resources should choose a method that consumes fewer
        //   computer resources.
        DataRow[] childRows = dirs.Select(
          String.Format("parentPath = '{0}'", path));

        foreach (DataRow childRow in childRows)
        {
          string childPath = (string)childRow["path"];

          if (childRow["type"].ToString() == "dir")
          {
            SampleVirtualDirectory svd = new SampleVirtualDirectory(childPath, spp);
            children.Add(svd);
            directories.Add(svd);
          }
          else
          {
            SampleVirtualFile svf = new SampleVirtualFile(childPath, spp);
            children.Add(svf);
            files.Add(svf);
          }
        }
      }
    }