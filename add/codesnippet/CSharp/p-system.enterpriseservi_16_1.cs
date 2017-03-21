    protected override void Activate()
    {
        MessageBox.Show( String.Format("Now entering...\nApplication: {0}\nInstance: {1}\nContext: {2}\n",
                                       ContextUtil.ApplicationId.ToString(), ContextUtil.ApplicationInstanceId.ToString(),
                                       ContextUtil.ContextId.ToString() ) );
    }