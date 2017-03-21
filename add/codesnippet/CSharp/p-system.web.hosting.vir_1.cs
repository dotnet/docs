    public override VirtualFile GetFile(string virtualPath)
    {
      if (IsPathVirtual(virtualPath))
        return new SampleVirtualFile(virtualPath, this);
      else
        return Previous.GetFile(virtualPath);
    }