    // Boolean properties are automatically displayed with binary 
    // UI (such as a checkbox).
    public bool LockColors
    {
        get
        {
            return colLabel.ColorLocked;
        }
        set
        {
            GetPropertyByName("ColorLocked").SetValue(colLabel, value);

            // Refresh the list.
            this.designerActionUISvc.Refresh(this.Component);
        }
    }