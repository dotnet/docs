    public override DesignerActionItemCollection GetSortedActionItems()
    {
        DesignerActionItemCollection items = new DesignerActionItemCollection();

        //Define static section header entries.
        items.Add(new DesignerActionHeaderItem("Appearance"));
        items.Add(new DesignerActionHeaderItem("Information"));

        //Boolean property for locking color selections.
        items.Add(new DesignerActionPropertyItem("LockColors",
                         "Lock Colors", "Appearance",
                         "Locks the color properties."));
        if (!LockColors)
        {
            items.Add(new DesignerActionPropertyItem("BackColor",
                             "Back Color", "Appearance",
                             "Selects the background color."));
            items.Add(new DesignerActionPropertyItem("ForeColor",
                             "Fore Color", "Appearance",
                             "Selects the foreground color."));

            //This next method item is also added to the context menu 
            // (as a designer verb).
            items.Add(new DesignerActionMethodItem(this,
                             "InvertColors", "Invert Colors",
                             "Appearance",
                             "Inverts the fore and background colors.",
                              true));
        }
        items.Add(new DesignerActionPropertyItem("Text",
                         "Text String", "Appearance",
                         "Sets the display text."));

        //Create entries for static Information section.
        StringBuilder location = new StringBuilder("Location: ");
        location.Append(colLabel.Location);
        StringBuilder size = new StringBuilder("Size: ");
        size.Append(colLabel.Size);
        items.Add(new DesignerActionTextItem(location.ToString(),
                         "Information"));
        items.Add(new DesignerActionTextItem(size.ToString(),
                         "Information"));

        return items;
    }