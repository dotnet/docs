using System.Web.Hosting;

public class SampleComponentFactory : IRegisteredObject
{
  private ArrayList components = new ArrayList();

  public void Start()
  {
    HostingEnvironment.RegisterObject(this);
  }

  void IRegisteredObject.Stop(bool immediate)
  {
    foreach (SampleComponent c in components)
    {
      ((IRegisteredObject)c).Stop(immediate);
    }
    HostingEnvironment.UnregisterObject(this);
  }

  public SampleComponent CreateComponent()
  {
    SampleComponent newComponent = new SampleComponent();
    newComponent.Initialize();
    components.Add(newComponent);
    return newComponent;
  }
}

public class SampleComponent : IRegisteredObject
{
  void IRegisteredObject.Stop(bool immediate)
  {
    // Clean up component resources here.
  }
  
  public void Initialize()
  {
    // Initialize component here.
  }
}