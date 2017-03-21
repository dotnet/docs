  void IRegisteredObject.Stop(bool immediate)
  {
    foreach (SampleComponent c in components)
    {
      ((IRegisteredObject)c).Stop(immediate);
    }
    HostingEnvironment.UnregisterObject(this);
  }