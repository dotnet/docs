// <snippet2>
namespace Samples.AspNet.CS.Controls
{
  using System;
  using System.Web;
  using System.Web.Security;
  using System.Security.Permissions;
  using System.Web.UI;
  using System.Web.UI.WebControls;
  using System.Web.UI.WebControls.WebParts;

  // <snippet3>
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public interface IZipCode
  {
    string ZipCode { get; set;}
  }
  // </snippet3>

  // <snippet4>
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class ZipCodeWebPart : WebPart, IZipCode
  {
    string zipCodeText = String.Empty;
    TextBox input;
    Button send;

    public ZipCodeWebPart()
    {
    }

    // Make the implemented property personalizable to save 
    // the Zip Code between browser sessions.
    [Personalizable()]
    public virtual string ZipCode
    {
      get { return zipCodeText; }
      set { zipCodeText = value; }
    }

    // This is the callback method that returns the provider.
    [ConnectionProvider("Zip Code")]
    public IZipCode ProvideIZipCode()
    {
      return this;
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();
      input = new TextBox();
      this.Controls.Add(input);
      send = new Button();
      send.Text = "Enter 5-digit Zip Code";
      send.Click += new EventHandler(this.submit_Click);
      this.Controls.Add(send);
    }

    private void submit_Click(object sender, EventArgs e)
    {
      if (input.Text != String.Empty)
      {
        zipCodeText = Page.Server.HtmlEncode(input.Text);
        input.Text = String.Empty;
      }
    }

  }
  // </snippet4>

  // <snippet5>
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class WeatherWebPart : WebPart
  {
    private IZipCode _provider;
    string _zipSearch;
    Label DisplayContent;

    // This method is identified by the ConnectionConsumer 
    // attribute, and is the mechanism for connecting with 
    // the provider. 
    [ConnectionConsumer("Zip Code")]
    public void GetIZipCode(IZipCode Provider)
    {
      _provider = Provider;
    }
    
    protected override void OnPreRender(EventArgs e)
    {
      EnsureChildControls();

      if (this._provider != null)
      {
        _zipSearch = _provider.ZipCode.Trim();
        DisplayContent.Text = "My Zip Code is:  " + _zipSearch;
      }
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();
      DisplayContent = new Label();
      this.Controls.Add(DisplayContent);
    }

  }
  // </snippet5>
}
// </snippet2>
