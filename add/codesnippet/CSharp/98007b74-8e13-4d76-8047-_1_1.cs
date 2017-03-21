    protected override void RenderPartContents(HtmlTextWriter writer, 
      WebPart part)
    {

        if (part == this.WebPartManager.SelectedWebPart)
          HttpContext.Current.Response.Write("<span>Not rendered</span>");
        else
          if(this.Zone.GetType() == typeof(MyZone))
            part.RenderControl(writer);
    }