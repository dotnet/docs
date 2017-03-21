    protected override void RenderVerbs(HtmlTextWriter writer)
    {
      WebPartVerb[] verbs = new WebPartVerb[] { OKVerb, 
        CancelVerb, ApplyVerb };
      foreach (WebPartVerb verb in verbs)
      {
        if (verb != null)
          verb.Text += " Verb";
      }
      base.RenderVerbs(writer);
    }