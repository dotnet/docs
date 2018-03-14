// <snippet5>
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class UserInfoWebPart : WebPart
  {
    HttpServerUtility server = HttpContext.Current.Server;
    private String _userNickName = "Add a nickname.";
    private String _userPetName = "Add a pet name.";
    private DateTime _userSpecialDate = DateTime.Now;
    private Boolean _userIsCurrent = true;
    private JobTypeName _userJobType = JobTypeName.Unselected;
    public enum JobTypeName
    {
      Unselected = 0,
      Support = 1,
      Service = 2,
      Professional = 3, 
      Technical = 4,
      Manager = 5,
      Executive = 6
    }
    Label NickNameLabel;
    Label PetNickNameLabel;
    Label SpecialDateLabel;
    CheckBox IsCurrentCheckBox;
    Label JobTypeLabel;

    // Add the Personalizable and WebBrowsable attributes to the  
    // public properties, so that users can save property values  
    // and edit them with a PropertyGridEditorPart control.
    [Personalizable(), WebBrowsable, WebDisplayName("Nickname")]
    public String NickName
    {
      get 
      { 
        object o = ViewState["NickName"];
        if (o != null)
          return (string)o;
        else
          return _userNickName;        
      } 

      set { _userNickName = server.HtmlEncode(value); }
    }

    [Personalizable(), WebBrowsable, WebDisplayName("Pet Name")]
    public String PetName
    {
      get 
      { 
        object o = ViewState["PetName"];
        if (o != null)
          return (string)o;
        else
          return _userPetName;        
      }

      set { _userPetName = server.HtmlEncode(value); }
    }

    [Personalizable(), WebBrowsable(), WebDisplayName("Special Day")]
    public DateTime SpecialDay
    {
      get
      {
        object o = ViewState["SpecialDay"];
        if (o != null)
          return (DateTime)o;
        else
          return _userSpecialDate;
        
      }

      set { _userSpecialDate = value; }
    }

    // <snippet6>
    [Personalizable(), WebBrowsable(), WebDisplayName("Job Type"), 
      WebDescription("Select the category that corresponds to your job.")]
    public JobTypeName UserJobType
    {
      get
      {
        object o = ViewState["UserJobType"];
        if (o != null)
          return (JobTypeName)o;
        else
          return _userJobType;
      }

      set { _userJobType = (JobTypeName)value; }
    }
    // </snippet6>

    [Personalizable(), WebBrowsable(), WebDisplayName("Is Current")]
    public Boolean IsCurrent
    {
      get
      {
        object o = ViewState["IsCurrent"];
        if (o != null)
          return (Boolean)o;
        else
          return _userIsCurrent;
      }

      set { _userIsCurrent = value; }
    }


    protected override void CreateChildControls()
    {
      Controls.Clear();

      NickNameLabel = new Label();
      NickNameLabel.Text = this.NickName;
      SetControlAttributes(NickNameLabel);

      PetNickNameLabel = new Label();
      PetNickNameLabel.Text = this.PetName;
      SetControlAttributes(PetNickNameLabel);

      SpecialDateLabel = new Label();
      SpecialDateLabel.Text = this.SpecialDay.ToShortDateString();
      SetControlAttributes(SpecialDateLabel);

      IsCurrentCheckBox = new CheckBox();
      IsCurrentCheckBox.Checked = this.IsCurrent;
      SetControlAttributes(IsCurrentCheckBox);

      JobTypeLabel = new Label();
      JobTypeLabel.Text = this.UserJobType.ToString();
      SetControlAttributes(JobTypeLabel);

      ChildControlsCreated = true;

    }

    private void SetControlAttributes(WebControl ctl)
    {
      ctl.BackColor = Color.White;
      ctl.BorderWidth = 1;
      ctl.Width = 200;
      this.Controls.Add(ctl);
    }

    protected override void RenderContents(HtmlTextWriter writer)
    {
      writer.Write("Nickname:");
      writer.WriteBreak();
      NickNameLabel.RenderControl(writer);
      writer.WriteBreak();
      writer.Write("Pet Name:");
      writer.WriteBreak();
      PetNickNameLabel.RenderControl(writer);
      writer.WriteBreak();
      writer.Write("Special Date:");
      writer.WriteBreak();
      SpecialDateLabel.RenderControl(writer);
      writer.WriteBreak();
      writer.Write("Job Type:");
      writer.WriteBreak();
      JobTypeLabel.RenderControl(writer);
      writer.WriteBreak();
      writer.Write("Current:");
      writer.WriteBreak();
      IsCurrentCheckBox.RenderControl(writer);
    }
  }
}
// </snippet5>
