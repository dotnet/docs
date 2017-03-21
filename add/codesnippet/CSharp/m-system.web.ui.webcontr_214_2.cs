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