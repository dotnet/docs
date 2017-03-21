  // This property implements the IWebActionable interface.
  WebPartVerbCollection IWebActionable.Verbs
  {
    get
    {
      if (m_Verbs == null)
      {
        ArrayList verbsList = new ArrayList();
        WebPartVerb onlyVerb = new WebPartVerb
          ("customVerb1", new WebPartEventHandler(IncrementVerbCounterClicks));
        onlyVerb.Text = "My Verb";
        onlyVerb.Description = "VerbTooltip";
        onlyVerb.Visible = true;
        onlyVerb.Enabled = true;
        verbsList.Add(onlyVerb);
        WebPartVerb otherVerb = new WebPartVerb
          ("customVerb2", new WebPartEventHandler(IncrementVerbCounterClicks));
        otherVerb.Text = "My other Verb";
        otherVerb.Description = "Other VerbTooltip";
        otherVerb.Visible = true;
        otherVerb.Enabled = true;
        verbsList.Add(otherVerb);
        m_Verbs = new WebPartVerbCollection(verbsList);
        return m_Verbs;
      }
      return m_Verbs;
    }
  }