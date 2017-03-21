  // Resets all of a user and shared personalization data for the page.
    protected void Reset_CurrentState_Button_Click(object src, EventArgs e)
    {
        // User must be authorized to modify state before a reset can occur.
        //When in user scope, all users by default can change their own data.
        if (_manager.Personalization.IsModifiable)
        {
            _manager.Personalization.ResetPersonalizationState();
        }
    }