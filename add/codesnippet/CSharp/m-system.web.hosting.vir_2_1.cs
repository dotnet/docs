    public SampleVirtualFile(string virtualPath, SamplePathProvider provider)
      : base(virtualPath)
    {
      this.spp = provider;
      GetData();
    }

    protected void GetData()
    {
      // Get the data from the SamplePathProvider
      DataSet ds = spp.GetVirtualData();

      // Get the virtual file from the resource table.
      DataTable files = ds.Tables["resource"];
      DataRow[] rows = files.Select(
        String.Format("(name = '{0}') AND (type='file')", this.Name));

      // If the select returned a row, store the file contents.
      if (rows.Length > 0)
      {
        DataRow row = rows[0];

        content = row["content"].ToString();
      }
    }