// <snippet1>
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
  // <snippet2>
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class TextDisplayWebPart : WebPart
  {
    private String _contentText = null;
    private String _fontStyle = null;
    TextBox input;
    Label DisplayContent;
    Literal lineBreak;

    // <snippet4>
    public override EditorPartCollection CreateEditorParts()
    {
      ArrayList editorArray = new ArrayList();
      TextDisplayEditorPart edPart = new TextDisplayEditorPart();
      edPart.ID = this.ID + "_editorPart1";
      editorArray.Add(edPart);
      EditorPartCollection editorParts = 
        new EditorPartCollection(editorArray);
      return editorParts;
    }

    public override object WebBrowsableObject
    {
      get { return this; }
    }
    // </snippet4>

    [Personalizable(), WebBrowsable]
    public String ContentText
    {
      get { return _contentText; }
      set { _contentText = value; }
    }

    [Personalizable(), WebBrowsable()]
    public String FontStyle
    {
      get { return _fontStyle; }
      set { _fontStyle = value; }
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();
      DisplayContent = new Label();
      DisplayContent.BackColor = Color.LightBlue;
      DisplayContent.Text = this.ContentText;
      if (FontStyle == null)
        FontStyle = "None";
      SetFontStyle(DisplayContent, FontStyle);
      this.Controls.Add(DisplayContent);

      lineBreak = new Literal();
      lineBreak.Text = @"<br />";
      Controls.Add(lineBreak);

      input = new TextBox();
      this.Controls.Add(input);
      Button update = new Button();
      update.Text = "Set Label Content";
      update.Click += new EventHandler(this.submit_Click);
      this.Controls.Add(update);

    }

    private void submit_Click(object sender, EventArgs e)
    {
      // Update the label string.
      if (input.Text != String.Empty)
      {
        _contentText = input.Text + @"<br />";
        input.Text = String.Empty;
        DisplayContent.Text = this.ContentText;
      }
    }

    private void SetFontStyle(Label label, String selectedStyle)
    {
      if (selectedStyle == "Bold")
      {
        label.Font.Bold = true;
        label.Font.Italic = false;
        label.Font.Underline = false;
      }
      else if (selectedStyle == "Italic")
      {
        label.Font.Italic = true;
        label.Font.Bold = false;
        label.Font.Underline = false;
      }
      else if (selectedStyle == "Underline")
      {
        label.Font.Underline = true;
        label.Font.Bold = false;
        label.Font.Italic = false;
      }
      else
      {
        label.Font.Bold = false;
        label.Font.Italic = false;
        label.Font.Underline = false;
      }
    }

    // <snippet3>
    // Create a custom EditorPart to edit the WebPart control.
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    private class TextDisplayEditorPart : EditorPart
    {
      DropDownList _partContentFontStyle;

      public TextDisplayEditorPart()
      {
        Title = "Font Face";
      }

      // <snippet5>
      public override bool ApplyChanges()
      {
        TextDisplayWebPart part = 
          (TextDisplayWebPart)WebPartToEdit;
        // Update the custom WebPart control with the font style.
        part.FontStyle = PartContentFontStyle.SelectedValue;

        return true;
      }
      // </snippet5>

      // <snippet6>
      public override void SyncChanges()
      {
        TextDisplayWebPart part = 
          (TextDisplayWebPart)WebPartToEdit;
        String currentStyle = part.FontStyle;

        // Select the current font style in the drop-down control.
        foreach (ListItem item in PartContentFontStyle.Items)
        {
          if (item.Value == currentStyle)
          {
            item.Selected = true;
            break;
          }
        }
      }
      // </snippet6>


      protected override void CreateChildControls()
      {
        Controls.Clear();

        // Add a set of font styles to the dropdown list.
        _partContentFontStyle = new DropDownList();
        _partContentFontStyle.Items.Add("Bold");
        _partContentFontStyle.Items.Add("Italic");
        _partContentFontStyle.Items.Add("Underline");
        _partContentFontStyle.Items.Add("None");

        Controls.Add(_partContentFontStyle);

      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
        writer.Write("<b>Text Content Font Style</b>");
        writer.WriteBreak();
        writer.Write("Select a font style.");
        writer.WriteBreak();
        _partContentFontStyle.RenderControl(writer);
        writer.WriteBreak();
      }

      // Access the drop-down control through a property.
      private DropDownList PartContentFontStyle
      {
        get 
        {
          EnsureChildControls();
          return _partContentFontStyle;
        }
      }
    }
    // </snippet3>
  }
  // </snippet2>
}
// </snippet1>
