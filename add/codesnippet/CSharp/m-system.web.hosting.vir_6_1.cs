    public override bool FileExists(string virtualPath)
    {
      if (IsPathVirtual(virtualPath))
      {
        SampleVirtualFile file = (SampleVirtualFile)GetFile(virtualPath);
        return file.Exists;
      }
      else
        return Previous.FileExists(virtualPath);
    }