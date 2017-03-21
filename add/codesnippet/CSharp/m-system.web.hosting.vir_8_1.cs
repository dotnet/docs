    public override VirtualDirectory GetDirectory(string virtualDir)
    {
      if (IsPathVirtual(virtualDir))
        return new SampleVirtualDirectory(virtualDir, this);
      else
        return Previous.GetDirectory(virtualDir);
    }