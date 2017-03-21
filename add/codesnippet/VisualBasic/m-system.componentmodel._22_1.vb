    ' This utility method connects the designer to various
    ' services it will use. 
    Private Sub InitializeServices()

        ' Acquire a reference to DesignerActionService.
        Me.actionService = GetService(GetType(DesignerActionService))

        ' Acquire a reference to DesignerActionUIService.
        Me.actionUiService = GetService(GetType(DesignerActionUIService))

        ' Acquire a reference to IComponentChangeService.
        Me.changeService = GetService(GetType(IComponentChangeService))

        ' Hook the IComponentChangeService events.
        If (Me.changeService IsNot Nothing) Then
            AddHandler Me.changeService.ComponentChanged, AddressOf ChangeService_ComponentChanged

            AddHandler Me.changeService.ComponentAdded, AddressOf ChangeService_ComponentAdded

            AddHandler Me.changeService.ComponentRemoved, AddressOf changeService_ComponentRemoved
        End If

        ' Acquire a reference to ISelectionService.
        Me.selectionService = GetService(GetType(ISelectionService))

        ' Hook the SelectionChanged event.
        If (Me.selectionService IsNot Nothing) Then
            AddHandler Me.selectionService.SelectionChanged, AddressOf selectionService_SelectionChanged
        End If

        ' Acquire a reference to IDesignerEventService.
        Me.eventService = GetService(GetType(IDesignerEventService))

        If (Me.eventService IsNot Nothing) Then
            AddHandler Me.eventService.ActiveDesignerChanged, AddressOf eventService_ActiveDesignerChanged
        End If

        ' Acquire a reference to IDesignerHost.
        Me.host = GetService(GetType(IDesignerHost))

        ' Acquire a reference to IDesignerOptionService.
        Me.optionService = GetService(GetType(IDesignerOptionService))

        ' Acquire a reference to IEventBindingService.
        Me.eventBindingService = GetService(GetType(IEventBindingService))

        ' Acquire a reference to IExtenderListService.
        Me.listService = GetService(GetType(IExtenderListService))

        ' Acquire a reference to IReferenceService.
        Me.referenceService = GetService(GetType(IReferenceService))

        ' Acquire a reference to ITypeResolutionService.
        Me.typeResService = GetService(GetType(ITypeResolutionService))

        ' Acquire a reference to IComponentDiscoveryService.
        Me.componentDiscoveryService = GetService(GetType(IComponentDiscoveryService))

        ' Acquire a reference to IToolboxService.
        Me.toolboxService = GetService(GetType(IToolboxService))

        ' Acquire a reference to UndoEngine.
        Me.undoEng = GetService(GetType(UndoEngine))

        If (Me.undoEng IsNot Nothing) Then
            MessageBox.Show("UndoEngine")
        End If
    End Sub