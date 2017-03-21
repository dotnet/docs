    public override bool DirectoryExists(string virtualDir)
    {
      if (IsPathVirtual(virtualDir))
      {
        SampleVirtualDirectory dir = (SampleVirtualDirectory)GetDirectory(virtualDir);
        return dir.Exists;
      }
      else
        return Previous.DirectoryExists(virtualDir);
    }