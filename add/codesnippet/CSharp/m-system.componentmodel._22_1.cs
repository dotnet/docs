    // This utility method connects the designer to various
    // services it will use. 
    private void InitializeServices()
    {
        // Acquire a reference to DesignerActionService.
        this.actionService =
            GetService(typeof(DesignerActionService))
            as DesignerActionService;

		// Acquire a reference to DesignerActionUIService.
		this.actionUiService =
			GetService(typeof(DesignerActionUIService))
			as DesignerActionUIService;

        // Acquire a reference to IComponentChangeService.
        this.changeService =
            GetService(typeof(IComponentChangeService))
            as IComponentChangeService;

        // Hook the IComponentChangeService events.
        if (this.changeService != null)
        {
            this.changeService.ComponentChanged +=
                new ComponentChangedEventHandler(
                ChangeService_ComponentChanged);

            this.changeService.ComponentAdded +=
                new ComponentEventHandler(
                ChangeService_ComponentAdded);

            this.changeService.ComponentRemoved +=
                new ComponentEventHandler(
                changeService_ComponentRemoved);
        }

        // Acquire a reference to ISelectionService.
        this.selectionService =
            GetService(typeof(ISelectionService))
            as ISelectionService;

        // Hook the SelectionChanged event.
        if (this.selectionService != null)
        {
            this.selectionService.SelectionChanged +=
                new EventHandler(selectionService_SelectionChanged);
        }

        // Acquire a reference to IDesignerEventService.
        this.eventService =
            GetService(typeof(IDesignerEventService))
            as IDesignerEventService;

        if (this.eventService != null)
        {
            this.eventService.ActiveDesignerChanged +=
                new ActiveDesignerEventHandler(
                eventService_ActiveDesignerChanged);
        }

        // Acquire a reference to IDesignerHost.
        this.host =
            GetService(typeof(IDesignerHost))
            as IDesignerHost;

        // Acquire a reference to IDesignerOptionService.
        this.optionService =
            GetService(typeof(IDesignerOptionService))
            as IDesignerOptionService;

        // Acquire a reference to IEventBindingService.
        this.eventBindingService =
            GetService(typeof(IEventBindingService))
            as IEventBindingService;

        // Acquire a reference to IExtenderListService.
        this.listService =
            GetService(typeof(IExtenderListService))
            as IExtenderListService;

        // Acquire a reference to IReferenceService.
        this.referenceService =
            GetService(typeof(IReferenceService))
            as IReferenceService;

        // Acquire a reference to ITypeResolutionService.
        this.typeResService =
            GetService(typeof(ITypeResolutionService))
            as ITypeResolutionService;

        // Acquire a reference to IComponentDiscoveryService.
        this.componentDiscoveryService =
            GetService(typeof(IComponentDiscoveryService))
            as IComponentDiscoveryService;

        // Acquire a reference to IToolboxService.
        this.toolboxService =
            GetService(typeof(IToolboxService))
            as IToolboxService;

        // Acquire a reference to UndoEngine.
        this.undoEng =
            GetService(typeof(UndoEngine))
            as UndoEngine;

        if (this.undoEng != null)
        {
            MessageBox.Show("UndoEngine");
        }
    }