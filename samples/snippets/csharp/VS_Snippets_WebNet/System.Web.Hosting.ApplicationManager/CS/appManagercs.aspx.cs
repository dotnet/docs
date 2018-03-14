using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// <Snippet1>
using System.Web.Hosting;

public class SampleComponentFactory : IRegisteredObject
{
  private ArrayList components = new ArrayList();

  // <Snippet2>
  public void Start()
  {
    HostingEnvironment.RegisterObject(this);
  }
  // </Snippet2>

  // <Snippet3>
  void IRegisteredObject.Stop(bool immediate)
  {
    foreach (SampleComponent c in components)
    {
      ((IRegisteredObject)c).Stop(immediate);
    }
    HostingEnvironment.UnregisterObject(this);
  }
  // </Snippet3>

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
// </Snippet1>
public partial class appManagercs : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    
  }
}