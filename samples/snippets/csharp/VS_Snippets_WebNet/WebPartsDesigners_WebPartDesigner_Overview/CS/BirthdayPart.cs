// <Snippet1>
// <Snippet2>
using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.Design.WebControls.WebParts;
using System.ComponentModel;

/// <summary>
/// BirthdayPart demonstrates some of the most
/// common overrides of members of the WebPart
/// class. BirthdayPartDesigner shows how to 
/// customize the rendering of a custom WebPart
/// control.
/// </summary>
namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
  [Designer(typeof(BirthdayPartDesigner))]
  public class BirthdayPart : WebPart
  {
    private DateTime birthDate;
    Calendar input;
    Label displayContent;

    public BirthdayPart()
    {
      this.AllowClose = false;
      this.Title = "Enter your birthday";
    }

    [
      Personalizable(PersonalizationScope.User, true),
      WebBrowsable()
    ]
    public DateTime BirthDate
    {
      get { return birthDate; }
      set { birthDate = value; }
    }
    
    // Set the appearance of the control at run time.
    protected override void CreateChildControls()
    {
      Controls.Clear();
      input = new Calendar();
      this.Controls.Add(input);
      Button update = new Button();
      update.Text = "Submit";
      update.Click += new EventHandler(this.submit_Click);
      this.Controls.Add(update);
      displayContent = new Label();
      displayContent.BackColor = 
      System.Drawing.Color.LightBlue;
      Literal br = new Literal();
      br.Text = "<br />";
      if ((this.birthDate.Day == DateTime.Now.Day)
        && (this.birthDate.Month == DateTime.Now.Month))
      {
        displayContent.Text = "Happy Birthday!";
        this.Controls.Add(br);
        this.Controls.Add(displayContent);
      }
    }

    private void submit_Click(object sender, EventArgs e)
    {
      this.birthDate = input.SelectedDate;
    }
  }

  // </Snippet2>
  // <Snippet3>
  public class BirthdayPartDesigner : WebPartDesigner
  {
    public override void Initialize(IComponent component)
    {
      // Verify that the associated control is a BirthdayPart.
      if (!typeof(BirthdayPart).IsInstanceOfType(component))
      {
        throw new ArgumentException("The specified control is not of type 'BirthdayPart'", "component");
      }
      base.Initialize(component);
    }

    // Here is where you make customizations
    // to design time appearance that will not
    // be visible to the end user.
    public override string GetDesignTimeHtml()
    {
      string designTimeHtml = null;
      try
      {
        designTimeHtml = base.GetDesignTimeHtml();
        string s = "<hr /><hr />I just added these lines to the"
          + " bottom of the control.<hr /><hr /></div>";
        designTimeHtml = designTimeHtml.Replace("</div>", s);
      }
      catch (Exception ex)
      {
        designTimeHtml = GetErrorDesignTimeHtml(ex);
      }
      finally
      {
        // undo any changes in the try block
      }

      if ((designTimeHtml == null) || (designTimeHtml.Length == 0))
      {
        designTimeHtml = GetEmptyDesignTimeHtml();
      }
      return designTimeHtml;
    }

    // This method normally returns a blank string.
    // Override to return a meaningful message.
    protected override string GetEmptyDesignTimeHtml()
    {
      return CreatePlaceHolderDesignTimeHtml(
        "<hr />If the page developer forgot to fill in a " +
        "required property you could tell them here.<hr />");
    }
    
    // Add specific text to the generic error message.
    protected override string GetErrorDesignTimeHtml(Exception e)
    {
      string s = "<hr />The control failed to render.";
      return(s + e.Message + "<hr />");
    }
  }
}
// </Snippet3>
// </Snippet1>