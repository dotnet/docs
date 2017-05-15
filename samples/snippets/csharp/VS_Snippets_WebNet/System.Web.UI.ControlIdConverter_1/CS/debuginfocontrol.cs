// <Snippet1>
namespace Samples.AspNet.CS {

  using System;
  using System.ComponentModel;
  using System.Web.UI;
  using System.Web.UI.WebControls;


  [DefaultProperty("ControlID")]
  public class DebugInfoControl : Control {

    public DebugInfoControl() {
    }

    public DebugInfoControl(string controlID) {
      ControlID = controlID;
    }

    [DefaultValue(""),
    TypeConverter(typeof(ControlIDConverter))]
    public string ControlID {
      get {
        object o = ViewState["ControlID"];
        if (o == null)
          return String.Empty;
        return (string)o;
      }
      set {
        if (ControlID != value) {
          ViewState["ControlID"] = value;
        }
      }
    }

    protected override void Render(HtmlTextWriter writer) {

      Label info = new Label();

      if (this.ControlID.Length == 0) {
        writer.Write("<Font Color='Red'>No ControlID set.</Font>");
      }

      Control ctrl = this.FindControl(ControlID);


      if (ctrl == null) {
        writer.Write("<Font Color='Red'>Could not find control " +  ControlID + " in Naming Container.</Font>");
      }
      else {
        writer.Write("<Font Color='Green'>Control " + ControlID + " found.<BR>");
        writer.Write("Its Naming Container is: " + ctrl.NamingContainer.ID + "<BR>");
        if (ctrl.EnableViewState)
          writer.Write("It uses view state to persist its state.<BR>");

        if (ctrl.EnableTheming)
          writer.Write("It can be assigned a Theme ID.<BR>");

        if (ctrl.Visible)
          writer.Write("It is visible on the page.<BR>");
        else
          writer.Write("It is not visible on the page.<BR>");

        writer.Write("</Font>");

      }
    }
  }
}
// </Snippet1>