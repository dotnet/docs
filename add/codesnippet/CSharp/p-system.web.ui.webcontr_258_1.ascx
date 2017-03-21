    // Allows authorized user to change personalization scope.
    protected void Toggle_Scope_Button_Click(object sender, EventArgs e)
    {
        if (_manager.Personalization.CanEnterSharedScope)
        {
            _manager.Personalization.ToggleScope();
        }
        
    }