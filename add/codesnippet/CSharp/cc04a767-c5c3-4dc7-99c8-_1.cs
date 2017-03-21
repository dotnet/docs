    public ColorLabelActionList( IComponent component ) : base(component) 
    {
        this.colLabel = component as ColorLabel;

        // Cache a reference to DesignerActionUIService, so the
        // DesigneractionList can be refreshed.
        this.designerActionUISvc =
            GetService(typeof(DesignerActionUIService))
            as DesignerActionUIService;
    }