    protected override WebPartVerbCollection GetWebPartVerbs(WebPart webPart)
    {
      ArrayList verbSet = new ArrayList();
      foreach (WebPartVerb verb in base.GetWebPartVerbs(webPart))
      {
        if (verb.Text != "Close")
          verbSet.Add(verb);
      }
      WebPartVerbCollection reducedVerbSet = 
        new WebPartVerbCollection(verbSet);
      return reducedVerbSet;
    }