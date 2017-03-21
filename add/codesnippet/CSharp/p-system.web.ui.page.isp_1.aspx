    private void Page_Load()
    {
        if (!IsPostBack)
        {
            // Validate initially to force asterisks
            // to appear before the first roundtrip.
            Validate();
        }
    }