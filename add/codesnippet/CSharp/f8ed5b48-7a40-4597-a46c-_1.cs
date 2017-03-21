    protected override void OnSelectedWebPartChanged(object sender, 
      WebPartEventArgs e)
    {
      if (e.WebPart != null)
        e.WebPart.Zone.SelectedPartChromeStyle.BackColor = 
          Color.LightGreen;
      base.OnSelectedWebPartChanged(sender, e);
    }