    public override DesignerActionListCollection ActionLists
    {
        get
        {
            if (null == actionLists)
            {
                actionLists = new DesignerActionListCollection();
                actionLists.Add(
                    new ColorLabelActionList(this.Component));
            }
            return actionLists;
        }
    }